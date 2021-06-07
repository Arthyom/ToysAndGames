using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.AppContext;
using ToysAndGames.DTOs;
using ToysAndGames.InMeMoryRepo;
using ToysAndGames.Models;
using ToysAndGames.Utilities;

namespace ToysAndGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Products : ControllerBase
    {
        private readonly In_Memory_Repo<Product> in_Memory_Repo;
        private readonly ImageLoader imageLoader;
        private readonly IMapper maper;

        public Products(
            In_Memory_Repo<Product> in_memory_repo,
            ImageLoader imageLoader,
            IMapper maper
            )
        {
            in_Memory_Repo = in_memory_repo;
            this.imageLoader = imageLoader;
            this.maper = maper;
        }

        [HttpGet]
        public ActionResult<List<DTOProduct>> get()
        {
            var products = in_Memory_Repo.Query;
            var DTOProducts = this.maper.Map<List<DTOProduct>>(products);
            return DTOProducts;
        }

        [HttpPut]
        public async Task<ActionResult> put([FromForm] DTOCProduct DtoNewProd)
        {
            var new_product = this.maper.Map<DTOCProduct, Product>(DtoNewProd);

            if (DtoNewProd.imagen != null)
                new_product.ruta_imagen = await imageLoader.guardar("productos", DtoNewProd.imagen);

            bool ok = await in_Memory_Repo.Add(new_product);

            if (ok)
                return Ok(new { ok = true });

            return BadRequest();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> patch([FromRoute] int id, [FromForm] DTOCProduct edited_prod)
        {
            var found = await in_Memory_Repo.Get_ById(id);
            if (found != null)
            {
                var edited = maper.Map<DTOCProduct, Product>(edited_prod);

                found.AgeRestriction = edited.AgeRestriction;
                found.Company = edited.Company;
                found.Description = edited.Description;
                found.Name = edited.Name;
                found.Price = edited.Price;

                if (edited_prod.imagen != null)
                    found.ruta_imagen = await imageLoader.guardar("productos", edited_prod.imagen);

                await in_Memory_Repo.Update(found);

                return Ok(new { Ok = true });
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete([FromRoute] int id)
        {
            var found = await in_Memory_Repo.Get_ById(id);
            if (found != null)
            {
                await in_Memory_Repo.Delete(found);
                // await Task.Delay(7000);
                return Ok(new { Ok = true });
            }
            return BadRequest();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DTOProduct>> get_by([FromRoute] int id)
        {
            var found = await in_Memory_Repo.Get_ById(id);
            if (found != null)
            {
                var found_DTO = this.maper.Map<DTOProduct>(found);
                return found_DTO;
            }

            return BadRequest();
        }

        [HttpGet("search/{data}")]
        public async Task<ActionResult<List<DTOProduct>>> get_search([FromRoute] string data)
        {
            List<DTOProduct> lista_salida;
            List<Product> list;
            if (data != "*")
                list = await in_Memory_Repo.Serach_match(data);

            else
                list = in_Memory_Repo.Query;

            lista_salida = maper.Map<List<DTOProduct>>(list);
           
            return lista_salida;
        }
    }
}
