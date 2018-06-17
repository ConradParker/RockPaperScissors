using RockPaperScissors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using RockPaperScissors.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RockPaperScissors.Data.Repositories
{
    public class Repository : IRepository
    {
        #region Private Variables

        protected RockPaperScissorsContext _dbContext;

        #endregion Private Variables

        #region Constructor(s)

        public Repository(RockPaperScissorsContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion Constructor(s)

        #region Public Methods

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>IQueryable<T></returns>
        public IQueryable<T> GetAll<T>() where T : class
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Fidn an entity by its primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById<T>(int id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T Create<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="id"></param>
        public void Delete<T>(int id) where T : class
        {
            var entity = GetById<T>(id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        #endregion Public Methods
    }
}