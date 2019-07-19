using System;
using SpaUserControl.Domain.Models;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Infraestructure.Repositories;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("Leonardo", "davinc131@hotmail.com");

            user.SetPassword("u3r5v8k9cw", "u3r5v8k9cw");
            user.Validate();

            using (IUserRepository userRep = new UserRepository())
            {
                userRep.Create(user);
            }

            using(IUserRepository userRep = new UserRepository())
            {
                var e = userRep.Get("davinc131@hotmail.com");
                Console.WriteLine(e.Email);
                Console.WriteLine(e.Password);
            }
        }
    }
}
