using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestingLayer
{
    public class UnitTest_Species
    {
        private AnimalDbContext _dbContext;
        private SpeciesContext _speciesContext;
        DbContextOptionsBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _dbContext = new AnimalDbContext(builder.Options);
            _speciesContext = new SpeciesContext(_dbContext);
        }

        [Test]
        public void TestCreateSpecies()
        {
            int speciesBefore = _speciesContext.ReadAll().Count();

            _speciesContext.Create(new Species("animol", "bozaenik", 13));

            int speciesAfter = _speciesContext.ReadAll().Count();

            Assert.IsTrue(speciesBefore != speciesAfter);
        }

        [Test]
        public void TestReadSpecies()
        {
            _speciesContext.Create(new Species("animol", "bozaenik", 13));

            Species species = _speciesContext.Read(1);

            Assert.That(species != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateSpecies()
        {
            _speciesContext.Create(new Species("animol", "bozaenik", 13));

            Species species = _speciesContext.Read(1);

            species.Name = "kotka";

            _speciesContext.Update(species);

            Species species1 = _speciesContext.Read(1);

            Assert.IsTrue(species1.Name == "poem", "Species Update() does not change name!");
        }

        [Test]
        public void TestDeleteSpecies()
        {
            _speciesContext.Create(new Species("animal", "vlechogo", 14));

            int speciesBeforeDeletion = _speciesContext.ReadAll().Count();

            _speciesContext.Delete(1);

            int speciesAfterDeletion = _speciesContext.ReadAll().Count();

            Assert.AreNotEqual(speciesBeforeDeletion, speciesAfterDeletion);
        }
    }
}