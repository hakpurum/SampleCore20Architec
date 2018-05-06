using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SampleCoreArch.Core.Logging
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="T:Microsoft.Extensions.Logging.ILoggerProvider" />
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLoggerProvider"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public CustomLoggerProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates the logger.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        ILogger ILoggerProvider.CreateLogger(string category)
        {
            return _serviceProvider.GetRequiredService<ILogger>();
        }

        void IDisposable.Dispose()
        {
            
        }
    }
}