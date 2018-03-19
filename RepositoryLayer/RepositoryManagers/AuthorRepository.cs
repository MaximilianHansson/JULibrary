using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryLayer.RepositoryManagers
{
    class AuthorRepository
    {
        public AUTHOR Read(int Aid)
        {
            using (var db = new LibDB())
            {
                return db.AUTHOR.FirstOrDefault(x => x.Aid.Equals(Aid));
            }
        }

    }
}
