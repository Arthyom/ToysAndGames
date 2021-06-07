using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToysAndGames;
using Xunit;

namespace Test_ToysAndGames
{
    public class Product_Should
    {
        private readonly WebApplicationFactory<Startup> app_builder;
        private readonly string url_gobal = "https://localhost:44352/api/Products";

        public Product_Should(
        )
        {
            app_builder = new WebApplicationFactory<Startup>();
        }


        [Fact]
        public async Task get_all()
        {
            //arrange
            var cliente = app_builder.CreateDefaultClient();

            //act
            var list = await cliente.GetAsync(url_gobal);

            //assert
            Assert.NotNull(list);


        }

        [Fact]
        public async Task get_by_id()
        {
            //arrange
            int id = 9;
            string by_id_url = $"{url_gobal}/{id}";
            var cliente = app_builder.CreateDefaultClient();

            //act
            var result = await cliente.GetAsync(by_id_url);
            var response = result.Content.ReadAsStringAsync().Result;
            


            //assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task get_by_id_error()
        {
            //arrange
            int id = 9;
            string by_id_url = $"{url_gobal}/{id}";
            var cliente = app_builder.CreateDefaultClient();
            var deleted = await cliente.DeleteAsync(by_id_url);

            //act
            var result = await cliente.GetAsync(by_id_url);
            var response = result.Content.ReadAsStringAsync().Result;



            //assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task get_search_by()
        {
            //arrange
            string by = "lo que sea";
            string by_id_url = $"{url_gobal}/search/{by}";
            var cliente = app_builder.CreateDefaultClient();

            //act
            var result = await cliente.GetAsync(by_id_url);
            var response = result.Content.ReadAsStringAsync().Result;

            //assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task get_search_by_all()
        {
            //arrange
            string by = "*";
            string by_id_url = $"{url_gobal}/search/{by}";
            var cliente = app_builder.CreateDefaultClient();

            //act
            var result = await cliente.GetAsync(by_id_url);
            var response = result.Content.ReadAsStringAsync().Result;

            //assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task delete_by_id()
        {
            //arrange
            int id = 9;
            string by_id_url = $"{url_gobal}/{id}";
            var cliente = app_builder.CreateDefaultClient();

            //act
            var result = await cliente.DeleteAsync(by_id_url);
            var response = result.Content.ReadAsStringAsync().Result;

            //assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task delete_by_id_error()
        {
            //arrange
            int id = 9;
            string by_id_url = $"{url_gobal}/{id}";
            var cliente = app_builder.CreateDefaultClient();
            var deleted = await cliente.DeleteAsync(by_id_url);


            //act
            var result = await cliente.DeleteAsync(by_id_url);
            var response = result.Content.ReadAsStringAsync().Result;

            //assert
            Assert.NotNull(response);
        }




    }
}
