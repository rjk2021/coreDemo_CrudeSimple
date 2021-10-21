using Entities;
using Entities.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Repository
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly AppDbContext _context;

        public PersonsRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task< Persons> Create(Persons _object)
        {
            var obj= await _context.AddAsync(_object);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }

        public async Task<Persons> GetById(int? id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<List<Persons>>GetPersonsAll()
        {
            return await  _context.Persons.ToListAsync();
        }

        public async Task  Remove(int id)
        {
            var person  =await _context.Persons.FindAsync(id);
            _context.Remove(person); 
            await _context.SaveChangesAsync();
        }

        public async Task Update(Persons _object)
        {
            var obj =  _context.Update(_object);
            await _context.SaveChangesAsync();
        }
    }
}
