using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Web.Controllers.Repository
{
    interface IStudents<T> where T:class
    {
        IEnumerable<T> GetData();
        T GetDataById(int ID);
        void InsertData(T ClassName);
        void DeleteById(int ID);
        void UpdateById(T ClassName);
        void SaveData();
    }
}
