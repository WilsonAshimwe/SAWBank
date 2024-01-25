using SAWBank.BLL.Interfaces;
using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.BLL.Services
{
    public class SecurityServices(ILoginRepository _loginRepository, IPasswordHasher _passwordHasher)
    {
        public Customer Login(string username, string password)
        {
            //Login? l = _loginRepository.Get(username);
            Customer? l = _loginRepository.Get(username);

            if (l == null) throw new ValidationException("Aucun user avec cet email");
            if (!_passwordHasher.Hash(l.Email + password).SequenceEqual(l.Password)) throw new ValidationException("pwd non valide");
            return l;
        }
    }
}
