using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Author> Author { get; set; }
    }
}
