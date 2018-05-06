using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Sockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SampleCoreArch.Core.Concrete;

namespace SampleCoreArch.Core.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class SampleUtility
    {
        /// <summary>
        /// LiteDb bağlantı bilgisi.
        /// </summary>
        public static string LiteDbConnStr => GetAppSetting<string>("connectionStrings:LiteDB", null);

        /// <summary>
        ///  LiteDb bağlantı bilgisi.
        /// </summary>
        public static LiteDB.ConnectionString LiteDbConnection => new LiteDB.ConnectionString(LiteDbConnStr);

        /// <summary>
        /// Mssql bağlantı bilgisi.
        /// </summary>
        public static string SqlDbConnStr => GetAppSetting<string>("connectionStrings:SqlDbConn", null);

        /// <summary>
        /// Default loglama seviyesi.
        /// </summary>
        public static LogLevel DefaultLogLevel => GetAppSetting("Logging:LogLevel:Default", LogLevel.Information);

        /// <summary>
        /// Loglama tipi.
        /// </summary>
        public static string LogType => GetAppSetting("Logging:LogType", "File");

        /// <summary>
        /// Dosya tabanlı loglamada kullanılacak isimlendirme formatı.
        /// </summary>
        public static string LogWriteTextToFile
        {
            get
            {
                var appKey = GetAppSetting("Logging:LogWriteTextToFile", "C:\\temp\\CustomLog.txt");
                appKey = appKey.Replace("{shortdate}", DateTime.Now.ToShortDateString());
                appKey = appKey.Replace("{longdate}", DateTime.Now.ToLongDateString());
                appKey = appKey.Replace("{basedir}", AppDomain.CurrentDomain.BaseDirectory);

                return appKey;
            }
        }

        /// <summary>
        /// AppSetting değerini getirir.
        /// </summary>
        /// <typeparam name="T">Dönüş tipi.</typeparam>
        /// <param name="key">AppSetting key adı.</param>
        /// <param name="defaultValue">AppSetting key bulunamazsa default değeri.</param>
        /// <returns></returns>
        public static T GetAppSetting<T>(string key, T defaultValue)
        {
            if (string.IsNullOrEmpty(key)) return defaultValue;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();

            var value = configuration.GetSection(key).Value;
            try
            {
                if (value == null) return default(T);
                var theType = typeof(T);
                if (theType.IsEnum)
                    return (T) Enum.Parse(theType, value, true);

                return (T) Convert.ChangeType(value, theType);
            }
            catch (Exception)
            {
                // ignored
            }

            return defaultValue;
        }

        /// <summary>
        /// Mail gönderme işlemi.
        /// </summary>
        /// <param name="mailModel">Ma ilModel tipinde model alır.</param>
        public static void SendMail(MailModel mailModel)
        {
            var client = new SmtpClient
            {
                Port = mailModel.Port,
                Host = mailModel.MailServer,
                EnableSsl = mailModel.EnableSsl,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mailModel.MailUser, mailModel.MailPassword)
            };

            var mail = new MailMessage
            {
                Sender = new MailAddress(mailModel.MailUser),
                From = new MailAddress(mailModel.From)
            };

            if (!string.IsNullOrEmpty(mailModel.AttachmentFilename))
            {
                var attachment = new Attachment(mailModel.AttachmentFilename, MediaTypeNames.Application.Octet);
                var disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(mailModel.AttachmentFilename);
                disposition.ModificationDate = File.GetLastWriteTime(mailModel.AttachmentFilename);
                disposition.ReadDate = File.GetLastAccessTime(mailModel.AttachmentFilename);
                disposition.FileName = Path.GetFileName(mailModel.AttachmentFilename);
                disposition.Size = new FileInfo(mailModel.AttachmentFilename).Length;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                mail.Attachments.Add(attachment);
            }


            if (mailModel.To != null)
                foreach (var item in mailModel.To.Split(','))
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        mail.To.Add(item);
                    }
                }

            if (mailModel.Cc != null)
                foreach (var item in mailModel.Cc.Split(','))
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        mail.CC.Add(item);
                    }
                }

            if (mailModel.Bcc != null)
                foreach (var item in mailModel.Bcc.Split(','))
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        mail.Bcc.Add(item);
                    }
                }
            mail.Subject = mailModel.Subject;
            mail.Body = mailModel.Body;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mail);
        }

        /// <summary>
        /// Kullanıcının ip bilgisini döner.
        /// </summary>
        /// <returns>Kullanıcı İp bilgisini string tipinde döner.</returns>
        public static string GetIp4Adress()
        {
            var hostAdress = Dns.GetHostName();
            var ipadress = Dns.GetHostEntry(hostAdress).AddressList.FirstOrDefault(f => f.AddressFamily == AddressFamily.InterNetwork);
            return ipadress?.ToString() ?? "-1";
        }
    }
}