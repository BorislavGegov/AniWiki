﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Diets
    {
        [Key]
        public int ID { get; private set; }
        [Required]
        public string Order { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        public string Complexity { get; set; }
        [Required]
        public IEnumerable<Animals> Animal { get; set; }
        public Diets()
        { }

        public Diets(string order, int volume, string complexity)
        {
            Order = order;
            Volume = volume;
            Complexity = complexity;
        }
    }
}
