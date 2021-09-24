using CommunalServices.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CommunalServices.Model
{
    /// <summary>Хранилище данных.</summary>
    public interface IRepository
    {
        /// <summary>Получение всех сущностей указанного типа из хранилища.</summary>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;

        /// <summary>Получение сущности по её идентификатору.</summary>
        Task<TEntity> GetAsync<TEntity>(int id) where TEntity : class;

        /// <summary>Создание сущности в хранилище.</summary>
        Task CreateAsync<TEntity>(TEntity entity);

        /// <summary>Редактирование сущности в хранилище.</summary>
        Task EditAsync<TEntity>(TEntity entity);

        /// <summary>Удаление сущности из хранилища.</summary>
        Task RemoveAsync<TEntity>(TEntity entity);

        /// <summary>
        /// Получение первой сущности удовлетворяющей условиям.
        /// </summary>
        /// <typeparam name="TEntity">Тип получаемой сущности.</typeparam>
        /// <param name="predicate">Лямбда-выражение для проверки каждого элемента на наличие условия.</param>
        /// <param name="includes">Коллекция лямбда-выражений, представляющих включаемые сущности.</param>
        Task<TEntity> FirstOrDefaultAsync<TEntity>(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, Object>>> includes)
            where TEntity : class;
    }
}
