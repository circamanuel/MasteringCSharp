using System;
using System.Collections.Generic;
using System.Text;

namespace genericClass
{
    internal interface IEntity
    {
        int Id { get; }    
    }
    internal class Repository<T> where T: IEntity
    {
        private List<T> Values = new List<T>();

        public void Add(T entity)
        {
            Values.Add(entity);
        }
    }
}
