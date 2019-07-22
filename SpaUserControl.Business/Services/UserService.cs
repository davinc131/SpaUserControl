using SpaUserControl.Common.Validation;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Domain.Models;
using SpaUserControl.Common.Resources;
using SpaUserControl.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaUserControl.Infraestructure.Repositories;

namespace SpaUserControl.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService()
        {
            _repository = new UserRepository();
        }
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public User Authenticate(string email, string password)
        {
            var user = GetByEmail(email);

            if (user.Password != PasswordAssertionConcern.Encrypt(password))
                throw new Exception(Errors.InvalidPassword);

            return user;
        }

        public void ChangeInformation(string email, string name)
        {
            var user = GetByEmail(email);

            user.ChangeName(name);
            user.Validate();

            _repository.Update(user);
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            var user = Authenticate(email, password);

            user.SetPassword(newPassword, confirmNewPassword);
            user.Validate();

            _repository.Update(user);
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
            var user = _repository.Get(email);
            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }

        public List<User> GetByRange(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            //Verifica se o email já foi cadastrado
            var hasUser = _repository.Get(email);
            if (hasUser != null)
                throw new Exception(Errors.DuplicateEmail); //Mensagem que indica que o usuário já existe no banco

            var user = new User(name, email);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            _repository.Create(user);
        }

        public string ResetPassword(string email)
        {
            var user = GetByEmail(email);
            var password = user.ResetPassword();
            user.Validate();

            _repository.Update(user);
            return password;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
