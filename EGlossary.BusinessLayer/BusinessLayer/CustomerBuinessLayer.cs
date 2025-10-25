using EGlossary.BusinessLayer.IBusinessLayer;
using EGlossary.BusinessLayer.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EGlossary.BusinessLayer.BusinessLayer
{
    public class CustomerBuinessLayer : ICustomerBuinessLayer
    {
        public IConfiguration _configuration;
        private string apiUrl;

        public CustomerBuinessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
            apiUrl = _configuration.GetSection("APIUrl").Value;
        }

        public async Task<List<CategoryViewModel>> GetLandingDetails()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    string url = $"{apiUrl}/api/v1/Category/GetCategories";
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data);

                        return result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Internal Server error");
            }
        }

        public async Task<object> GetCustomers()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string url = $"{apiUrl}/api/v1/Customer/GetCustomers";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<CustomerViewModel>>(data);

                    return result;
                }
                return null;
            }
        }
    }
}