using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PivotTable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = PivotData.GetPivotData(); ViewBag.DataSource = data;
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }

    public class PivotData
    {
        public int Sold { get; set; }
        public double Amount { get; set; }
        public string Country { get; set; }
        public string Products { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }

        private static List<PivotData> pivotDataList = new List<PivotData>();

        public PivotData() { }

        public PivotData(int sold, double amount, string country, string products, string year, string quarter)
        {
            Sold = sold;
            Amount = amount;
            Country = country;
            Products = products;
            Year = year;
            Quarter = quarter;
        }

        public static List<PivotData> GetPivotData()
        {
            if (pivotDataList.Count == 0)
            {
                pivotDataList.Add(new PivotData(31, 52824, "France", "Mountain Bikes", "FY 2015", "Q1"));
                pivotDataList.Add(new PivotData(51, 86904, "France", "Mountain Bikes", "FY 2015", "Q2"));
                pivotDataList.Add(new PivotData(90, 153360, "France", "Mountain Bikes", "FY 2015", "Q3"));
                pivotDataList.Add(new PivotData(25, 42600, "France", "Mountain Bikes", "FY 2015", "Q4"));
                pivotDataList.Add(new PivotData(27, 46008, "France", "Mountain Bikes", "FY 2016", "Q1"));
                pivotDataList.Add(new PivotData(49, 83496, "France", "Mountain Bikes", "FY 2016", "Q2"));
                pivotDataList.Add(new PivotData(95, 161880, "France", "Mountain Bikes", "FY 2016", "Q3"));
                pivotDataList.Add(new PivotData(67, 114168, "France", "Mountain Bikes", "FY 2016", "Q4"));
                pivotDataList.Add(new PivotData(75, 127800, "France", "Mountain Bikes", "FY 2017", "Q1"));
                pivotDataList.Add(new PivotData(67, 114168, "France", "Mountain Bikes", "FY 2017", "Q2"));
                pivotDataList.Add(new PivotData(69, 117576, "France", "Mountain Bikes", "FY 2017", "Q3"));
                pivotDataList.Add(new PivotData(90, 153360, "France", "Mountain Bikes", "FY 2017", "Q4"));
                pivotDataList.Add(new PivotData(16, 27264, "France", "Mountain Bikes", "FY 2018", "Q1"));
                pivotDataList.Add(new PivotData(83, 124422, "France", "Road Bikes", "FY 2015", "Q1"));
                pivotDataList.Add(new PivotData(57, 85448, "France", "Road Bikes", "FY 2015", "Q2"));
                pivotDataList.Add(new PivotData(20, 29985, "France", "Road Bikes", "FY 2015", "Q3"));
                pivotDataList.Add(new PivotData(67, 70008, "France", "Road Bikes", "FY 2016", "Q1"));
                pivotDataList.Add(new PivotData(89, 60496, "France", "Road Bikes", "FY 2016", "Q2"));
                pivotDataList.Add(new PivotData(75, 801880, "France", "Road Bikes", "FY 2016", "Q3"));
                pivotDataList.Add(new PivotData(57, 204168, "France", "Road Bikes", "FY 2016", "Q4"));
                pivotDataList.Add(new PivotData(75, 737800, "France", "Road Bikes", "FY 2017", "Q1"));
                pivotDataList.Add(new PivotData(87, 884168, "France", "Road Bikes", "FY 2017", "Q2"));
                pivotDataList.Add(new PivotData(39, 729576, "France", "Road Bikes", "FY 2017", "Q3"));
                pivotDataList.Add(new PivotData(90, 38860, "France", "Road Bikes", "FY 2017", "Q4"));
                pivotDataList.Add(new PivotData(93, 139412, "France", "Road Bikes", "FY 2015", "Q4"));
                pivotDataList.Add(new PivotData(51, 92824, "Germany", "Mountain Bikes", "FY 2015", "Q1"));
                pivotDataList.Add(new PivotData(61, 76904, "Germany", "Mountain Bikes", "FY 2015", "Q2"));
                pivotDataList.Add(new PivotData(70, 43360, "Germany", "Mountain Bikes", "FY 2015", "Q3"));
                pivotDataList.Add(new PivotData(85, 62600, "Germany", "Mountain Bikes", "FY 2015", "Q4"));
                pivotDataList.Add(new PivotData(97, 86008, "Germany", "Mountain Bikes", "FY 2016", "Q1"));
                pivotDataList.Add(new PivotData(69, 93496, "Germany", "Mountain Bikes", "FY 2016", "Q2"));
                pivotDataList.Add(new PivotData(45, 301880, "Germany", "Mountain Bikes", "FY 2016", "Q3"));
                pivotDataList.Add(new PivotData(77, 404168, "Germany", "Mountain Bikes", "FY 2016", "Q4"));
                pivotDataList.Add(new PivotData(15, 137800, "Germany", "Mountain Bikes", "FY 2017", "Q1"));
                pivotDataList.Add(new PivotData(37, 184168, "Germany", "Mountain Bikes", "FY 2017", "Q2"));
                pivotDataList.Add(new PivotData(49, 89576, "Germany", "Mountain Bikes", "FY 2017", "Q3"));
                pivotDataList.Add(new PivotData(40, 33360, "Germany", "Mountain Bikes", "FY 2017", "Q4"));
                pivotDataList.Add(new PivotData(96, 77264, "Germany", "Mountain Bikes", "FY 2018", "Q1"));
                pivotDataList.Add(new PivotData(23, 24422, "Germany", "Road Bikes", "FY 2015", "Q1"));
                pivotDataList.Add(new PivotData(67, 75448, "Germany", "Road Bikes", "FY 2015", "Q2"));
                pivotDataList.Add(new PivotData(70, 52345, "Germany", "Road Bikes", "FY 2015", "Q3"));
                pivotDataList.Add(new PivotData(13, 135612, "Germany", "Road Bikes", "FY 2015", "Q4"));
                pivotDataList.Add(new PivotData(57, 90008, "Germany", "Road Bikes", "FY 2016", "Q1"));
                pivotDataList.Add(new PivotData(29, 90496, "Germany", "Road Bikes", "FY 2016", "Q2"));
                pivotDataList.Add(new PivotData(45, 301880, "Germany", "Road Bikes", "FY 2016", "Q3"));
                pivotDataList.Add(new PivotData(77, 404168, "Germany", "Road Bikes", "FY 2016", "Q4"));
                pivotDataList.Add(new PivotData(15, 137800, "Germany", "Road Bikes", "FY 2017", "Q1"));
                pivotDataList.Add(new PivotData(37, 184168, "Germany", "Road Bikes", "FY 2017", "Q2"));
                pivotDataList.Add(new PivotData(99, 829576, "Germany", "Road Bikes", "FY 2017", "Q3"));
                pivotDataList.Add(new PivotData(80, 38360, "Germany", "Road Bikes", "FY 2017", "Q4"));
                pivotDataList.Add(new PivotData(91, 67824, "United States", "Mountain Bikes", "FY 2015", "Q1"));
                pivotDataList.Add(new PivotData(81, 99904, "United States", "Mountain Bikes", "FY 2015", "Q2"));
                pivotDataList.Add(new PivotData(70, 49360, "United States", "Mountain Bikes", "FY 2015", "Q3"));
                pivotDataList.Add(new PivotData(65, 69600, "United States", "Mountain Bikes", "FY 2015", "Q4"));
                pivotDataList.Add(new PivotData(57, 90008, "United States", "Mountain Bikes", "FY 2016", "Q1"));
                pivotDataList.Add(new PivotData(29, 90496, "United States", "Mountain Bikes", "FY 2016", "Q2"));
                pivotDataList.Add(new PivotData(45, 301880, "United States", "Mountain Bikes", "FY 2016", "Q3"));
                pivotDataList.Add(new PivotData(77, 404168, "United States", "Mountain Bikes", "FY 2016", "Q4"));
                pivotDataList.Add(new PivotData(15, 137800, "United States", "Mountain Bikes", "FY 2017", "Q1"));
                pivotDataList.Add(new PivotData(37, 184168, "United States", "Mountain Bikes", "FY 2017", "Q2"));
                pivotDataList.Add(new PivotData(49, 89576, "United States", "Mountain Bikes", "FY 2017", "Q3"));
                pivotDataList.Add(new PivotData(40, 33360, "United States", "Mountain Bikes", "FY 2017", "Q4"));
                pivotDataList.Add(new PivotData(96, 77264, "United States", "Mountain Bikes", "FY 2018", "Q1"));
                pivotDataList.Add(new PivotData(23, 24422, "United States", "Road Bikes", "FY 2015", "Q1"));
                pivotDataList.Add(new PivotData(67, 75448, "United States", "Road Bikes", "FY 2015", "Q2"));
                pivotDataList.Add(new PivotData(70, 52345, "United States", "Road Bikes", "FY 2015", "Q3"));
                pivotDataList.Add(new PivotData(13, 135612, "United States", "Road Bikes", "FY 2015", "Q4"));
                pivotDataList.Add(new PivotData(57, 90008, "United States", "Road Bikes", "FY 2016", "Q1"));
                pivotDataList.Add(new PivotData(29, 90496, "United States", "Road Bikes", "FY 2016", "Q2"));
                pivotDataList.Add(new PivotData(45, 301880, "United States", "Road Bikes", "FY 2016", "Q3"));
                pivotDataList.Add(new PivotData(77, 404168, "United States", "Road Bikes", "FY 2016", "Q4"));
                pivotDataList.Add(new PivotData(15, 137800, "United States", "Road Bikes", "FY 2017", "Q1"));
                pivotDataList.Add(new PivotData(37, 184168, "United States", "Road Bikes", "FY 2017", "Q2"));
                pivotDataList.Add(new PivotData(99, 829576, "United States", "Road Bikes", "FY 2017", "Q3"));
                pivotDataList.Add(new PivotData(80, 38360, "United States", "Road Bikes", "FY 2017", "Q4"));
            }

            return pivotDataList;
        }

    }

}