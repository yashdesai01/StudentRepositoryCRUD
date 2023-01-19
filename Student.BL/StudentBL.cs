using AutoMapper;
using Student.Database;
using Student.EntityModel;
using Student.IBL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Status = Student.Database.Status;

namespace Student.BL
{
    public class StudentBL : IStudentRepository
    {
        private StudentDBEntities objStudentDBEntity;
        public StudentBL()
        {
            objStudentDBEntity = new StudentDBEntities();
        }

        public int AddStudent(tblStudentDetail student)
        {
            tblStudentDetail studentObj = new tblStudentDetail()
            {
                Name = student.Name,
                StateID = student.StateID,
                Country = student.Country,
                StatusID = student.StatusID,
                Image = student.Image
            };
            if(student.ID == 0)
            {
                objStudentDBEntity.tblStudentDetails.Add(studentObj);
            }
            else
            {
                studentObj.ID = student.ID;
                var tblStudent = objStudentDBEntity.tblStudentDetails.First(g => g.ID == student.ID);
                tblStudent.Name = student.Name;
                tblStudent.StatusID = student.StatusID;
                tblStudent.StateID = student.StateID;
                tblStudent.CountryID = student.CountryID;
                tblStudent.Image = student.Image;
            }
            return objStudentDBEntity.SaveChanges(); // 0 for not save
        }

        public tblStudentDetail GetStudentById(int StudentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblStudentDetail> GetStudentList()
        {
            IEnumerable<tblStudentDetail> StudentObj = objStudentDBEntity.tblStudentDetails.ToList();
            return StudentObj;
        }

        public tblStudentDetail UpdateStudent(int ID)
        {
            tblStudentDetail student = objStudentDBEntity.tblStudentDetails.Find(ID);
            return student;
        }

        public int RemoveStudent(int ID)
        {
            tblStudentDetail studentDetail = objStudentDBEntity.tblStudentDetails.Find(ID);
            if(studentDetail != null)
            {
                objStudentDBEntity.tblStudentDetails.Remove(studentDetail);
                objStudentDBEntity.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<countryState> StateList()
        {
            List<countryState> States = objStudentDBEntity.countryStates.ToList();
            return States;
        }

        public List<Status> StatusList()
        {
            List<Status> Status = objStudentDBEntity.Status.ToList();
            return Status;
        }
    }
}
