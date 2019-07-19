using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaUserControl.Domain.Models;

namespace SpaUserControl.Domain.Contracts.Repositories
{
    public interface IUserRepository:IDisposable
    {
        User Get(string email);
        User Get(Guid id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}
