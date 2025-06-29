using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MicroVShop.Web.Models;
using MicroVShop.Web.Services.Interfaces;

namespace MicroVShop.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductsController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
    {
        var result = await _productService.GetAllAsync();

        if (!result.Any())
            return View("Error");

        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _productService.CreateAsync(model);

            if (result != null)
                return RedirectToAction(nameof(Index));
        }
        else
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
            return View("Error");

        ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _productService.UpdateAsync(model);

            if (result != false)
                return RedirectToAction(nameof(Index));
        }
        else
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
            return View("Error");

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _productService.DeleteAsync(id);

        if (result == false)
            return View("Error");

        return RedirectToAction(nameof(Index));
    }
}