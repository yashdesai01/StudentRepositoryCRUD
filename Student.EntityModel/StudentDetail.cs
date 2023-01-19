using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.EntityModel
{
    public class tblStudentDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string Image { get; set; }

        public virtual Country Country { get; set; }
        public virtual Status Status { get; set; }
    }
}
