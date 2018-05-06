using System;
using SampleCoreArch.Core.Interfaces;
using SampleCoreArch.DataLayer.Concrete.EntityFramework;

namespace SampleCoreArch.Business
{
    public class UnitOfWork : IUnitOfWork
    {
        private SampleDbContext _context;

        public UnitOfWork(SampleDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            var transId = -1;
            if (_context.ChangeTracker.HasChanges())
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        if (_context != null)
                        {
                            transId = _context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception(ex.ToString());
                    }
                }
            }

            return transId;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
            _context = null;
        }
    }
}