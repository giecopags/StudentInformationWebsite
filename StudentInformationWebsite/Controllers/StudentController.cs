using Microsoft.AspNetCore.Mvc;
using StudentInformationWebsite.Models;

namespace StudentInformationWebsite.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                student.ID = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Create");
            }
            return View(student);
        }

        //[HttpPost]
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(student => student.ID == id);
            if (student == null)
                return NotFound();  
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(int id, Student student) 
        {
            if (id != student.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(student => student.ID == id);
                if (existingStudent == null)
                    return NotFound();

                existingStudent.FirstName = student.FirstName;
                existingStudent.MiddleName = student.MiddleName;
                existingStudent.LastName = student.LastName;
                existingStudent.Address = student.Address;
                existingStudent.Age = student.Age;
                existingStudent.ContactNumber = student.ContactNumber;
                existingStudent.Gender = student.Gender;

                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(students => students.ID == id);
            if(student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.ID == id);
            if(student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}
