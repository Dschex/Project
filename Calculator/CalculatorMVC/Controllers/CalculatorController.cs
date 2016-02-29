using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculatorMVC.Controllers
{
    public class CalculatorController : Controller
    {
        // GET:/Calculator
        public ActionResult Index(string firstNumber)
        {
            if (firstNumber != string.Empty)
            {
                return View(firstNumber);
            }
            return View("OPPS");
            
        }
    }
}