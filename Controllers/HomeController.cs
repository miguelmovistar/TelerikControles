using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TelerikControles.Models;

namespace TelerikControles.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetCreditCard([DataSourceRequest]DataSourceRequest request)
        {
            return Json(_GetCreditCard().ToDataSourceResult(request));
        }

        private static IEnumerable<CreditCard> _GetCreditCard()
        {
            List<CreditCard> List = new List<CreditCard>();
            AdventureWorksEntities1 db = new AdventureWorksEntities1();
            var CreditCardResult = from k in db.CreditCard select k;
            foreach (var item in CreditCardResult)
            {
                CreditCard entidad = new CreditCard();
                entidad.CreditCardID = item.CreditCardID;
                entidad.CardType = item.CardType;
                entidad.CardNumber = item.CardNumber;
                List.Add(entidad);
            }

            return List;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}