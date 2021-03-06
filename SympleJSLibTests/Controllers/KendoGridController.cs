﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SympleLib.MVC;

namespace SympleJSLibTests.Controllers
{
    public class KendoGridController : Controller
    {
        //
        // GET: /KendoGrid/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MultiSelect()
        {
            return View();
        }

        public ActionResult NoResults()
        {
            return View();
        }

        public ActionResult Temp()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var people = new List<Person>();
            people.Add(new Person { LastName="Alone", FirstName="All" });
            return Json(people, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DataSource(string search, bool? testBox)
        {
            var people = Person.PeopleCollection.AsQueryable();
            if(testBox == true)
            {
                people = people.Take(4);
            }
            if (string.IsNullOrEmpty(search) != true)
            {
                people = people.Where(x => x.LastName.Contains(search));
            }

            var dataSource = KendoUiHelper.ParseGridData<Person>(people);
            return Json(dataSource, JsonRequestBehavior.AllowGet);
        }


        public JsonResult EmptyDataSource()
        {
            var people = new List<Person>();
            people.Add(new Person { LastName = "Alone", FirstName = "All" });
            var dataSource = KendoUiHelper.ParseGridData<Person>(people.AsQueryable());
            return Json(dataSource, JsonRequestBehavior.AllowGet);
        }




        public ActionResult NoCaseSort()
        {
            return View();
        }
    }

    public class Person
    {
        public int id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsAlive { get; set; }

        public static IEnumerable<Person> PeopleCollection
        {
            get
            {
                var people = new List<Person>();
                people.Add(new Person { LastName = null, FirstName = "John", City = "Johnson", State = "NB", BirthDate = null, IsAlive = true });
                people.Add(new Person { LastName = "Hankok", FirstName = "John", City = "Pennsylivania", State = "PN", BirthDate = DateTime.Parse("2/1/1980"), IsAlive = true });
                people.Add(new Person { LastName = "Mayfield", FirstName = "Curtis", City = "SoulTown", State = "NO", BirthDate = DateTime.Parse("1/1/1950"), IsAlive = true });
                people.Add(new Person { LastName = "Wooten", FirstName = "Victor", City = "Salem", State = "OR", BirthDate = DateTime.Parse("1/1/1950"), IsAlive = true });
                people.Add(new Person { LastName = "Saw", FirstName = "Tenor", City = "Seattle", State = "WA", BirthDate = DateTime.Parse("1/1/1950"), IsAlive = true });
                people.Add(new Person { LastName = "Johnson", FirstName = "James", City = "SanFransico", State = "CA", BirthDate = DateTime.Parse("1/1/1950") });
                people.Add(new Person { LastName = "Lewis", FirstName = "Daniel", City = "Banning", State = "CA", BirthDate = DateTime.Parse("1/1/1950") });
                people.Add(new Person { LastName = "Lara", FirstName = "Heather", City = "Beaumont", State = "CA", BirthDate = DateTime.Parse("1/1/1950") });
                people.Add(new Person { LastName = "Jager", FirstName = "Mic", City = "Detroit", State = "MI", BirthDate = DateTime.Parse("1/1/1950") });
                people.Add(new Person { LastName = "Rock", FirstName = "Kid", City = "Detroit", State = "MI", BirthDate = DateTime.Parse("1/1/1950") });
                people.Add(new Person { LastName = "Smith", FirstName = "John", City = "Johnson", State = "NB", BirthDate = DateTime.Parse("1/1/1950"), IsAlive = true });
                people.Add(new Person { LastName = "Hankok", FirstName = "John", City = "Pennsylivania", State = "PN", BirthDate = DateTime.Parse("2/1/1980"), IsAlive = true });
                people.Add(new Person { LastName = "Mayfield", FirstName = "Curtis", City = "SoulTown", State = "NO", BirthDate = DateTime.Parse("1/1/1950"), IsAlive = true });
                people.Add(new Person { LastName = "Wooten", FirstName = "Victor", City = "Salem", State = "OR", BirthDate = DateTime.Parse("1/1/1950"), IsAlive = true });
                people.Add(new Person { LastName = "Saw", FirstName = "Tenor", City = "Seattle", State = "WA", BirthDate = DateTime.Parse("1/1/1950"), IsAlive = true });
                people.Add(new Person { LastName = "Johnson", FirstName = "James", City = "SanFransico", State = "CA", BirthDate = DateTime.Parse("1/1/1950") });
                people.Add(new Person { LastName = "Lewis", FirstName = "Daniel", City = "Banning", State = "CA", BirthDate = DateTime.Parse("1/1/1950") });
                people.Add(new Person { LastName = "Lara", FirstName = "Heather", City = "Beaumont", State = "CA", BirthDate = DateTime.Parse("1/1/1950") });
                people.Add(new Person { LastName = "Jager", FirstName = "Mic", City = "Detroit", State = "MI", BirthDate = DateTime.Parse("1/1/1950") });
                people.Add(new Person { LastName = "Rock", FirstName = "Kid", City = "Detroit", State = "MI", BirthDate = DateTime.Parse("1/1/1950") });

                for (int i = 0; i < people.Count(); i++)
                {
                    people[i].id = i;
                }

                return people.OrderBy(x=>x.LastName);
            }
        }
    }
}
