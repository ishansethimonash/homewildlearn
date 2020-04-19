using HomeWildLearn.Models;
using HomeWildLearn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWildLearn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult About(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        public ActionResult Kids()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Parents()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Whatsnew()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AnimalsAroundMe()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Explore()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ExploreSearch()
        {
            //ViewBag.Message = "Your application description page.";

            if (TempData["shortMessage"] != null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
            }
            return View();
        }

        public ActionResult TestYourKnowledge()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult InterestingFacts()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult WhereTo()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult LearnCamping()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}