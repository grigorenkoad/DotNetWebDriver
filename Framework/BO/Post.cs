using System;

namespace Framework.BO
{
    public class Post
    {

        public string Header { get; set; }
        public string Body { get; set; }
        public string PostDate { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }

        public Post(string header, string body, string date, string username, string id)
        {
            Header = header;
            Body = body;
            PostDate = date;
            UserName = username;
            Id = id;
        }
    }
}