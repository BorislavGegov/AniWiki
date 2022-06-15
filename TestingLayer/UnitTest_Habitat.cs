using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestingLayer
{
    class UnitTest_Habitat
    {
        private AnimalDbContext _dbContext;
        private HabitatContext _habitatContext;
        DbContextOptionsBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _dbContext = new AnimalDbContext(builder.Options);
            _habitatContext = new HabitatContext(_dbContext);
        }

        [Test]
        public void TestCreateGenre()
        {
            int habitatsBefore = _habitatContext.ReadAll().Count();

            _habitatContext.Create(new Habitat("novel"));

            int habitatsAfter = _habitatContext.ReadAll().Count();

            Assert.IsTrue(habitatsBefore != habitatsAfter);
        }

        [Test]
        public void TestReadGenre()
        {
            _habitatContext.Create(new Habitat("novel"));

            Habitat genre = _habitatContext.Read(1);

            Assert.That(genre != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateGenre()
        {
            _habitatContext.Create(new Habitat("novel"));

            Habitat genre = _habitatContext.Read(1);

            genre.Name = "poem";

            _habitatContext.Update(genre);

            Habitat genre1 = _habitatContext.Read(1);

            Assert.IsTrue(genre1.Name == "poem", "Habitat Update() does not change name!");
        }

        [Test]
        public void TestDeleteGenre()
        {
            _habitatContext.Create(new Habitat("Delete genre"));

            int habitatsBeforeDeletion = _habitatContext.ReadAll().Count();

            _habitatContext.Delete(1);

            int habitatsAfterDeletion = _habitatContext.ReadAll().Count();

            Assert.AreNotEqual(habitatsBeforeDeletion, habitatsAfterDeletion);
        }
    }
}
