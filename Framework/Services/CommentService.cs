using Framework.Pages;
using Framework.BO;
using Framework.Utils;

namespace Framework.Services
{
    public class CommentService
    {
        public static Comment AddComment(Comment comment)
        {
            if (new CommentsPage().IsUserLogged())
            {
                new CommentsPage().InputCommentText(comment.Text).ClickOnSubmit();
                return comment;
            }
            else
            {
                new CommentsPage().InputUserName(comment.Text).InputUserEmail(comment.Text).InputUserUrl(comment.Text).InputCommentText(comment.Text).ClickOnSubmit();
                return comment;
            }
        }

        public static void DeleteComment(Comment comment)
        {
            new CommentsPage().ClickTrash(comment.Text);
        }

        public static void EditComment(Comment comment)
        {
            new CommentsPage().ClickEdit(comment.Text);
        }

        public static bool IsCommentDisplayed(Comment comment)
        {
            return new CommentsPage().IsCommentDisplayed(comment.Text);
        }
    }
}
