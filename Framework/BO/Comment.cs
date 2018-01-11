using System;
namespace Framework.BO
{
    public class Comment
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }

        public Comment(string author, string text, string date)
        {
            Author = author;
            Text = text;
            Date = date;
        }
    }
}
