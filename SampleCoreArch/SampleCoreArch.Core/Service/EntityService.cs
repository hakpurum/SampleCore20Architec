using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using SampleCoreArch.Core.Common;
using SampleCoreArch.Core.Enums;
using SampleCoreArch.Core.Helpers;
using SampleCoreArch.Core.Interfaces;
using SampleCoreArch.Core.Logging;

namespace SampleCoreArch.Core.Service
{
    public abstract class EntityService<T> : IEntityService<T>, IDisposable where T : class, IEntity, new()
    {
        private string ClassFullName => typeof(T).FullName;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepository<T> _repository;
        private readonly ILogger _logger;

        protected EntityService(IEntityRepository<T> repository, IUnitOfWork unitOfWork, ILogger logger = null)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public Result<T> GetFindById(int id)
        {
            var result = new Result<T>();

            try
            {
                _logger?.LogInformation(LoggingEvents.GetItem, $"GetFindById()EntityService => {ClassFullName}");
                result.ResultObject = _repository.GetFindById(id);
            }
            catch (Exception ex)
            {
                _logger?.LogError(LoggingEvents.GetItem, ex.ToLog("Get", ClassFullName));
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
            }

            return result;
        }

        public virtual Result<T> Get(Expression<Func<T, bool>> filter = null)
        {
            var result = new Result<T>();

            try
            {
                _logger?.LogInformation(LoggingEvents.GetItem, $"Get()EntityService => {ClassFullName}");
                result.ResultObject = _repository.Get(filter);
            }
            catch (Exception ex)
            {
                _logger?.LogError(LoggingEvents.GetItem, ex.ToLog("Get", ClassFullName));
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
            }

            return result;
        }

        public virtual Result<IEnumerable<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            var result = new Result<IEnumerable<T>>();
            try
            {
                _logger?.LogInformation(LoggingEvents.ListItems, $"GetList()EntityService => {ClassFullName}");
                result.ResultObject = _repository.GetList(filter).ToList();
            }
            catch (Exception ex)
            {
                _logger?.LogError(LoggingEvents.ListItems, ex.ToLog("GetList", ClassFullName));
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
            }

            return result;
        }

        public virtual Result<IEnumerable<T>> GetListPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 15)
        {
            var result = new Result<IEnumerable<T>>();

            try
            {
                _logger?.LogInformation(LoggingEvents.ListPaging, $"GetListPaging()EntityService => {ClassFullName}");
                result.ResultObject = _repository.GetListPaging(filter, out total, index, size);
            }
            catch (Exception ex)
            {
                total = 0;
                _logger?.LogError(LoggingEvents.ListPaging, ex.ToLog("GetListPaging", ClassFullName));
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
            }

            return result;
        }

        public virtual Result<T> Add(T entity)
        {
            var result = new Result<T>();
            try
            {
                _logger?.LogInformation(LoggingEvents.InsertItem, $"Add()EntityService => {ClassFullName}");
                result.ResultObject = _repository.Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger?.LogError(LoggingEvents.InsertItem, ex.ToLog("Add", ClassFullName));
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
            }

            return result;
        }

        public virtual Result<T> Update(T entity)
        {
            var result = new Result<T>();
            try
            {
                _logger?.LogInformation(LoggingEvents.UpdateItem, $"Update()EntityService => {ClassFullName}");
                result.ResultObject = _repository.Update(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger?.LogError(LoggingEvents.UpdateItem, ex.ToLog("Update", ClassFullName));
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
            }

            return result;
        }

        public virtual Result<bool> Delete(T entity)
        {
            var result = new Result<bool>();
            try
            {
                _logger?.LogInformation(LoggingEvents.DeleteItem, $"Delete()EntityService => {ClassFullName}");
                _repository.Delete(entity);
                _unitOfWork.Commit();
                result.ResultObject = true;
            }
            catch (Exception ex)
            {
                _logger?.LogError(LoggingEvents.DeleteItem, ex.ToLog("Delete", ClassFullName));
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultObject = false;
                result.ResultStatus = false;
            }

            return result;
        }

        public virtual Result<bool> AddRange(IEnumerable<T> listEntity)
        {
            var result = new Result<bool>();
            try
            {
                _logger?.LogInformation(LoggingEvents.InsertRange, $"AddRange()EntityService => {ClassFullName}");
                _repository.AddRange(listEntity);
                _unitOfWork.Commit();
                result.ResultObject = true;
            }
            catch (Exception ex)
            {
                _logger?.LogError(LoggingEvents.InsertRange, ex.ToLog("AddRange", ClassFullName));
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
            }

            return result;
        }

        public virtual Result<bool> Delete(Expression<Func<T, bool>> filter)
        {
            var result = new Result<bool>();
            try
            {
                _logger?.LogInformation(LoggingEvents.DeleteItem, $"Delete()EntityService => {ClassFullName}");
                _repository.Delete(filter);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger?.LogError(LoggingEvents.DeleteItem, ex.ToLog("Delete", ClassFullName));
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
            }

            return result;
        }

        public Result<bool> DeleteAll(Expression<Func<T, bool>> filter = null)
        {
            var result = new Result<bool>();
            try
            {
                _logger?.LogInformation(LoggingEvents.DeleteAll, $"DeleteAll()EntityService => {ClassFullName}");
                _repository.DeleteAll(filter);
                _unitOfWork.Commit();
                result.ResultObject = true;
            }
            catch (Exception ex)
            {
                _logger?.LogError(LoggingEvents.DeleteAll, ex.ToLog("DeleteAll", ClassFullName));
                result.ResultCode = (int) ResultStatusCode.InternalServerError;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
            }

            return result;
        }

        public void Dispose()
        {
            _repository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}