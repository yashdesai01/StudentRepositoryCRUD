using Student.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.Web.Controllers.Repository
{
    public class StudentRepository<T> : IStudents<T> where T : class
    {
        private StudentEntityModel db;
        private IDbset<T> DbEntity;
        public StudentRepository()
        {
            db = new StudentEntityModel();
            DbEntity = db.Set<T>();
        }
        public void DeleteById(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetData()
        {
            throw new NotImplementedException();
        }

        public T GetDataById(int ID)
        {
            throw new NotImplementedException();
        }

        public void InsertData(T ClassName)
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(T ClassName)
        {
            throw new NotImplementedException();
        }
    }
}