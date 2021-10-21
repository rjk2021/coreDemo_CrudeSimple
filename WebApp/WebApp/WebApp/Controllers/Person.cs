using Data.DAL;

using Data.DAL.Repository;
using Entities;
using Entities.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class Person : Controller
    {


        //private readonly AppDbContext _person;


        //public Person(AppDbContext person)
        //{
        //    _person = person;

        //}
        private readonly IPersonsRepository _person;


        public Person(IPersonsRepository person)
        {
            _person = person;

        }
        public async Task<IActionResult> Index()
        {
            var persons =await  _person.GetPersonsAll();

            return View(persons);
        }
        public async Task< IActionResult> Details(int? personId)
        {
            if (personId == null)
            {
                return NotFound();
            }
            var person = await _person.GetById(personId);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        //AddOrEdit Get Method
        public async Task< IActionResult> Save(int? personId)
        {
            ViewBag.PageName = personId == null ? "Create Person" : "Edit Person";
            ViewBag.IsEdit = personId == null ? false : true;
            if (personId == null)
            {
                return View();
            }
            else
            {
                var person =  await _person.GetById(personId);

                if (person == null)
                {
                    return NotFound();
                }
                return View(person);
            }
        }

        //AddOrEdit Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Save(int Id, [Bind("Id,UserName,UserEmail")] Persons personsData)
        {
            bool IsExist = false;

            Persons person = await   _person.GetById(Id);

            if (person != null)
            {
                IsExist = true;
            }
            else
            {
                person = new Persons();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    person.UserEmail = personsData.UserEmail;
                    person.UserName = personsData.UserName;
                    person.CreatedOn = DateTime.Now;
                    person.IsDeleted = false;


                    if (IsExist)
                    {
                       await  _person.Update(person);
                    }
                    else
                    {
                       await _person.Create(person);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personsData);
        }

        // GET: person/Delete/1
        public async Task< IActionResult> Delete(int? personId)
        {
            if (personId == null)
            {
                return NotFound();
            }
            var person = await  _person.GetById(personId);

            return View(person);
        }

        // POST: person/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Delete(int Id)
        {
           await _person.Remove(Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
