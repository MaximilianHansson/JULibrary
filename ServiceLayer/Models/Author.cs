using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class Author
    {
        public int Aid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthYear { get; set; }

        public virtual List<Book> Book { get; set; }
    }
}
