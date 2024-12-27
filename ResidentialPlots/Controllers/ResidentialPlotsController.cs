using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ResidentialPlots.Controllers;

public class ResidentialPlotsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ResidentialPlotsController(IUnitOfWork p_unitOfWork)
    {
        _unitOfWork = p_unitOfWork;
    }

    public IActionResult Index()
    {
        List<ResidentialPlot> plots = _unitOfWork.ResidentialPlots.GetElements();

        return View(plots);
    }
}