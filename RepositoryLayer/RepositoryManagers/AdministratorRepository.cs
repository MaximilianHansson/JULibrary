using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace RepositoryLayer.RepositoryManagers
{
    public class AdministratorRepository
    {
        public AdministratorRepository() { }

        public void CreateNew(ADMINISTARTOR newAdmin)
        {
            using (var db = new LibDB())
            {
                db.ADMINISTARTOR.Add(newAdmin);
                db.SaveChanges();
            }
        }

        public ADMINISTARTOR Read(string username)
        {
            using(var db = new LibDB())
            {
                return db.ADMINISTARTOR.FirstOrDefault(a => a.username.Equals(username));
            }
        }

		public List<ADMINISTARTOR> List()
		{
			using (var db = new LibDB())
			{
				// May need to use an include
				return db.ADMINISTARTOR.ToList();
			}

		}
    }
}
