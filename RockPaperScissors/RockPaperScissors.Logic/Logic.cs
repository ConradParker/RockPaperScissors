using RockPaperScissors.Data.Repositories;

namespace RockPaperScissors.Logic
{
    public class Logic : ILogic
    {
        #region Private Variables

        private IRepository _repository;

        #endregion Private Variables

        #region Constructor(s)

        public Logic(IRepository repository)
        {
            _repository = repository;
        }

        #endregion Constructor(s)

        #region Public Methods

        /// <summary>
        /// Find a Match by its key
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public T GetById<T>(int id) where T : class
        {
            return _repository.GetById<T>(id);
        }

        #endregion Public Methods
    }
}
