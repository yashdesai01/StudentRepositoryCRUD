using Student.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.IBL
{
    public interface IRegister
    {
        bool Register(tblStudentDetail reg);
    }
}
