using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Application.Service
{
    public class BaseCRUDService<TDbContextLocator,TEntity>
        where TEntity : class, IPrivateEntity, new()
        where TDbContextLocator : class, IDbContextLocator
    {
        /// <summary>
        /// 注入仓储
        /// </summary>
        private readonly IRepository<TEntity, TDbContextLocator> _repository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseCRUDService(IRepository<TEntity, TDbContextLocator> repository)
        {
            _repository = repository;
        }
        #region ==同步方法==
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Insert(TEntity entity) => _repository.InsertNow(entity).Entity;

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity) => _repository.UpdateNow(entity, ignoreNullValues: true).Entity;

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(int id) => _repository.DeleteNow(id);

        /// <summary>
        /// 单条查询
        /// </summary>
        /// <param name="id"></param>
        public TEntity Find(int id) => _repository.Find(id);
        #endregion

        #region ==异步方法==
        /// <summary>
        /// 新增-异步
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> InsertSync(TEntity entity)
        {
            // 如果不需要返回自增Id，使用 InsertAsync即可
            var newEntity = await _repository.InsertNowAsync(entity);
            return newEntity.Entity;
        }

        /// <summary>
        /// 更新-异步
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> UpdateSync(TEntity entity)
        {
            var newEntity = await _repository.UpdateAsync(entity, ignoreNullValues: true);
            return newEntity.Entity;
        }

        /// <summary>
        /// 清除-异步
        /// </summary>
        /// <param name="id"></param>
        public async Task<bool> ClearSync(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }
        #endregion
    }
}
