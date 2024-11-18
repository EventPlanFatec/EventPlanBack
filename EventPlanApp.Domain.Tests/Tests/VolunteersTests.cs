//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace EventPlanApp.Tests.Domain.Entities
//{
//    public class VolunteersTests : IClassFixture<WebApplicationFactory<Program>>  // Substitua Program pela sua classe de inicialização, se necessário
//    {
//        private readonly HttpClient _client;
//        private readonly TestServer _server;

//        public VolunteersTests(WebApplicationFactory<Program> factory)
//        {
//            _server = new TestServer(new WebHostBuilder()
//                .UseStartup<Program>());  // Configure o projeto para o seu Startup.cs
//            _client = _server.CreateClient();
//        }

//        [Fact]
//        public async Task AdicionarVoluntario_RetornaSucesso()
//        {
//            // Arrange
//            var newVolunteer = new { name = "John Doe", tasks = "Limpeza" };
//            var content = new StringContent(JsonConvert.SerializeObject(newVolunteer), Encoding.UTF8, "application/json");

//            // Act
//            var response = await _client.PostAsync("/api/volunteers", content);

//            // Assert
//            response.EnsureSuccessStatusCode();  // Verifica se o status é 200-299
//            var responseString = await response.Content.ReadAsStringAsync();
//            Assert.Contains("Voluntário adicionado com sucesso", responseString);
//        }

//        [Fact]
//        public async Task AtualizarVoluntario_RetornaSucesso()
//        {
//            // Arrange
//            var updatedVolunteer = new { name = "John Doe", tasks = "Limpeza, Organização" };
//            var content = new StringContent(JsonConvert.SerializeObject(updatedVolunteer), Encoding.UTF8, "application/json");

//            // Act
//            var response = await _client.PutAsync("/api/volunteers/1", content);

//            // Assert
//            response.EnsureSuccessStatusCode();  // Verifica se o status é 200-299
//            var responseString = await response.Content.ReadAsStringAsync();
//            Assert.Contains("Voluntário atualizado com sucesso", responseString);
//        }

//        [Fact]
//        public async Task RemoverVoluntario_RetornaSucesso()
//        {
//            // Arrange
//            var volunteerId = 1;

//            // Act
//            var response = await _client.DeleteAsync($"/api/volunteers/{volunteerId}");

//            // Assert
//            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);  // Espera um status 204
//        }


//    }
//}
