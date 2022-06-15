using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLayer
{
    public class UnitTest_Diet
    {
        private AnimalDbContext _dbContext;
        private DietContext _DietContext;
        DbContextOptionsBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _dbContext = new AnimalDbContext(builder.Options);
            _DietContext = new DietContext(_dbContext);
        }

        [Test]
        public void CreateDiet()
        {
            int dietBefore = _DietContext.ReadAll().Count();
            _DietContext.Create(new Diet("mesoqdni",5,"many"));
            int dietAfter = _DietContext.ReadAll().Count();
            Assert.IsTrue(dietBefore != dietAfter);
        }
        [Test]
        public void ReadDiet()
        {
            _DietContext.Create(new Diet("mesoqdni", 5, "many"));
            Diet Diet = _DietContext.Read(1);
            Assert.That(Diet != null, "There's no record with id 1");
        }
        [Test]
        public void UpdateDiet()
        {
            _DietContext.Create(new Diet("trevopasni",2,"many"));
            Diet Diet = _DietContext.Read(1);
            Diet.Order = "mesoqdni";
            _DietContext.Update(Diet);
            Diet DietAlt = _DietContext.Read(1);
            Assert.IsTrue(DietAlt.Order == "mesoqdni", "Update() doesn't change anything!");
        }
        [Test]
        public void DeleteDiet()
        {
            _DietContext.Create(new Diet("Delete diet",1,"many"));
            int dietBeforeDel = _DietContext.ReadAll().Count();
            _DietContext.Delete(1);
            int dietAfterDel = _DietContext.ReadAll().Count();
            Assert.AreNotEqual(dietBeforeDel, dietAfterDel);
        }
    }
}
