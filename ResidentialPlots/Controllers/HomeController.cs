using System.Diagnostics;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using ResidentialPlots.Models;

namespace ResidentialPlots.Controllers;

public class HomeController(IUnitOfWork p_unitOfWork) : Controller
{
    private readonly IUnitOfWork _unitOfWork = p_unitOfWork;

    public IActionResult Index()
    {
        List<ResidentialPlot> plots = _unitOfWork.ResidentialPlots.GetElements();
        
        return View(plots);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}