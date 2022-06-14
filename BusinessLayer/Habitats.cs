using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Habitats
    {
        [Key]
        public int ID { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Temperature { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public string Food { get; set; }
        [Required]
        public string Water { get; set; }
        [Required]
        public string Light { get; set; }
        [Required]
        public IEnumerable<Animals> Animal { get; set; }
        public Habitats()
        { }

        public Habitats(string name, int temperature, int area, string food, string water, string light)
        {
            Name = name;
            Temperature = temperature;
            Area = area;
            Food = food;
            Water = water;
            Light = light;
        }
    }
}
