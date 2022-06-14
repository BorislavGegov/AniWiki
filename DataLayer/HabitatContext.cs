using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HabitatContext:IDB<Habitat,int>
    {
        private AnimalDbContext _context;

        public HabitatContext(AnimalDbContext context)
        {
            _context = context;
        }
        
            public void Create(Habitat item)
            {
                try
                {
                    _context.Habitats.Add(item);
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
                    _context.Habitats.Remove(Read(key));
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public Habitat Read(int key, bool noTracking = false, bool useNavigationProperties = false)
            {
                try
                {
                    IQueryable<Habitat> query = _context.Habitats;

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

            public IEnumerable<Habitat> Read(int skip, int take, bool useNavigationProperties = false)
            {
                try
                {
                    IQueryable<Habitat> query = _context.Habitats.AsNoTrackingWithIdentityResolution();

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

            public IEnumerable<Habitat> ReadAll(bool useNavigationProperties = false)
            {
                try
                {
                    IQueryable<Habitat> query = _context.Habitats.AsNoTracking();

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

            public void Update(Habitat item, bool useNavigationProperties = false)
            {
                try
                {
                    Habitat HabitatFromDB = Read(item.ID, useNavigationProperties);

                    if (useNavigationProperties)
                    {

                        List<Species> Species = new List<Species>();

                        foreach (Species specie in item.Species)
                        {
                            Species SpecieFromDB = _context.Species.Find(specie.ID);

                            if (SpecieFromDB != null)
                            {
                                Species.Add(SpecieFromDB);
                            }
                            else
                            {
                                Species.Add(specie);
                            }
                        }

                        HabitatFromDB.Species = Species;
                    }

                    _context.Entry(HabitatFromDB).CurrentValues.SetValues(item);
                    _context.SaveChanges();

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

