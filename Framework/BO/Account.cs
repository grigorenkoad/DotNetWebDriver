namespace Framework.BO
{
    public class Account
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Account(string name, string email, string pass)
        {
            Name = name;
            Email = email;
            Password = pass;
        }
    }
}
