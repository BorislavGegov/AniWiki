using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class WaterAnimals
    {
        [Key]
        public int ID { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Order { get; set; }
        [Required]
        public int Temperature { get; set; }
        [Required]
        public int Depth { get; set; }
        [Required]
        public string Habitat { get; set; }
        [Required]
        public int Lifespan { get; set; }
        private WaterAnimals()
        { }
        public WaterAnimals(string name, string type, string order, int temperature, int depth, string habitat, int lifespan)
        {
            Name = name;
            Type = type;
            Order = order;
            Temperature = temperature;
            Depth = depth;
            Habitat = habitat;
            Lifespan = lifespan;
        }

    }
}
