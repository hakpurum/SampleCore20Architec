using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LiteDB;
using SampleCoreArch.Core.Interfaces;
using SampleCoreArch.Core.Utility;

namespace SampleCoreArch.Core.DataAccess
{
    public abstract class LiteDbRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly LiteRepository _liteRepository;

        protected LiteDbRepository(LiteRepository liteRepository)
        {
            _liteRepository = liteRepository;
        }

        public TEntity GetFindById(int id)
        {
            return _liteRepository.SingleById<TEntity>(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return _liteRepository.First(filter);
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return _liteRepository.Query<TEntity>().Where(filter ?? (f => true)).ToList()
                .AsQueryable(); //Fetch(filter ?? (f => true)).AsQueryable();
        }

        public IQueryable<TEntity> GetListPaging(Expression<Func<TEntity, bool>> filter, out int total, int index,int size)
        {
            throw new NotImplementedException();
        }

        public TEntity Add(TEntity entity)
        {
            _liteRepository.Insert(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _liteRepository.Update(entity);
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> listEntity)
        {
            _liteRepository.Insert(listEntity);
        }

        public void Delete(TEntity entity)
        {
            //_liteRepository.Delete<TEntity>(_liteRepository.Engine.FindOne());
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            _liteRepository.Delete(filter);
        }

        public void DeleteAll(Expression<Func<TEntity, bool>> filter = null)
        {
            BackUp();
            if (filter == null)
            {
                _liteRepository.Delete<TEntity>(Query.All());
            }
            else
            {
                _liteRepository.Delete(filter);
            }
        }

        public void Save()
        {
        }

        private static void BackUp()
        {
            var con = SampleUtility.LiteDbConnection;
            var fileDetail = new System.IO.FileInfo(con.Filename);
            var destFileName = $"//backup_{DateTime.Now:dd-mm-yyyy}_{fileDetail.Name}";
            System.IO.File.Copy(fileDetail.FullName, fileDetail.Directory + destFileName);
        }

        public void Dispose()
        {
            _liteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public void CustomSaveChanges()
        {
            
        }
    }
}