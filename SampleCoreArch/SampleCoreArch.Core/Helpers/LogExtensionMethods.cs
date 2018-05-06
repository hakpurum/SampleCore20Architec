using System;

namespace SampleCoreArch.Core.Helpers
{
    /// <summary>
    /// Loglama işlemi sırasında exception lar için yazılmış extension method.
    /// </summary>
    public static class LogExtensionMethods
    {
        /// <summary>
        /// Exception mesajını düzenleyerek belli bir formatta string olarak return eder.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="methodName">Log kaydının atıldığı method adı.</param>
        /// <param name="fullName">Log kaydının atıldığı full class yolu.Örn : typeof(T).FullName</param>
        /// <returns></returns>
        public static string ToLog(this Exception ex, string methodName, string fullName)
        {
            return $"MethodName => {methodName}() FullName => {fullName} Message => {ex.Message} InnerException => {ex.InnerException} StackTrace => {ex.StackTrace}";
        }
    }
}