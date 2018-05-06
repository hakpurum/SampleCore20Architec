using System;
using System.ComponentModel.DataAnnotations;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Core.Logging
{
    /// <summary>
    /// Loglama mdel nesnesi.
    /// </summary>
    /// <seealso cref="SampleCoreArch.Core.Interfaces.IEntity" />
    [Serializable]
    public sealed class EventLog : IEntity
    {
        /// <summary>
        /// Birincil otomatik artan alan.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Log mesajı.
        /// </summary>
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// Log işlem id alanı..
        /// </summary>
        public int EventId { get; set; }
        /// <summary>
        /// Loglama seviyesi.
        /// </summary>
        public string LogLevel { get; set; }
        /// <summary>
        /// Kullanıcı ip adresi.
        /// </summary>
        public string IpAdress { get; set; }
        /// <summary>
        /// Host adı.
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// Log oluşturulma tarihi.
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}