using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FlyingAnimals
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
        public int Wings { get; set; }
        [Required]
        public int Lifespan { get; set; }

        private FlyingAnimals()
        { }
        public FlyingAnimals(string name, string type, string order, int wings, int lifespan)
        {
            Name = name;
            Type = type;
            Order = order;
            Wings = wings;
            Lifespan = lifespan;
        }
        
    }
}
