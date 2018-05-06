using System;

namespace SampleCoreArch.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}