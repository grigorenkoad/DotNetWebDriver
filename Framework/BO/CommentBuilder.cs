using System;
using Framework.Utils;
namespace Framework.BO
{
    public class CommentBuilder
    {
        public static Comment GenerateComment()
        {
            return new Comment(string.Empty, $"I think this post is {StringUtils.GetRandomString(7)}", DateTime.Today.ToShortDateString());
        }
    }
}
