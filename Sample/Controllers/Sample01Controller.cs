using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class Sample01Controller : Controller
    {
        // GET: Sample01
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(string Band1,string Band2, string Band3, string Multiplier, string Tolerance, string Temperature)
        {

            var result = CalculateOhmValue(Band1, Band2, Band3, Multiplier, Tolerance, Temperature);
            ViewData["result"] = result;

            return View();
        }

        // Here we do the work
        private object CalculateOhmValue(string band1, string band2, string band3, string multiplier, string tolerance, string temperature)
        {
            double OhmValue = 0;
            int d1 = 0;
            int d2 = 0;
            int d3 = 0 ;
            double m = 1;
            string tol = "";
            string tem = "";

            d1 = ColortoOhm(band1);
            d2 = ColortoOhm(band2);
            if (band3 != "None")
                d3 = ColortoOhm(band3);
            m = ColortoMul(multiplier);
            if (tolerance != "None")
                tol = ColortoTol(tolerance);
            if (temperature != "None")
                tem = ColortoTem(temperature);

            if (band3 != "None")
                OhmValue = ((100 * d1) + (10 * d2) + (1 * d3)) * m;
            else
                OhmValue = ((10 * d1) + (1 * d2)) * m;
          
            return (OhmValue + " " + "Ohms" + " " + tol + " " + tem);
           //RALPH
        }
        //All this may need to come from a DB.
        //It has been the same for a long time and will be the same for now.
        int ColortoOhm(string Color)
        {
            int tmp = 0;
            switch (Color)
            {
                case "Black":
                    tmp = 0;
                    break;
                case "Brown":
                    tmp = 1;
                    break;
                case "Red":
                    tmp = 2;
                    break;
                case "Orange":
                    tmp = 3;
                    break;
                case "Yellow":
                    tmp = 4;
                    break;
                case "Green":
                    tmp = 5;
                    break;
                case "Blue":
                    tmp = 6;
                    break;
                case "Puple":
                    tmp = 7;
                    break;
                case "Gray":
                    tmp = 8;
                    break;
                case "White":
                    tmp = 9;
                    break;
                default:
                    break;
            }
            return tmp;
        }
        double ColortoMul(string Color)
        {
            double tmp = 0;
            switch (Color)
            {
                case "Black":
                    tmp = 1;
                    break;
                case "Brown":
                    tmp = 10;
                    break;
                case "Red":
                    tmp = 100;
                    break;
                case "Orange":
                    tmp = 1000;
                    break;
                case "Yellow":
                    tmp = 10000;
                    break;
                case "Green":
                    tmp = 100000;
                    break;
                case "Blue":
                    tmp = 1000000;
                    break;
                case "Puple":
                    tmp = 10000000;
                    break;
                case "Gray":
                    tmp = 100000000;
                    break;
                case "White":
                    tmp = 1000000000;
                    break;
                case "Gold":
                    tmp = 0.1;
                    break;
                case "Silver":
                    tmp = 0.01;
                    break;
                default:
                    Console.WriteLine("Other");
                    break;

            }
            return tmp;
        }
        string ColortoTol(string Color)
        {
            string tmp = "";
            switch (Color)
            {
                case "Brown":
                    tmp = "1%";
                    break;
                case "Red":
                    tmp = "2%";
                    break;
                case "Green":
                    tmp = "0.5%";
                    break;
                case "Blue":
                    tmp = "0.25%";
                    break;
                case "Puple":
                    tmp = "0.1%";
                    break;
                case "Gold":
                    tmp = "5%";
                    break;
                case "Silver":
                    tmp = "10%";
                    break;
                default:
                    Console.WriteLine("Other");
                    break;
            }
            return tmp;
        }
        string ColortoTem(string Color)
        {
            string tmp = "";
            switch (Color)
            {
                case "Brown":
                    tmp = "100 ppm";
                    break;
                case "Red":
                    tmp = "50 ppm";
                    break;
                case "Orange":
                    tmp = "15 ppm";
                    break;
                case "Yellow":
                    tmp = "25 ppm";
                    break;
                default:
                    Console.WriteLine("Other");
                    break;

            }
            return tmp;
        }
    }
}