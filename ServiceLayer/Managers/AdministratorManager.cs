using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServiceLayer.Models;
using RepositoryLayer.RepositoryManagers;
using RepositoryLayer;
using System.Security.Cryptography;


namespace ServiceLayer.Managers
{
    public class AdministratorManager
    {
        public AdministratorManager() { }

        public void createAdministrator(string username, string password)
        {

            AdministratorRepository adminReposObj = new AdministratorRepository();
            Administrator newAdmin = new Administrator();

            newAdmin.username = username;

            using (Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, 20))
            {
                newAdmin.passwordHash = Convert.ToBase64String(deriveBytes.GetBytes(20));
                newAdmin.salt = Convert.ToBase64String(deriveBytes.Salt);
            }
            
            adminReposObj.CreateNew(Mapper.Map<ADMINISTARTOR>(newAdmin));
            
        }
    }
}
