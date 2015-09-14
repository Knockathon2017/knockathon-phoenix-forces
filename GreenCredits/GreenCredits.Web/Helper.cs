using GreenCredits.DAL;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace GreenCredits.Web
{
    public static class Helper
    {
        public static IHtmlString Traders(this HtmlHelper html)
        {
            var traders = ObjectFactory.GetInstance<IFarmerRepository>().GetTraders();
            return html.Partial(@"~/Views/Dashboard/TradersListView.cshtml", traders);
        }
    }
}