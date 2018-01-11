
using Framework.Utils;
using System;

namespace Framework.BO
{
    public class PostBuilder
    {
        public static Post GeneratePost(Account account)
        {
            return new Post($"Post {StringUtils.GetRandomString(15)}", $"This post is {StringUtils.GetRandomString(15)}", DateTime.Today.ToShortDateString(), account.Name, "");
        }
    }
}
