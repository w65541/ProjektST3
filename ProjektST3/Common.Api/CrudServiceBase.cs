using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using Common.CrossCutting.Dtos;
using Common.Storage.Entities;
using Common.CrossCutting.Enums;

namespace Common.Api
{
    public class CrudServiceBase<TDbContext, TEntity, TDto>
            where TDbContext : BaseContext
            where TEntity : BaseEntity
            where TDto : class
    {
        private readonly TDbContext _dbContext;
        protected virtual Task OnBeforeRecordCreatedAsync(TDbContext dbContext, TEntity entity) => Task.CompletedTask;
        protected virtual Task OnAfterRecordCreatedAsync(TDbContext dbContext, TEntity entity) => Task.CompletedTask;

        public CrudServiceBase(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CrudOperationResult<TDto>?> Delete(int id)
        {
            var entity = await _dbContext
                .Set<TEntity>()
                .SingleOrDefaultAsync(e => e.Id!.Equals(id));
            if (entity == null)
            {
                return null;
                
                //return new CrudOperationResult<TDto>
                //{
                //    Status = CrudOperationResultStatus.RecordNotFound,
                //};
            }

            _dbContext.Set<TEntity>().Remove(entity);

            await _dbContext.SaveChangesAsync();

            return new CrudOperationResult<TDto>
            {
                Status = CrudOperationResultStatus.Success,
            };
        }

        public async Task<int> Create(TEntity entity)
        {
            await OnBeforeRecordCreatedAsync(_dbContext, entity);

            _dbContext
                .Set<TEntity>()
                .Add(entity);

            await _dbContext.SaveChangesAsync();
            await OnAfterRecordCreatedAsync(_dbContext, entity);

            return entity.Id;
        }

        public async Task<CrudOperationResult<TDto>> Update(int id, TEntity newEntity)
        {
            var entityBeforeUpdate = await GetById(id);

            if (entityBeforeUpdate == null)
            {
                return new CrudOperationResult<TDto>
                {
                    Status = CrudOperationResultStatus.RecordNotFound,
                };
            }

            UpdateExistingEntity(entityBeforeUpdate, newEntity);

            try
            {
                _dbContext.Set<TEntity>().Update(entityBeforeUpdate);
                await _dbContext.SaveChangesAsync();

                return new CrudOperationResult<TDto>
                {
                    Status = CrudOperationResultStatus.Success,
                    //Result = updatedDto
                };
            }
            catch (Exception ex)
            {
                return new CrudOperationResult<TDto>
                {
                    Status = CrudOperationResultStatus.Failure,

                };
            }
        }

        protected async Task<TEntity> GetById(int id)
        {
            var entity = await _dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .Where(e => e.Id!.Equals(id))
                .SingleOrDefaultAsync();

            return entity;
        }
        protected async Task<IEnumerable<TEntity>> Get()
        {
            var entities = await _dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        private void UpdateExistingEntity(TEntity existingEntity, TEntity newEntity)
        {
            var entityType = typeof(TEntity);
            foreach (var property in entityType.GetProperties())
            {
                if (property.CanWrite)
                {
                    var newValue = property.GetValue(newEntity);
                    property.SetValue(existingEntity, newValue);
                }
            }
        }
    }
}
