// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Web;
using System.Web.Mvc;

namespace ShreyCart.Service
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
