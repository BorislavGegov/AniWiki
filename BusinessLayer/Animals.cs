using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Animals
    {
        [Key]
        public int ID { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public IEnumerable<Habitats> Habitat { get; set; }
        [Required]
        public IEnumerable<Diets> Diet { get; set; }
        [Required]
        public int Lifespan { get; set; }
        private Animals()
        { }

        public Animals(string name, string type, int lifespan)
        {
            Name = name;
            Type = type;
            Lifespan = lifespan;
        }
    }
}
