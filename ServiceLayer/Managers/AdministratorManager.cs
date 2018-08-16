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

        public Administrator login(string username, string password)
        {
            AdministratorRepository adminReposObj = new AdministratorRepository();

            var dbAdmin = adminReposObj.Read(username);
            var passwordHash = "";

			//if user doesen't exist
			if(dbAdmin == null)
			{
				return null;
			}

			//check if username matches with password
            using (Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, Convert.FromBase64String(dbAdmin.salt)))
            {
                passwordHash = Convert.ToBase64String(deriveBytes.GetBytes(20));
                if(passwordHash == dbAdmin.passwordHash)
                {
                    return Mapper.Map<Administrator>(dbAdmin);
                }
                else
                {
                    return null;
                }
            }

        }

		public List<Administrator> getAllAdmins()
		{
			AdministratorRepository adminManagerObj = new AdministratorRepository();
			return Mapper.Map<List<Administrator>>(adminManagerObj.List());
		}

	}
}
