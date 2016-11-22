using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Phone
    {
        public int PhoneID { get; set; }
        public string Home { get; set; }
        public string Cellphone { get; set; }
        public string Other { get; set; }
        public virtual Person person { get; set; }
    }
}
