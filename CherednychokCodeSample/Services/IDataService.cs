using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CommonLibrary.Interfaces
{
    /// <summary>
    /// Interface for data services
    /// </summary>
    /// <author>Dmitry Zhemkov</author>
    /// <date>22 April 2013</date>
    public interface IDataService<T>
    {
        IEnumerable<T> GetData(Expression<Func<T, bool>> predicate);

        bool Add(T record);
        bool Edit(T recordOld, T recordNew);
        bool Remove(T record);
    }
}
