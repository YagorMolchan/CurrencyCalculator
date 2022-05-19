using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;
using System.Xml;
using CurrencyCalculator.Models.Entities;
using CurrencyCalculator.Models.ViewModels;
using CurrencyCalculator.Extensions;

namespace CurrencyCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IHttpClientFactory _factory;

        

        public CalculatorController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public IActionResult Index(CalculatorViewModel model)
        {
            return View(model);
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    XmlDocument xmlDocument = new XmlDocument();
        //    xmlDocument.Load("https://www.lb.lt/webservices/FxRates/FxRates.asmx/getCurrencyList");

        //    List<Currency> currencies = xmlDocument.GetCurrencyList();
        //    xmlDocument.Load(string.Format("https://www.lb.lt/webservices/FxRates/FxRates.asmx/getFxRates?tp=EU&dt={0}", DateTime.Now.ToString("yyyy-MM-dd")));

        //    List<string> childCurrencies = xmlDocument.GetChildCurrencies();

        //    currencies = currencies.Join(childCurrencies,
        //            curr => curr.Abbreviation,
        //            child => child,
        //            (curr, child) => new Currency{ Abbreviation = child, Name = curr.Name }
        //        ).ToList();

        //    RateViewModel model = new RateViewModel
        //    {
        //        RateDate = DateTime.Now,
        //        Rate = 1,
        //        FromAbbreviation = "EUR",
        //        FromCurrencies = new SelectList(currencies, "Abbreviation", "Name"),
        //        ToAbbreviation = "EUR",
        //        ToCurrencies = new SelectList(currencies, "Abbreviation", "Name"),
        //    };           

        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Index(RateViewModel model)
        //{
        //    return View(model);
        //}


        //public JsonResult GetFxRate(RateViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        XmlDocument xmlDocument = new XmlDocument();
        //        xmlDocument.Load(string.Format("https://www.lb.lt/webservices/FxRates/FxRates.asmx/getFxRates?tp=EU&dt={0}", DateTime.Now.ToString("yyyy-MM-dd")));

        //        var fromRate = (model.FromAbbreviation == "EUR") ? 1 : xmlDocument.GetFxRate(model.FromAbbreviation);
        //        var toRate = (model.ToAbbreviation == "EUR") ? 1 : xmlDocument.GetFxRate(model.ToAbbreviation);

        //        model.Rate = toRate / fromRate;
        //    }
        //    return Json(model);
        //}


    }
}
