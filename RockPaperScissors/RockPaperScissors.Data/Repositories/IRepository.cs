using RockPaperScissors.Dto;
using RockPaperScissors.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Data.Repositories
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : class;
        T GetById<T>(int id) where T : class;
        T Create<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
    }
}
