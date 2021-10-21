using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    public interface IGenericRepository<T> where T: class 
    {

        List<T> GetPersonsAll();

        T GetById(int? id);
        T Create(T _object);
        void Update(T _object);

        void Remove(int id);


    }
}
