using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames;
using Xunit;

namespace Test_ToysAndGames
{
    class Images_Should
    {
        private readonly WebApplicationFactory<Startup> app_builder;
        private readonly string url_gobal = "https://localhost:44352/api/Images";

        public Images_Should()
        {
            app_builder = new WebApplicationFactory<Startup>();
        }

        public async Task get_image_by_name()
        {
            //arrange
            string name = "";
            string image_name_url = $"{url_gobal}/{name}";
            var cliente = app_builder.CreateDefaultClient();

            //act
            var content = await cliente.GetAsync(image_name_url).Result.Content.ReadAsStringAsync();

            //asserts
            Assert.NotNull(content);

        }

        public async Task get_image_by_error()
        {
            //arrange
            string name = "";
            string image_name_url = $"{url_gobal}/{name}";
            var cliente = app_builder.CreateDefaultClient();

            //act
            var content = await cliente.GetAsync(image_name_url).Result.Content.ReadAsStringAsync();

            //asserts
            Assert.NotNull(content);

        }

    }
}
