using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors.Data.Test.Helpers
{
    public static class EfHelper
    {
        public static Mock<DbSet<T>> AsMockDbSet<T>(IList<T> data, bool callBase = true) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            var queryable = data.AsQueryable();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            mockSet.CallBase = callBase;

            return mockSet;
        }
    }
}
