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
    }
}
