using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using Utilities;

namespace ResidentialPlots.Controllers;

// [Area("Admin")]
[Authorize(Roles = StaticData.RULE_ADMIN)]
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

        TempData["success"] = StaticData.PLOT_CREATED_MESSAGE;

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
    public IActionResult Edit(ResidentialPlot plot, List<IFormFile> images)
    {
        if (!ModelState.IsValid)
            return NotFound();

        ResidentialPlot originalPlot = p_unitOfWork.ResidentialPlots.GetElements().Find(x => x.ID == plot.ID);
        if (originalPlot is null)
            return NotFound();

        UploadImages(originalPlot, images);
        
        p_unitOfWork.ResidentialPlots.Update(originalPlot);
        p_unitOfWork.Save();

        TempData["success"] = StaticData.PLOT_UPDATED_MESSAGE;
        
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
        if (!id.HasValue)
            return RedirectToAction(nameof(Index));

        ResidentialPlot actualPlot = p_unitOfWork.ResidentialPlots.GetElements().Find(x => x.ID == id.Value);
        if (actualPlot is null)
            return NotFound();

        p_unitOfWork.ResidentialPlots.Remove(actualPlot);
        p_unitOfWork.Save();

        TempData["success"] = StaticData.PLOT_REMOVED_MESSAGE;
        return RedirectToAction(nameof(Index));
    }

    private void UploadImages(ResidentialPlot plot, List<IFormFile> images)
    {
        if (images.IsNullOrEmpty())
            return;

        foreach (var image in images)
        {
            if (image.Length <= 0)
                continue;

            string[] supportedTypes = ["image/jpeg", "image/png", "image/jpg"];
            if (!supportedTypes.Contains(image.ContentType))
                continue;

            string fileName = $"{Guid.NewGuid()}_{image.FileName}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

            using var stream = new FileStream(path, FileMode.Create);
            image.CopyTo(stream);

            Image imageModel = new Image
            {
                Path = $"/uploads/{fileName}",
                Title = fileName,
                ResidentialPlotID = plot.ID
            };
            
            p_unitOfWork.ImageRepository.Add(imageModel);
            p_unitOfWork.Save();
        }
    }

    [HttpPost]
    public IActionResult DeleteImage(int imageId, int plotId)
    {
        ResidentialPlot plot = p_unitOfWork.ResidentialPlots.GetElements().Find(x => x.ID == plotId);
        if (plot is null)
            return NotFound();
        
        Image image = p_unitOfWork.ImageRepository.GetElements().Find(x => x.ID == imageId);
        if (image is null)
            return NotFound();

        plot.Images.Remove(image);

        bool isImageUsedElsewhere = p_unitOfWork.ResidentialPlots.GetElements()
            .Any(x => x.Images.Contains(image));

        if (!isImageUsedElsewhere)
        {
            p_unitOfWork.ImageRepository.GetElements().Remove(image);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.Path?.TrimStart('/') ?? string.Empty);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        p_unitOfWork.ResidentialPlots.Update(plot);
        p_unitOfWork.Save();

        TempData["success"] = $"{StaticData.IMAGE_REMOVED} {plot.Name}";
        return RedirectToAction(nameof(Edit), new { id = plotId });
    }

    public IActionResult Details(int? id)
    {
        if (!id.HasValue)
            return NotFound();

        ResidentialPlot plot = p_unitOfWork.ResidentialPlots.GetElements().Find(x => x.ID == id.Value);
        if (plot == null)
            return NotFound();

        return View(plot);
    }
}