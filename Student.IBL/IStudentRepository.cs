using Student.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.IBL
{
    public interface IStudentRepository
    {
        IEnumerable<tblStudentDetail> GetStudentList();
        int AddStudent(tblStudentDetail student);
        tblStudentDetail GetStudentById(int StudentId);
        int RemoveStudent(int ID);
        tblStudentDetail UpdateStudent(int ID);
        List<Status> StatusList();
        List<countryState> StateList();
    }
}
