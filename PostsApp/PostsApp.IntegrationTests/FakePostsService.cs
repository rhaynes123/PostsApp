using System;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace PostsApp.IntegrationTests
{
    public class FakePostsService : IDisposable
	{
		private WireMockServer _mockServer;
        public string Url => _mockServer.Url!;
		

        public void Start()
        {
            _mockServer = WireMockServer.Start();
        }
        public void GetFakePosts()
        {
            _mockServer.Given(Request.Create()
                .WithPath("/posts")
                .UsingGet())
                .RespondWith(Response.Create().WithBody("""
                    [
                        {
                          "userId": 1,
                          "id": 1,
                          "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                          "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
                        }
                    ]
                    """));
        }
        public void Dispose()
        {
            _mockServer.Stop();
            _mockServer.Dispose();
        }
    }
}

