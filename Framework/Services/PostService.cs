using Framework.BO;
using Framework.Pages;

namespace Framework.Services
{
    public class PostService
    {
        public static void AddPost(Post post)
        {
            new EditPostPage().FillTitleInput(post.Header).FillContentInput(post.Body).ClickUpdateButton();
        }

        public static void DeletePost(Post post)
        {
            new PostsPage().ClickToTrash(post);
        }

        public static void EditPost(Post post)
        {
            new PostsPage().ClickToEdit(post);
        }

        public static bool IsPostDisplayed(Post post)
        {
            return new FeedPage().IsPostDisplayed(post.Id);
        }
    }
}
