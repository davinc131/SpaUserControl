using SpaUserControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Gerencia os serviços referentes a classe de usuário. Todos os serviços como verificação, autenticação etc. 
/// </summary>
namespace SpaUserControl.Domain.Contracts.Services
{
    public interface IUserService: IDisposable
    {
        User Authenticate(string email, string password);
        User GetByEmail(string email);
        void Register(string name, string email, string password, string confirmPassword);
        void ChangeInformation(string email, string name);
        void ChangePassword(string email, string password, string newPassword, string confirmNewPassword);
        string ResetPassword(string email);
        List<User> GetByRange(int skip, int take);
    }
}
