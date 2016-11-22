using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual List<Adress> PersonAdress { get; set; }
        public virtual List<Phone> PersonPhone { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
