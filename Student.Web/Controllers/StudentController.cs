using Student.BL;
using Student.Database;
using Student.IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Student.Web.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository studentRepository;
        public StudentController(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        public ActionResult Index()
        {
            //StudentBL StudentRepo = new StudentBL();
            //StudentRepo.GetStudentList();
            //return View(StudentRepo);

            IEnumerable<tblStudentDetail> StudentList = (IEnumerable<tblStudentDetail>)studentRepository.GetStudentList();
            return View(StudentList);
        }

        public ActionResult AddStudent()
        {
            ViewBag.Status = new SelectList(studentRepository.StatusList(), "Status1");
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(tblStudentDetail student)
        {
            tblStudentDetail StudentObj = new tblStudentDetail()
            {
                Name = student.Name,
                Image = student.Image,
                CountryID = student.CountryID,
                StateID = student.StateID,
                StatusID = student.StatusID
            };
            if (student.ID == 0)
            {
                int result = studentRepository.AddStudent(StudentObj);
            }
            else
            {
                StudentObj.ID = student.ID;
                int result = studentRepository.AddStudent(StudentObj);
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult RemoveStudent(int ID)
        {
            int result = studentRepository.RemoveStudent(ID);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateStudent(int ID)
        {
            //if (ID == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            tblStudentDetail studentDetail = studentRepository.UpdateStudent(ID);
            if (studentDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(studentRepository.StatusList(), "CountryId", "County", studentDetail.CountryID);
            ViewBag.StatusID = new SelectList(studentRepository.StatusList(), "StatusId", "Status1", studentDetail.StatusID);
            return View(studentDetail);
        }

    }
}