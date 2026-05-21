using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_spajanje_repo.Repository;

namespace MVC_spajanje_repo.Controllers
{
    public class StudentController : Controller
    {
        private HomeRepo _repo;

        public StudentController(IConfiguration configuration)
        {
            _repo = new HomeRepo(configuration);
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var studenti = _repo.GetAllStudents();
            return View(studenti);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student=_repo.GetStudentById(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student= _repo.GetStudentById(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if(_repo.DeleteStudent(id)) return RedirectToAction(nameof(Index));
                throw new Exception("Neuspješno brisanje studenta!");
            }
            catch (Exception ex) {
            {
                ViewBag.Message = ex.Message;
                var student = _repo.GetStudentById(id);
                return View(student);
            }
        }
    }
}
