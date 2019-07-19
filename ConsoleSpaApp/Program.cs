using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using SpaUserControl.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSpaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("Leonardo", "davinc10831@hotmail.com");

            user.SetPassword("u3r5v8k9cw", "u3r5v8k9cw");
            user.Validate();

            using (IUserRepository userRep = new UserRepository())
            {
                userRep.Create(user);
            }

            using (IUserRepository userRep = new UserRepository())
            {
                var e = userRep.Get("davinc10831@hotmail.com");
                Console.WriteLine(e.Email);
                Console.WriteLine(e.Password);
                Console.ReadKey();
            }
        }
    }
}
