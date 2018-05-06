namespace SampleCoreArch.Core.Concrete
{
    /// <summary>
    /// Mail gönderimi için kullanılır.
    /// </summary>
    public class MailModel
    {
        /// <summary>
        /// Maili gönderen kim.
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Mail kime gönderilecek.
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Bilgilendirilecek kişiler.
        /// </summary>
        public string Cc { get; set; }
        /// <summary>
        /// Bilgilendirilecek kişiler gizli.
        /// </summary>
        public string Bcc { get; set; }
        /// <summary>
        /// Mail Konu.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Mail içeriği.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Mail Sunucusu.
        /// </summary>
        public string MailServer { get; set; }
        /// <summary>
        /// Mail sunucu kullanıcı adı.
        /// </summary>
        public string MailUser { get; set; }
        /// <summary>
        /// Mail sunucu kullanıcı şifresi.
        /// </summary>
        public string MailPassword { get; set; }
        /// <summary>
        /// Mail sunucu port numarası.
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// SSL aktif mi.
        /// </summary>
        public bool EnableSsl { get; set; }
        /// <summary>
        /// Mail ile gönderilecek dosya eki.
        /// </summary>
        public string AttachmentFilename { get; set; }
    }
}