using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloAspWebApp.Controllers
{
    // Controllers shoudl end in the word controller
    //   and their name is before that

    // Controllers contain action methods
    // Each action method will process one kind of request that it matches
    // Group related action methods into one controller so they can share some
    //  Setup code, etc...
    public class HelloController
    {

        // Action methods job is to fulfill the users request, and return
        //   some "IActionResult"
        // 
        public IActionResult Action1()
        {
            Console.WriteLine("Action method");

            // ContentResult is the most flexible, low-level IActionResult
            return new ContentResult
            {
                Content = "<html> <head> </head> <body>Hello from contenet result </body> </html>",
                ContentType = "text/html",
                StatusCode = StatusCodes.Status200OK
            };

            // Instead we use ViewResult
            //   This handles out Razor Views. Views are a powerful html templating thing.

        }


        // Sources for action method parameters: (automatic deserialization)
        //    Route parameters in the URL... configured with braces in route patters in the start up file
        //    Query strings parameters in the URL (automatic, no config needed, if param name matches)
        //    Request body (e.g. form data)
        //    Some others if you configure things especially right for them

        // For query params, you might want to add a default value to the paramterrs,
        //   For route parameters, you dont need default values

        // The preocess of fillingin action method parameters is called model binding.
        //   typically problems in model binding do not throw exceptions, they just leave the .NET values at their defaults
        public IActionResult ParameterizedAction(string param1= "", int param2 = 0)
        {
            Console.WriteLine("Action method");

            // ContentResult is the most flexible, low-level IActionResult
            return new ContentResult
            {
                Content = $"<html> <head> </head> <body>Hello {param1}, {param2} from contenet result </body> </html>",
                ContentType = "text/html",
                StatusCode = StatusCodes.Status200OK
            };

            // Instead we use ViewResult
            //   This handles out Razor Views. Views are a powerful html templating thing.

        }

        public IActionResult Redirect1()
        {
            //return new RedirectToRouteResult("hello-controller-generic", new { controller = "Hello", action = "Redirect2"});
            return new RedirectToActionResult(actionName: "Redirect2", controllerName: "Hello", routeValues: null);
        }

        public IActionResult Redirect2()
        {
            return new RedirectToActionResult(actionName: "Redirect1", controllerName: "Hello", routeValues: null);
        }


    }
}
