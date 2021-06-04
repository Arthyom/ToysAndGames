using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysAndGames.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(100)]
        public int AgeRestriction { get; set; }
        
        [Required, MaxLength(50)]
        public string Company { get; set; }

        [Required, Range(1,1000)]
        public decimal Price { get; set; }

        public string ruta_imagen { get; set; }

    }
}
