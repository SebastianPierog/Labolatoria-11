using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Controls;

namespace Z11_UCR
{
    public  class User
    {
        public User (string login, string password)
        {
            Login = login;
            Password = password;
        }
        public string Login { get; private set; }
        private string Password { get; set; }

        public bool CheckLogin(string login, SecureString password)
        {
            var pwd = default(string);
            IntPtr unmangedString = IntPtr.Zero; ;
            try
            {
                unmangedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                pwd = Marshal.PtrToStringUni(unmangedString);
            }
            finally 
            {

                Marshal.ZeroFreeGlobalAllocUnicode(unmangedString);
            }
            return (Login == login && Password == pwd);
        }
    }
}