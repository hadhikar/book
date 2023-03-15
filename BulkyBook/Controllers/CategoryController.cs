using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyBook.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }


    // GET: /<controller>/
    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _db.Categories;
        return View(objCategoryList);
    }

    //Get
    public IActionResult Create()
    {

        return View();
    }

    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //Get
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDB = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.CategoryId == id);

        if (categoryFromDB == null)
        {
            return NotFound();
        }


        return View(categoryFromDB);
    }

    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //Get
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDB = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.CategoryId == id);

        if (categoryFromDB == null)
        {
            return NotFound();
        }


        return View(categoryFromDB);
    }

    //Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(Category obj)
    {
        if (obj != null)
        {
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        return NotFound();
    }

}

