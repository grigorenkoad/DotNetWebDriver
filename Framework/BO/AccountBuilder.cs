using System;
using Framework.Utils;

namespace Framework.BO
{
    public class AccountBuilder
    {
        public static Account CreateAccount()
        {
            return new Account($"User_{StringUtils.GetRandomString(5)}", String.Empty, StringUtils.GetRandomString(9));
        }
    }
}
