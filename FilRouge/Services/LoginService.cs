using FilRouge.Interfaces;
using FilRouge.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Services
{
    public class LoginService
    {
        private IRepository<User> _userRepository;

        private IHttpContextAccessor _accessor;

        public LoginService(IRepository<User> userRepository, IHttpContextAccessor accessor)
        {
            _userRepository = userRepository;
            _accessor = accessor;
        }

        public bool Login(string userName, string password)
        {
            User u = _userRepository.SearchOne(u => u.UserName == userName && u.Password == password);
            if (u != null)
            {
                _accessor.HttpContext.Session.SetString("isLogged", "true");
                return true;
            }
            return false;
        }

        public bool IsLogged()
        {
            if (bool.TryParse(_accessor.HttpContext.Session.GetString("isLogged"), out bool isLogged))
            {
                if (isLogged)
                {
                    return true;
                }
            }
            return false;
        }

        public string GenerateToken(string userName, string password)
        {
            //Verification dans la base de données de l'email et mot de passe
            User u = _userRepository.SearchOne(u => u.UserName == userName && u.Password == password);
            if (u != null)
            {
                //données à stocker dans le token
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, u.UserName),
                    new Claim(ClaimTypes.Role, "connected"),
                };

                //Objet pour signer le token
                SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bonjour je suis la clé de cryptage")), SecurityAlgorithms.HmacSha256);


                //Créer notre jwt
                JwtSecurityToken jwt = new JwtSecurityToken(issuer: "m2i", audience: "m2i", claims: claims, signingCredentials: signingCredentials, expires: DateTime.Now.AddDays(2));
                return new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            return null;
        }
    }
}
