using System;
using ClassLibrary;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Authenticator auth = Authenticator.Instance;

        auth.RegisterUser("User1");
        auth.RegisterUser("User2");
        auth.ShowRegisteredUsers();
        auth.Authenticate("User1");
        auth.Logout();
        auth.Authenticate("User3");

        Thread thread1 = new Thread(() =>
        {
            Authenticator auth1 = Authenticator.Instance;
            auth1.Authenticate("User2");
        });
        Thread thread2 = new Thread(() =>
        {
            Authenticator auth2 = Authenticator.Instance;
            auth2.Authenticate("User1");
        });
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();

        Authenticator auth2 = Authenticator.Instance;
        Console.WriteLine(ReferenceEquals(auth, auth2) ? "--> Однакові <--" : "--> Різні <--");
    }
}