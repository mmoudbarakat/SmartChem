



using App.Metrics;
using Microsoft.AspNetCore.Mvc;
using UnitsNet;

namespace SmartChemMVC.Controllers
{
    public class UnitsConverterController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Convert(decimal quantity, string category, string fromUnit, string toUnit)
        //{
        //    // Add the necessary conversion logic based on the selected category, fromUnit, and toUnit
        //    // Store the converted value in a ViewBag property or a model object

        //    return View("Index");
        //}



        //Speed
        //public IActionResult SpeedConverter()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ActionName("SpeedConverter")]
        //public IActionResult SpeedConverter(decimal quantity, string fromUnit, string toUnit)
        //{
        //    var convertedValue = PerformSpeedUnitConversion(quantity, fromUnit, toUnit);
        //    ViewBag.ConvertedValue = convertedValue;

        //    return View();
        //}

        //private string PerformSpeedUnitConversion(decimal quantity, string fromUnit, string toUnit)
        //{
        //    double value = decimal.ToDouble(quantity);

        //    // Use UnitsNet to perform the speed conversion
        //    Speed fromSpeed = Speed.FromKilometersPerHour(value);

        //    switch (toUnit)
        //    {
        //        case "m/s":
        //            Speed toSpeedMetersPerSecond = Speed.FromMetersPerSecond(fromSpeed.MetersPerSecond);
        //            return $"{toSpeedMetersPerSecond} m/s";
        //        case "mph":
        //            Speed toSpeedMilesPerHour = Speed.FromMilesPerHour(fromSpeed.MilesPerHour);
        //            return $"{toSpeedMilesPerHour} mph";
        //        case "km/h":
        //            return $"{value} km/h";
        //        default:
        //            return string.Empty;
        //    }
        //}




        ////Area
        //public IActionResult AreaConverter()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AreaConverter(decimal quantity, string fromUnit, string toUnit)
        //{
        //    var convertedValue = PerformAreaUnitConversion(quantity, fromUnit, toUnit);
        //    ViewBag.ConvertedValue = convertedValue;

        //    return View();
        //}

        //private string PerformAreaUnitConversion(decimal quantity, string fromUnit, string toUnit)
        //{
        //    double value = decimal.ToDouble(quantity);

        //    // Use UnitsNet to perform the area conversion
        //    Area fromArea = Area.FromSquareKilometers(value);

        //    switch (toUnit)
        //    {
        //        case "m²":
        //            Area toAreaSquareMeters = fromArea;
        //            return $"{toAreaSquareMeters} m²";
        //        case "ha":
        //            Area toAreaHectares = Area.FromHectares(fromArea.Hectares);
        //            return $"{toAreaHectares} ha";
        //        case "km²":
        //            return $"{value} km²";
        //        default:
        //            return string.Empty;
        //    }
        //}




    }
}

