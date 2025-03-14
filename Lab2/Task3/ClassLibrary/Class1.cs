using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Authenticator
    {
        private static readonly Lazy<Authenticator> instance = new Lazy<Authenticator>(() => new Authenticator());
        private readonly HashSet<string> users = new HashSet<string>();
        private string authenticatedUser;
        private Authenticator()
        {
            Console.WriteLine("Аутентифікатор створено");
        }
        public static Authenticator Instance => instance.Value;
        public bool RegisterUser(string username)
        {
            if (users.Add(username))
            {
                Console.WriteLine($"Користувач {username} зареєстрований.");
                return true;
            }
            Console.WriteLine($"Користувач {username} вже існує.");
            return false;
        }
        public bool Authenticate(string username)
        {
            if (users.Contains(username))
            {
                authenticatedUser = username;
                Console.WriteLine($"Користувач {username} аутентифікований.");
                return true;
            }
            Console.WriteLine($"Помилка: користувача {username} не знайдено.");
            return false;
        }
        public void ShowRegisteredUsers()
        {
            Console.WriteLine("Зареєстровані користувачі:");
            foreach (var user in users)
                Console.WriteLine(" - " + user);
        }
        public void Logout()
        {
            if (authenticatedUser != null)
            {
                Console.WriteLine($"Користувач {authenticatedUser} вийшов з системи.");
                authenticatedUser = null;
            }
            else
            {
                Console.WriteLine("Немає активного користувача.");
            }
        }
    }
}