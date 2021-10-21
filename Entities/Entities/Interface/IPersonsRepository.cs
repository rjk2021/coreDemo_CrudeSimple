using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interface
{
    public interface IPersonsRepository
    {

       Task< List<Persons>> GetPersonsAll();

       Task<Persons> GetById(int? id);
       Task<Persons> Create(Persons _object);
       Task Update(Persons _object);

        Task  Remove(int id);


    }
}
