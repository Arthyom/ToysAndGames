using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Models;

namespace ToysAndGames.AppContext
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public void LoadData()
        {
            this.Products.AddRange(

                  new Product()
                  {
                      Id = 1,
                      AgeRestriction = 9,
                      Company = "Wfls INC",
                      Description = "no one",
                      Name = "Monos Varios",
                      Price = 43,
                      ruta_imagen = "ee133880-957c-4b3d-8a38-5afd93ccae7e.jpg",

                  },

                    new Product()
                    {
                        Id = 2,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Balero of Palo",
                        Price = 54,
                        ruta_imagen = "db8a923e-c129-415c-b677-1a04ed6bc67b.jpg"
                    }, new Product()
                    {
                        Id = 3,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Luchadores Of plastico",
                        Price = 40,
                        ruta_imagen = "608a81b4-4770-41d6-bf3d-98be951e1d1d.jpg"

                    },

                    new Product
                    {
                        Id = 12,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Alacranes of Broma",
                        Price = 38
                    },

                    new Product()
                    {
                        Id = 4,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Barbis Variadas",
                        Price = 50,
                        ruta_imagen = "2b73a281-d201-4ad9-b105-bcf6cd96edb7.jpg"
                    },

                    new Product()
                    {
                        Id = 5,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Pelotas Of colors",
                        Price = 234,
                        ruta_imagen = "628c6b2c-472c-4d86-b929-6e987876c964.jpg"

                    }, new Product()
                    {
                        Id = 6,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Peluches variados",
                        Price = 14,
                        ruta_imagen = "262f0940-c934-4ea7-be1c-0eb61bb1a7f7.jpg"

                    }, new Product()
                    {
                        Id = 7,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Dinosaurios Ocicones",
                        Price = 84,
                        ruta_imagen = "f7a96aa2-fbfe-4a22-937e-f2a74038fc2b.jpg"

                    },

                    new Product
                    {
                        Id = 13,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Carritos of Plastico",
                        Price = 65
                    },

                    new Product
                    {
                        Id = 14,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Chicles de Broma",
                        Price = 380
                    },

                    new Product
                    {
                        Id = 15,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Figura Accion Chavo del 8",
                        Price = 560,
                        ruta_imagen = "342dd441-20bc-42ed-b458-1b4c115316db.jpg"
                    },

                    new Product()
                    {
                        Id = 11,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Monas Chinas Estander",
                        Price = 43,
                        ruta_imagen = "d0b5d537-9661-48bb-9611-66477a55d065.jpg",

                    },

                    new Product()
                    {
                        Id = 8,
                        AgeRestriction = 9,
                        Company = "Wfls INC",
                        Description = "no one",
                        Name = "Canicas Varias",
                        Price = 94,
                        ruta_imagen = "0b2273bd-d079-47c8-90b0-cd5efc44ac12.jpg"

                    }


            );
        }



    }
}
