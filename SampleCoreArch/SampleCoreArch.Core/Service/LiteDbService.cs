using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LiteDB;
using Microsoft.Extensions.Logging;
using SampleCoreArch.Core.Common;
using SampleCoreArch.Core.Enums;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Core.Service
{
    public abstract class LiteDbService<T> : ILiteDbService<T>, IDisposable where T : class, IEntity, new()
    {
        private readonly LiteRepository _liteRepository;
        private readonly ILogger _logger;

        protected LiteDbService(LiteRepository liteRepository, ILogger logger = null)
        {
            _liteRepository = liteRepository;
            _logger = logger;
        }


        #region CRUD-Operation

        public Result<LiteQueryable<T>> Query(string collectionName = null)
        {
            var result = new Result<LiteQueryable<T>>();
            try
            {
                result.ResultObject = _liteRepository.Query<T>(collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<bool> Delete(BsonValue id, string collectionName = null)
        {
            var result = new Result<bool>();
            try
            {
                result.ResultObject = _liteRepository.Delete<T>(id, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<int> Delete(Query query, string collectionName = null)
        {
            var result = new Result<int>();
            try
            {
                result.ResultObject = _liteRepository.Delete<T>(query, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<int> Delete(Expression<Func<T, bool>> predicate, string collectionName = null)
        {
            var result = new Result<int>();
            try
            {
                result.ResultObject = _liteRepository.Delete(predicate, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<List<T>> Fetch(Query query = null, string collectionName = null)
        {
            var result = new Result<List<T>>();
            try
            {
                result.ResultObject = _liteRepository.Fetch<T>(query, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<List<T>> Fetch(Expression<Func<T, bool>> predicate, string collectionName = null)
        {
            var result = new Result<List<T>>();
            try
            {
                result.ResultObject = _liteRepository.Fetch(predicate, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<T> First(Query query = null, string collectionName = null)
        {
            var result = new Result<T>();
            try
            {
                result.ResultObject = _liteRepository.First<T>(query, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<T> First(Expression<Func<T, bool>> predicate, string collectionName = null)
        {
            var result = new Result<T>();
            try
            {
                result.ResultObject = _liteRepository.First(predicate, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<T> FirstOrDefault(Query query = null, string collectionName = null)
        {
            var result = new Result<T>();
            try
            {
                result.ResultObject = _liteRepository.FirstOrDefault<T>(query, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<T> FirstOrDefault(Expression<Func<T, bool>> predicate, string collectionName = null)
        {
            var result = new Result<T>();
            try
            {
                result.ResultObject = _liteRepository.FirstOrDefault(predicate, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<bool> Insert(T entity, string collectionName = null)
        {
            var result = new Result<bool>();
            try
            {
                _liteRepository.Insert(entity, collectionName);
                result.ResultObject = true;
            }
            catch (Exception ex)
            {
                result.ResultObject = false;
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<int> Insert(IEnumerable<T> entities, string collectionName = null)
        {
            var result = new Result<int>();
            try
            {
                result.ResultObject = _liteRepository.Insert(entities, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<T> Single(Expression<Func<T, bool>> predicate, string collectionName = null)
        {
            var result = new Result<T>();
            try
            {
                result.ResultObject = _liteRepository.Single(predicate, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<T> Single(Query query = null, string collectionName = null)
        {
            var result = new Result<T>();
            try
            {
                result.ResultObject = _liteRepository.Single<T>(query, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<T> SingleById(BsonValue id, string collectionName = null)
        {
            var result = new Result<T>();
            try
            {
                result.ResultObject = _liteRepository.SingleById<T>(id, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<T> SingleOrDefault(Query query = null, string collectionName = null)
        {
            var result = new Result<T>();
            try
            {
                result.ResultObject = _liteRepository.SingleOrDefault<T>(query, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<T> SingleOrDefault(Expression<Func<T, bool>> predicate, string collectionName = null)
        {
            var result = new Result<T>();
            try
            {
                result.ResultObject = _liteRepository.SingleOrDefault(predicate, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<bool> Update(T entity, string collectionName = null)
        {
            var result = new Result<bool>();
            try
            {
                result.ResultObject = _liteRepository.Update(entity, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<int> Update(IEnumerable<T> entities, string collectionName = null)
        {
            var result = new Result<int>();
            try
            {
                result.ResultObject = _liteRepository.Update(entities, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<int> Upsert(IEnumerable<T> entities, string collectionName = null)
        {
            var result = new Result<int>();
            try
            {
                result.ResultObject = _liteRepository.Upsert(entities, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        public Result<bool> Upsert(T entity, string collectionName = null)
        {
            var result = new Result<bool>();
            try
            {
                result.ResultObject = _liteRepository.Upsert(entity, collectionName);
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;

                result.ResultStatus = false;
            }

            return result;
        }

        #endregion

        public Result<List<T>> Paging(Expression<Func<T, bool>> filter = null, int skip = 1, int take = 5,
            string collectionName = null)
        {
            var result = new Result<List<T>>();

            try
            {
                skip = (skip - 1);
                var skipCount = skip == 0 ? 0 : (skip * take);

                result.ResultObject = _liteRepository.Query<T>(collectionName).Where(filter ?? (f => true))
                    .Skip(skipCount).Limit(take).ToList();
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;
                result.ResultStatus = false;
            }

            return result;
        }

        public Result<int> Count(Expression<Func<T, bool>> filter = null, string collectionName = null)
        {
            var result = new Result<int>();

            try
            {
                result.ResultObject = _liteRepository.Query<T>(collectionName).Where(filter ?? (f => true)).Count();
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştu => " + ex;
                result.ResultInnerMessage = "Hata Oluştu => " + ex.InnerException;
                result.ResultStatus = false;
            }

            return result;
        }


        #region Dispose

        public void Dispose()
        {
            _liteRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}