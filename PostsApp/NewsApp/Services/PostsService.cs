using System;
using System.Text.Json;
using PostsApp.Models;

namespace PostsApp.Services
{
	public class PostsService: IPostsService
	{
        private const string _dataUrl = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _httpClient;
        public PostsService()
		{
            _httpClient = new HttpClient();
		}
        
        public async Task<List<Post>> Get()
        {
            var response = await _httpClient.GetAsync(_dataUrl);

            if(response.StatusCode == System.Net.HttpStatusCode.NotModified)
            {

            }
            else if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<List<Post>>(json, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                return result;
            }

            return new List<Post>();
        }
    }
}

