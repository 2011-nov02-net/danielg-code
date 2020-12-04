using System;
using Microsoft.AspNetCore.Mvc;

namespace HelloAspWebApp.Controllers
{
    public class ViewBasedController : Controller
    {
        public IActionResult HomePage()
        {
            // usually we return view results with the View helper method from the Contorller base class

            // This says give me a view named home
            return View("Home");
        }

        public IActionResult ViewWithLayout1()
        {
            // views can have a layout
            //  a layout is a special kind of view that cant stand on its own
            //   at some point it calls @RenderBodt()
            //     that is where the actual view goes

            return View("Page1");
        }

        public IActionResult ViewWithLayout2()
        {
            return View();
        }
    }
}
