﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        static List<Person> data = new List<Person>()
            {
                new Person(){ Id = 1,Name = "Will",Age = 18 },
                new Person(){ Id = 2,Name = "Tom",Age = 28 },
                new Person(){ Id = 3,Name = "Mary",Age = 38 },
                new Person(){ Id = 4,Name = "John",Age = 48 },
            };
        public ActionResult Index()
        {
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                data.Add(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }
        public ActionResult Edit(int id)
        {
            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Person person)
        {
            if (ModelState.IsValid)
            {
                var one = data.FirstOrDefault(p => p.Id == person.Id);
                one.Name = person.Name;
                one.Age = person.Age;
                return RedirectToAction("Index");
            }
            return View(person);
        }
        public ActionResult Details(int id)
        {
            return View(data.FirstOrDefault(p => p.Id == id));
        }
        public ActionResult Delete(int id)
        {
            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,FormCollection form)
        {
            data.Remove(data.FirstOrDefault(p => p.Id == id));
            return RedirectToAction("Index");
        }
    }
}