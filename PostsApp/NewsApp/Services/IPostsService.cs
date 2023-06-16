namespace PostsApp.Services
{
	public interface IPostsService
	{
		Task<List<Post>> Get();
	}
}

