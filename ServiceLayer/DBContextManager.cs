using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class DBContextManager
    {
        private static AnimalDbContext _context;
        private static SpeciesContext _speciesContext;
        private static HabitatContext _habitatContext;
        private static DietContext _dietContext;

        #region DB context
        public static void SetChangeTracking(bool value)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = value;
        }

        public static AnimalDbContext CreateContext()
        {
            _context = new AnimalDbContext();
            return _context;
        }

        public static AnimalDbContext GetContext()
        {
            return _context;
        }
        public static SpeciesContext CreateSpeciesContext(AnimalDbContext context)
        {
            _speciesContext = new SpeciesContext(context);
            return _speciesContext;
        }

        public static SpeciesContext GetSpeciesContext()
        {
            return _speciesContext;
        }

        public static HabitatContext CreateHabitatContext(AnimalDbContext context)
        {
            _habitatContext = new HabitatContext(context);
            return _habitatContext;
        }

        public static HabitatContext GetHabitatContext()
        {
            return _habitatContext;
        }
        public static DietContext CreateDietContext(AnimalDbContext context)
        {
            _dietContext = new DietContext(context);
            return (_dietContext);
        }
        public static DietContext GetDietContext()
        {
            return _dietContext;
        }

        #endregion
    }
}
