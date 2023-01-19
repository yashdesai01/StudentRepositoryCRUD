using AutoMapper;
using Student.Database;
using Student.EntityModel;
using Student.IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BL
{
    public class RegisterManager : IRegister
    {
        private StudentDBEntities _objStudentDBEntity;

        public bool Register(tblStudentDetail reg)
        {
            tblStudentDetail tbl = new tblStudentDetail() { 
                Name = reg.Name,
                CountryID = reg.CountryID,
                StateID = reg.StateID,
                StatusID = reg.StatusID,
                Image = reg.Image
            };

            //Mapper.Initialize<IStudentRepository, StudentDetail>();  //creating map  
            //var userDto = Mapper.Map<IStudentRepository, StudentDetail>(reg);

            _objStudentDBEntity.tblStudentDetails.Add(tbl);
            if (_objStudentDBEntity.SaveChanges() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
