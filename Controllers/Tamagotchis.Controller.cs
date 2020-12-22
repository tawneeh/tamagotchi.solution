using Microsoft.AspNetCore.Mvc;
using Game.Models;
using System.Collections.Generic;

namespace Game.Controllers
{
  public class TamagotchisController : Controller
  {

    [HttpGet("/tamagotchi")]
    public ActionResult Index()
    {
      List<Tamagotchi> all = Tamagotchi.GetAll();
      return View(all);
    }

    [HttpGet("/tamagotchi/new")]
    public ActionResult New() 
    { 
      return View();
    }

    [HttpPost("/tamagotchi")]
    public ActionResult Create(string name) // change this argument?? int id
    { 
      Tamagotchi myTamagotchi = new Tamagotchi(name);
      myTamagotchi.Save();
      return RedirectToAction("Index");
    }

    [HttpPost("/tamagotchi/show")]
    public ActionResult Feed()
    { 
      return RedirectToAction("Index");
    }

    [HttpPost("/tamagotchi/show")]
    public ActionResult Sleep()
    { 
      return View();
    }

    [HttpPost("/tamagotchi/show")]
    public ActionResult Play()
    { 
      return View();
    }

    [HttpGet("/tamagotchi/{id}")]
    public ActionResult Show(int id)
    {
      Tamagotchi foundTamagotchi = Tamagotchi.Find(id);
      return View(foundTamagotchi);
    }
  }
}