using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class Administrator
    {
        public string username { get; set; }

        public string passwordHash { get; set; }

        public string salt { get; set; }

    }
}
