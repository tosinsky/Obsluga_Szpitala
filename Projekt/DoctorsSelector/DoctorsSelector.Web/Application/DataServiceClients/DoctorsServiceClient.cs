namespace DoctorsSelector.Web.Application.DataServiceClients
{
    using DoctorsSelector.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Text.Json;

    public class DoctorsServiceClient : IDoctorsServiceClient
    {
        public IHttpClientFactory clientFactory;
        public DoctorsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://localhost:44391/examination-rooms");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<DoctorDto>>(responseStream, options);
        }
    }
}
