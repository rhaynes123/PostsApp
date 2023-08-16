using System;
using System.Text.Json;
using PostsApp.Models;

namespace PostsApp.Services
{
	public class PostsService: IPostsService
	{
        private readonly HttpClient _httpClient;
        public PostsService(IHttpClientFactory clientFactory)
		{
            _httpClient = clientFactory.CreateClient("PostsClient");
		}
        
        public async Task<List<Post>> Get()
        {
            var response = await _httpClient.GetAsync("/posts");

            if (!response.IsSuccessStatusCode)
            {
                return new List<Post>();
            }
            
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<Post>>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true
            });

            return result;
            
        }
    }
}

