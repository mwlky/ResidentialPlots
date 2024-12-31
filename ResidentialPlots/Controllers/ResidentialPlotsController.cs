using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ResidentialPlots.Controllers;

public class ResidentialPlotsController(IUnitOfWork p_unitOfWork) : Controller
{
    public IActionResult Index()
    {
        List<ResidentialPlot> plots = p_unitOfWork.ResidentialPlots.GetElements();

        return View(plots);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ResidentialPlot plot)
    {
        if (!ModelState.IsValid)
            return View();

        p_unitOfWork.ResidentialPlots.Add(plot);
        p_unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int? id)
    {
        if (!id.HasValue)
            return NotFound();

        ResidentialPlot plot = p_unitOfWork.ResidentialPlots.GetElements().Find(x => x.ID == id);
        if (plot is null)
            return NotFound();

        return View(plot);
    }

    [HttpPost]
    public IActionResult Edit(ResidentialPlot plot)
    {
        if (!ModelState.IsValid)
            return View();

        p_unitOfWork.ResidentialPlots.Update(plot);
        p_unitOfWork.Save();

        return RedirectToAction(nameof(Index));
    }
    
    
    public IActionResult Remove(int? id)
    {
        if (!id.HasValue)
            return RedirectToAction(nameof(Index));

        ResidentialPlot plot = p_unitOfWork.ResidentialPlots.GetElements().Find(x => x.ID == id);
        if (plot is null)
            return NotFound();

        return View(plot);
    }

    [HttpPost]
    public IActionResult RemovePOST(int? id)
    {
        if(!id.HasValue)
            return RedirectToAction(nameof(Index));
        
        ResidentialPlot actualPlot = p_unitOfWork.ResidentialPlots.GetElements().Find(x => x.ID == id.Value);
        if (actualPlot is null)
            return NotFound();

        p_unitOfWork.ResidentialPlots.Remove(actualPlot);
        p_unitOfWork.Save();
        
        return RedirectToAction(nameof(Index));
    }
}