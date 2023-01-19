using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.EntityModel
{
    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<tblStudentDetails> StudentDetails { get; set; }
    }
}
