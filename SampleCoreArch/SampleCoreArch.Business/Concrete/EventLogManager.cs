using System;
using System.IO;
using System.Net;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SampleCoreArch.Business.Interfaces;
using SampleCoreArch.Core.Enums;
using SampleCoreArch.Core.Interfaces;
using SampleCoreArch.Core.Logging;
using SampleCoreArch.Core.Service;
using SampleCoreArch.Core.Utility;
using SampleCoreArch.DataLayer.Interfaces;

namespace SampleCoreArch.Business.Concrete
{
    public class EventLogManager : EntityService<EventLog>, IEventLogService, ILogger
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventLogDal _eventLog;

        public EventLogManager(IEventLogDal eventLog, IUnitOfWork unitOfWork) : base(eventLog, unitOfWork)
        {
            _eventLog = eventLog;
            _unitOfWork = unitOfWork;
        }

       

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel.GetHashCode() >= SampleUtility.DefaultLogLevel.GetHashCode();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = formatter(state, exception);
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            if (exception != null)
            {
                message += "\n" + exception;
            }

            var eventLog = new EventLog
            {
                Message = message,
                EventId = eventId.Id,
                LogLevel = logLevel.ToString(),
                CreatedTime = DateTime.UtcNow,
                IpAdress = SampleUtility.GetIp4Adress(),
                HostName = Dns.GetHostName()
            };

            InsertLog(eventLog);
        }

        private void InsertLog(EventLog eventLog)
        {
            if (SampleUtility.LogType.Contains(LogType.Db.ToString()))
            {
                InsertLiteDbLog(eventLog);
            }
            if (SampleUtility.LogType.Contains(LogType.File.ToString()))
            {
                WriteTextToFile(eventLog);
            }
        }

        private void InsertLiteDbLog(EventLog eventLog)
        {
            try
            {
                _eventLog.Add(eventLog);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                WriteTextToFile(eventLog);
                WriteTextToFile(new EventLog
                {
                    EventId = LoggingEvents.InsertItem,
                    HostName = eventLog.HostName,
                    IpAdress = eventLog.IpAdress,
                    LogLevel = eventLog.LogLevel,
                    Message = ex.ToString()
                });
            }
        }

        private void WriteTextToFile(EventLog eventLog)
        {
            try
            {
                var message = JsonConvert.SerializeObject(eventLog) + ",";

                var filePath = SampleUtility.LogWriteTextToFile;
                var fileInfo = new FileInfo(filePath);
                if (!Directory.Exists(fileInfo.DirectoryName))
                {
                    Directory.CreateDirectory(fileInfo.DirectoryName);
                }
                using (var streamWriter = new StreamWriter(filePath, true))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }


        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}