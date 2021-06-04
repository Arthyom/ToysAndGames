using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysAndGames.DTOs
{
    public class DTOCProduct
    {
     

        [Required, MaxLength(50)]
        public string name { get; set; }

        [MaxLength(100)]
        public string description { get; set; }

        [Range(0,100)]
        public int ageRestriction { get; set; }

        [Required, MaxLength(50)]
        public string company { get; set; }

        [Required, Range(1, 1000)]
        public decimal price { get; set; }

        public IFormFile imagen { get; set; }
    }
}
