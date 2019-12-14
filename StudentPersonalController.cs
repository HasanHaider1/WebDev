using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDevProject.Models;

namespace WebDevProject.Controllers
{
    public class StudentPersonalController : Controller
    {
        private DCSEntities db = new DCSEntities();

        // GET: StudentPersonal
        public ActionResult Index()
        {
            var studentPersonals = db.StudentPersonals.Include(s => s.School).Include(s => s.StudentClassroom).Include(s => s.StudentHistory).Include(s => s.StudentSchool);
            return View(studentPersonals.ToList());
        }

        // GET: StudentPersonal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPersonal studentPersonal = db.StudentPersonals.Find(id);
            if (studentPersonal == null)
            {
                return HttpNotFound();
            }
            return View(studentPersonal);
        }

        // GET: StudentPersonal/Create
        public ActionResult Create()
        {
            ViewBag.School_idSchool = new SelectList(db.Schools, "idSchool", "nameSchool");
            ViewBag.idStudent = new SelectList(db.StudentClassrooms, "StudentPersonal_idStudent", "month_2");
            ViewBag.idStudent = new SelectList(db.StudentHistories, "StudentPersonal_idStudent", "teacherComments");
            ViewBag.idStudent = new SelectList(db.StudentSchools, "StudentPersonal_idStudent", "month_2");
            return View();
        }

        // POST: StudentPersonal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStudent,School_idSchool,name,grade,age,contact,prevSchool,currentlyStudying,nextSchool")] StudentPersonal studentPersonal)
        {
            
            var schoolID = (from s in db.Schools
                            where s.emailID == User.Identity.Name
                            select s.idSchool).First();
            

            if (ModelState.IsValid)
            {
                studentPersonal.School_idSchool = schoolID;
                db.StudentPersonals.Add(studentPersonal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.School_idSchool = new SelectList(db.Schools, "idSchool", "nameSchool", studentPersonal.School_idSchool);
            ViewBag.idStudent = new SelectList(db.StudentClassrooms, "StudentPersonal_idStudent", "month_2", studentPersonal.idStudent);
            ViewBag.idStudent = new SelectList(db.StudentHistories, "StudentPersonal_idStudent", "teacherComments", studentPersonal.idStudent);
            ViewBag.idStudent = new SelectList(db.StudentSchools, "StudentPersonal_idStudent", "month_2", studentPersonal.idStudent);
            return View(studentPersonal);
        }

        // GET: StudentPersonal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPersonal studentPersonal = db.StudentPersonals.Find(id);
            if (studentPersonal == null)
            {
                return HttpNotFound();
            }
            ViewBag.School_idSchool = new SelectList(db.Schools, "idSchool", "nameSchool", studentPersonal.School_idSchool);
            ViewBag.idStudent = new SelectList(db.StudentClassrooms, "StudentPersonal_idStudent", "month_2", studentPersonal.idStudent);
            ViewBag.idStudent = new SelectList(db.StudentHistories, "StudentPersonal_idStudent", "teacherComments", studentPersonal.idStudent);
            ViewBag.idStudent = new SelectList(db.StudentSchools, "StudentPersonal_idStudent", "month_2", studentPersonal.idStudent);
            return View(studentPersonal);
        }

        // POST: StudentPersonal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStudent,School_idSchool,name,grade,age,contact,prevSchool,currentlyStudying,nextSchool")] StudentPersonal studentPersonal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentPersonal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.School_idSchool = new SelectList(db.Schools, "idSchool", "nameSchool", studentPersonal.School_idSchool);
            ViewBag.idStudent = new SelectList(db.StudentClassrooms, "StudentPersonal_idStudent", "month_2", studentPersonal.idStudent);
            ViewBag.idStudent = new SelectList(db.StudentHistories, "StudentPersonal_idStudent", "teacherComments", studentPersonal.idStudent);
            ViewBag.idStudent = new SelectList(db.StudentSchools, "StudentPersonal_idStudent", "month_2", studentPersonal.idStudent);
            return View(studentPersonal);
        }

        // GET: StudentPersonal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPersonal studentPersonal = db.StudentPersonals.Find(id);
            if (studentPersonal == null)
            {
                return HttpNotFound();
            }
            return View(studentPersonal);
        }

        // POST: StudentPersonal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentPersonal studentPersonal = db.StudentPersonals.Find(id);
            db.StudentPersonals.Remove(studentPersonal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
