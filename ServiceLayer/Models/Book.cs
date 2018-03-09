using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class Book
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public int? SignId { get; set; }

        public string PublicationYear { get; set; }

        public string publicationinfo { get; set; }

        public short? pages { get; set; }
    }
}
