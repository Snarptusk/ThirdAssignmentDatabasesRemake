using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Adress
    {
        public int AdressID { get; set; }
        public string Home { get; set; }
        public string Work { get; set; }
        public string Other { get; set; }
        public string City { get; set; }
        public virtual Person person { get; set; }
    }
}
