using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DietContext : IDB<Diet, int>
    {
        private AnimalDbContext _context;

        public DietContext(AnimalDbContext context)
        {
            _context = context;
        }
        public void Create(Diet item)
        {
            try
            {
                _context.Diets.Add(item);
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
                    _context.Diets.Remove(Read(key));
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public Diet Read(int key, bool noTracking = false, bool useNavigationProperties = false)
            {
                try
                {
                    IQueryable<Diet> query = _context.Diets;

                    if (noTracking)
                    {
                        query = query.AsNoTrackingWithIdentityResolution();
                    }

                    if (useNavigationProperties)
                    {
                        query = query.Include(i => i.Species);
                    }

                    return query.SingleOrDefault(i => i.ID == key);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public IEnumerable<Diet> Read(int skip, int take, bool useNavigationProperties = false)
            {
                try
                {
                    IQueryable<Diet> query = _context.Diets.AsNoTrackingWithIdentityResolution();

                    if (useNavigationProperties)
                    {
                        query = query.Include(i => i.Species);
                    }

                    return query.Skip(skip).Take(take).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public IEnumerable<Diet> ReadAll(bool useNavigationProperties = false)
            {
                try
                {
                    IQueryable<Diet> query = _context.Diets.AsNoTracking();

                    if (useNavigationProperties)
                    {
                        query = query.Include(i => i.Species);
                    }

                    return query.ToList();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Update(Diet item, bool useNavigationProperties = false)
            {
                try
                {
                    Diet DietFromDB = Read(item.ID, useNavigationProperties);

                    if (useNavigationProperties)
                    {

                        List<Species> species = new List<Species>();

                        foreach (Species specie in item.Species)
                        {
                            Species speciesFromDB = _context.Species.Find(specie.ID);

                            if (speciesFromDB != null)
                            {
                                species.Add(speciesFromDB);
                            }
                            else
                            {
                                species.Add(specie);
                            }
                        }

                        DietFromDB.Species = species;
                    }

                    _context.Entry(DietFromDB).CurrentValues.SetValues(item);
                    _context.SaveChanges();

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

