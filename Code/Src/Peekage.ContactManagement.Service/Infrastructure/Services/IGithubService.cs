using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Infrastructure.Services
{
    public interface IGithubService
    {
        Task<List<string>> GetAllRepositoryNamesByAccount(string account);
    }

    public class GithubService : IGithubService
    {
        static readonly HttpClient _client = new HttpClient();
        static readonly string _baseUrl = "https://api.github.com";
        ILogger<GithubService> _logger;

        public GithubService(ILogger<GithubService> logger)
        {
            _logger = logger;
        }

        public async Task<List<string>> GetAllRepositoryNamesByAccount(string account)
        {
            try
            {
                //TODO: check if account does not exist!

                var response = await _client.GetAsync($"{_baseUrl}/users/{account}/repos");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GithubResponse>>(responseBody);
                return items.Select(a => a.Name).ToList();
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        class GithubResponse
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public bool Private { get; set; }
        }
    }
}
