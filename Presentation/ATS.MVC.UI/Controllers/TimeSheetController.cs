using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATS.Data.Model;
using ATS.Data;
using ATS.Data.DAL;

namespace ATS.MVC.UI.Controllers
{
    public class TimeSheetController : BaseController
    {
        //
        // GET: /TimeSheet/

        public ActionResult Index()
        {
            var timeSheetMasters = TimesheetRepository.GetAllTimeSheetMasters();
            return View(timeSheetMasters.ToList());
        }

        //
        // GET: /TimeSheet/Details/5

        public ActionResult Details(int id)
        {
            TimeSheetMaster master = TimesheetRepository.GetTimeSheetMasterById(id);
            var detail = master.TimeSheetDetail;
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail.ToList());
        }

        //
        // GET: /TimeSheet/Create

        public ActionResult Create()
        {
            // Create TimeSheet Master
            // Create Detail List based on the number of days from the calendar month
            PersonRepository personRepository = new PersonRepository(new ATSCEEntities());
            Staff staff = personRepository.GetStaffByID(2);

            TimeSheetMaster master = TimesheetRepository.CreateTimeSheetMasterTemplate(DateTime.Today, staff);
            return View(master);
        }

        //
        // POST: /TimeSheet/Create

        [HttpPost]
        public ActionResult Create(TimeSheetMaster master)
        {
            if (ModelState.IsValid)
            {
                master.Save();
                return RedirectToAction("Index");
            }

            return View(master);
        }

        //
        // GET: /TimeSheet/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TimeSheetMaster master = TimesheetRepository.GetTimeSheetMasterById(id);

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Approved",
                Value = "1"
            });
            items.Add(new SelectListItem
            {
                Text = "Submitted",
                Value = "2",
            });
            items.Add(new SelectListItem
            {
                Text = "Rejected",
                Value = "3"
            });
            ViewBag.StatusList = items;

            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        //
        // POST: /TimeSheet/Edit/5

        [HttpPost]
        public ActionResult Edit(TimeSheetMaster master)
        {
            TimeSheetMaster newMaster = master;
            if (ModelState.IsValid)
            {
                newMaster.Save();
                return RedirectToAction("Index");
            }
            return View(master);
        }

        //
        // GET: /TimeSheet/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TimeSheetDetail detail = TimesheetRepository.GetTimeSheetDetailById(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        //
        // POST: /TimeSheet/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSheetDetail.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
