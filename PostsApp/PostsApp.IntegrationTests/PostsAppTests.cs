namespace PostsApp.IntegrationTests;
using PostsApp.Services;
using NSubstitute;
public class PostsAppTests
{
    private readonly FakePostsService fakePostsService = new();
    private readonly IHttpClientFactory factory = Substitute.For<IHttpClientFactory>();
    private readonly IPostsService sut;
    public PostsAppTests()
    {
        fakePostsService.Start();
        fakePostsService.GetFakePosts();
        factory.CreateClient("PostsClient").Returns(new HttpClient
        {
            BaseAddress = new Uri(fakePostsService.Url),
        });
        sut = new PostsService(clientFactory: factory);
    }

    [Fact]
    public async Task GetPostsTest()
    {
        //Arrange
        //Act
        var results = await sut.Get();
        //Assert
        Assert.NotEmpty(results);
    }

    [Fact]
    public async Task GetPostsHasTestData()
    {
        //Arrange
        //Act
        var results = await sut.Get();
        //Assert
        Assert.Contains(results.First().Title, "sunt aut facere repellat provident occaecati excepturi optio reprehenderit");
    }
}
