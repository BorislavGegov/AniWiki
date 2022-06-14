using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Species
    {
        [Key]
        public int ID { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public IEnumerable<Habitat> Habitats { get; set; }
        [Required]
        public IEnumerable<Diet> Diets { get; set; }
        [Required]
        public int Lifespan { get; set; }
        private Species()
        { }

        public Species(string name, string type, int lifespan)
        {
            Name = name;
            Type = type;
            Lifespan = lifespan;
        }
    }
}
