using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class schoolController : Controller
    {
        // GET: school
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult studentList()
        {
            var context = new mycontext();
            var student = context.students.ToList();
            return View(student);
        }

        [HttpGet]
        [ActionName("studentAdd")]
        public ActionResult studentAdd()
        {
            return View();
        }

        [HttpPost]
        [ActionName("studentAdd")]
        public ActionResult studentAdd(student student)
        {
            var context = new mycontext();
            if (!ModelState.IsValid)
            {
                return View("studentAdd");
            }
            UpdateModel(student);
            context.students.Add(student);
            context.SaveChanges();
            return RedirectToAction("studentList", "school");
        }

        [HttpGet]
        [ActionName("studentEdit")]
        public ActionResult studentEdit(int? id)
        {
            var context = new mycontext();
            var model = context.students.Find(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("studentEdit")]
        public ActionResult studentEdit(int? id, student student)
        {
            var context = new mycontext();

            var model = context.students.Find(id);
            model.name = student.name;
            UpdateModel(model);
            context.SaveChanges();
            return RedirectToAction("studentList", "school");

        }


        public ActionResult studentRemove(int? id)
        {
            var context = new mycontext();
            var model = context.students.SingleOrDefault(x => x.studentId == id);
            context.students.Remove(model);
            context.SaveChanges();
            return RedirectToAction("studentList", "school");
        }

        public ActionResult generalList()
        {
            var context = new mycontext();
            var general = context.generals.ToList();
            return View(general);
        }

        [HttpGet]
        [ActionName("generalAdd")]
        public ActionResult generalAdd()
        {
            return View();
        }

        [HttpPost]
        [ActionName("generalAdd")]
        public ActionResult generalAdd(general general)
        {
            var context = new mycontext();
            if (!ModelState.IsValid)
            {
                return View("OkulyonetimAdd");
            }
            UpdateModel(general);
            context.generals.Add(general);
            context.SaveChanges();
            return RedirectToAction("generalList", "school");
        }


        [HttpGet]
        [ActionName("generalEdit")]
        public ActionResult generalEdit(int? id)
        {
            var context = new mycontext();
            var model = context.generals.Find(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("generalEdit")]
        public ActionResult generalEdit(int? id, general general)
        {
            var context = new mycontext();

            var model = context.generals.Find(id);
            model.name = general.name;
            UpdateModel(model);
            context.SaveChanges();
            return RedirectToAction("generalList", "school");

        }

        public ActionResult generalRemove(int? id)
        {
            var context = new mycontext();
            var model = context.generals.SingleOrDefault(x => x.generalId == id);
            context.generals.Remove(model);
            context.SaveChanges();
            return RedirectToAction("generalList", "school");
        }

        public ActionResult lessonList()
        {
            var context = new mycontext();
            var lesson = context.lessons.ToList();
            return View(lesson);
        }


        [HttpGet]
        [ActionName("lessonAdd")]
        public ActionResult lessonAdd(lesson lesson)
        {
            using (var context = new mycontext())
            {
                List<general> teacher = context.generals.ToList();
                ViewBag.DDLteacher = new SelectList(teacher, "generalId", "name");
                return View();
            }

        }


        [HttpPost]
        [ActionName("lessonAdd")]
        public ActionResult lessonAdd(FormCollection formData, HttpPostedFileBase file)
        {
            using (var context = new mycontext())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        string teacherId = formData["DDLteacher"].ToString();
                        var lesson = new lesson();
                        lesson.generalId = int.Parse(teacherId);
                        UpdateModel(lesson);
                        context.lessons.Add(lesson);
                        context.SaveChanges();
                        return RedirectToAction("lessonList", "school");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return View();
            }

        }


        [HttpGet]
        [ActionName("lessonEdit")]
        public ActionResult lessonEdit(int? id)
        {
            var context = new mycontext();
            var model = context.lessons.Find(id);
            List<SelectListItem> teacher = context.generals.Select

                (
                x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.generalId.ToString(),
                    Selected = x.generalId == x.generalId
                }

                ).ToList();
            ViewBag.DDLteacher = teacher;
            return View(model);
        }
        [HttpPost]
        [ActionName("lessonEdit")]
        public ActionResult lessonEdit(int? id, lesson ders)
        {
            var context = new mycontext();
            var model = context.lessons.Find(id);
            model.generalId = ders.generalId;
            UpdateModel(model);
            context.SaveChanges();
            return RedirectToAction("lessonList", "school");
        }

        public ActionResult lessonRemove(int? id)
        {
            var context = new mycontext();
            var model = context.lessons.SingleOrDefault(x => x.lessonId == id);
            context.lessons.Remove(model);
            context.SaveChanges();
            return RedirectToAction("lessonList", "school");
        }

        public ActionResult toLessonList()
        {
            var context = new mycontext();
            var tolessons = context.tolessons.ToList();
            return View(tolessons);
        }


        [HttpGet]
        [ActionName("toLessonAdd")]
        public ActionResult toLessonAdd()
        {
            using (var context = new mycontext())
            {
                List<student> students = context.students.ToList();
                ViewBag.DDLstudents = new SelectList(students, "studentId", "name");

                List<lesson> lessons = context.lessons.ToList();
                ViewBag.DDLlessons = new SelectList(lessons, "lessonId", "name");
                return View();
            }

        }


        [HttpPost]
        [ActionName("toLessonAdd")]
        public ActionResult toLessonAdd(FormCollection formData)
        {
            using (var context = new mycontext())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        string studentId = formData["DDLstudents"].ToString();
                        string lessonId = formData["DDLlessons"].ToString();
                        var toLesson = new tolesson();
                        toLesson.studentId = int.Parse(studentId);
                        toLesson.lessonId = int.Parse(lessonId);
                        UpdateModel(toLesson);
                        context.tolessons.Add(toLesson);
                        context.SaveChanges();
                        return RedirectToAction("toLessonList", "school");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return View();
            }

        }

        [HttpGet]
        [ActionName("toLessonEdit")]
        public ActionResult toLessonEdit(int? id)
        {
            var context = new mycontext();
            var model = context.lessons.Find(id);
            List<SelectListItem> lessons = context.lessons.Select

                (
                x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.lessonId.ToString(),
                    Selected = x.lessonId == x.lessonId
                }

                ).ToList();
            ViewBag.DDLlessons = lessons;

            List<SelectListItem> students = context.students.Select

               (
               x => new SelectListItem
               {
                   Text = x.name,
                   Value = x.studentId.ToString(),
                   Selected = x.studentId == x.studentId
               }

               ).ToList();
            ViewBag.DDLstudents = students;
            return View(model);
        }

        [HttpPost]
        [ActionName("toLessonEdit")]
        public ActionResult toLessonEdit(int? id, tolesson tolesson)
        {
            var context = new mycontext();
            var model = context.tolessons.Find(id);
            model.lessonId = tolesson.lessonId;
            model.studentId = tolesson.lessonId;
            UpdateModel(model);
            context.SaveChanges();
            return RedirectToAction("toLessonList", "school");
        }

        public ActionResult toLessonRemove(int? id)
        {
            var context = new mycontext();
            var model = context.tolessons.SingleOrDefault(x => x.Id == id);
            context.tolessons.Remove(model);
            context.SaveChanges();
            return RedirectToAction("toLessonList", "school");
        }
    }
}