using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SpeciesContext : IDB<Species, int>
    {
        private AnimalDbContext _context;

        public SpeciesContext(AnimalDbContext context)
        {
            _context = context;
        }
        public void Create(Species item)
        {
            try
            {
                _context.Species.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _context.Species.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Species Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Species> query = _context.Species;

                if (noTracking)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                if (useNavigationProperties)
                {
                    query = query.Include(i => i.Diets).Include(i => i.Habitats);
                }

                return query.SingleOrDefault(i => i.ID == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Species> Read(int skip, int take, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Species> query = _context.Species.AsNoTrackingWithIdentityResolution();

                if (useNavigationProperties)
                {
                    query = query.Include(i => i.Diets).Include(i => i.Habitats);
                }

                return query.Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Species> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Species> query = _context.Species.AsNoTracking();

                if (useNavigationProperties)
                {
                    query = query.Include(i => i.Diets).Include(i => i.Habitats);
                }

                return query.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Update(Species item, bool useNavigationProperties = false)
        {
            try
            {
                Species SpeciesFromDB = Read(item.ID, useNavigationProperties);

                if (useNavigationProperties)
                {

                    List<Diet> diets = new List<Diet>();
                    List<Habitat> habitats = new List<Habitat>();

                    foreach (Diet diet in item.Diets)
                    {
                        Diet dietsFromDB = _context.Diets.Find(diet.ID);

                        if (dietsFromDB != null)
                        {
                            diets.Add(dietsFromDB);
                        }
                        else
                        {
                            diets.Add(diet);
                        }
                    }
                    foreach (Habitat habitat in item.Habitats)
                    {
                        Habitat habitatsFromDB = _context.Habitats.Find(habitat.ID);

                        if (habitatsFromDB != null)
                        {
                            habitats.Add(habitatsFromDB);
                        }
                        else
                        {
                            habitats.Add(habitat);
                        }
                    }

                    SpeciesFromDB.Diets = diets;

                }

                _context.Entry(SpeciesFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
