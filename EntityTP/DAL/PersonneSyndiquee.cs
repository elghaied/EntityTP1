using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTP.DAL
{
    public class PersonneSyndiquee : Personne
    {
        public string Syndicat {  get; set; }
        public DateTime DateSyndication {  get; set; }
    }
}
