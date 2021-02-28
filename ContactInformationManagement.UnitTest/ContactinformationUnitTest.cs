using ContactInformationManagement.Common.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ContactInformationManagement.UnitTest
{
    
    public class ContactinformationUnitTest
    {
        private readonly HttpClient _client;
        public ContactinformationUnitTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _client = server.CreateClient();

        }
        [Fact]
        public async Task GetAllContactDetails()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/contact");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddContactDetails()
        {
            var requestBody = new
            {
                FirstName = "Smit",
                LastName = "Machchhar",
                Email = "abc@gmail.com",
                PhoneNumber = 9876543210,
                Status = "Active"
            };

            // Act
            var response = await _client.PostAsync("/api/contact", ContentHelper.GetStringContent(requestBody));
            var value = await response.Content.ReadAsStringAsync();

            ResponseModel responseModel = JsonConvert.DeserializeObject<ResponseModel>(value);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(responseModel);
            Assert.NotNull(responseModel.ContactId);
            Assert.NotEqual(0, responseModel.ContactId);
        }

        [Fact]
        public async Task UpdateContactDetails()
        {
            var requestBody = new
            {
                ContactId = 1,
                FirstName = "Smit",
                LastName = "Machchhar",
                Email = "abc@gmail.com",
                PhoneNumber = 919876543210,
                Status = "InActive"
            };

            // Act
            var response = await _client.PutAsync("/api/contact/Update/1", ContentHelper.GetStringContent(requestBody));
            var value = await response.Content.ReadAsStringAsync();

            AssertResponseMessage(response, value);
        }

        [Fact]
        public async Task GetContactDetailById()
        {
            // Act
            var response = await _client.GetAsync("/api/contact/1");

            var value = await response.Content.ReadAsStringAsync();

            ContactDetailDTO contactDetailDTO = JsonConvert.DeserializeObject<ContactDetailDTO>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(contactDetailDTO);
            Assert.Equal(1, contactDetailDTO.ContactDetailId);
            Assert.Equal("Smit", contactDetailDTO.FirstName);
        }

        [Fact]
        public async Task DeleteContactDetailById()
        {
            // Act
            var response = await _client.DeleteAsync("/api/contact/1");

            var value = await response.Content.ReadAsStringAsync();

            AssertResponseMessage(response, value);
        }

        private void AssertResponseMessage(HttpResponseMessage response, string value)
        {
            ResponseModel responseModel = JsonConvert.DeserializeObject<ResponseModel>(value);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(responseModel);
            Assert.NotNull(responseModel.Message);
        }
    }
}
