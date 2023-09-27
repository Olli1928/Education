using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Education.Controllers;

public class EducationSiteController : Controller
{
    // 
    // GET: /EducationSite/
    public IActionResult Welcome()
    {
        return View("Welcome");
    }
    // 
    
}