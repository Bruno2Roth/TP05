using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05.Models;

namespace TP05.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Identificarse(string nj)
    {
        Escape partida = new Escape(nj);
        HttpContext.Session.SetString("juego" , Objeto.ObjectToString(partida));
        partida.SumarSala();
        return RedirectToAction("JugarSala");
    }
    public IActionResult JugarSala()
    {
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        if(partida == null)
        {
            return View("Sala0");   
        }else
        {
            ViewBag.Nombre = partida.nombreJugador;
            ViewBag.pista = partida.pistas[partida.salaActual];
            ViewBag.sala = partida.salaActual;
            return View("Sala" + partida.salaActual);
        }
    }
    [HttpGet]
    public IActionResult PasarSala(string contraseña)
    {
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        if(partida.Contraseña(contraseña))
        {
            partida.SumarSala();
            HttpContext.Session.SetString("juego" , Objeto.ObjectToString(partida));
        }
        return RedirectToAction("JugarSala");
    }
    /*[HttpGet]
    public IActionResult Sala1(string secuencia1, string secuencia2, string secuencia3, string secuencia4, string secuencia5, string contraseña1){
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        ViewBag.que = partida.salaActual;
        if(partida.salaActual == 1)
        {
            ViewBag.secuencia1 = partida.Contraseña(secuencia1, partida.secuencias[0]);
            ViewBag.secuencia2 = partida.Contraseña(secuencia2, partida.secuencias[0]);
            ViewBag.secuencia3 = partida.Contraseña(secuencia3, partida.secuencias[0]);
            ViewBag.secuencia4 = partida.Contraseña(secuencia4, partida.secuencias[0]);
            ViewBag.secuencia5 = partida.Contraseña(secuencia5, partida.secuencias[0]);
            if(partida.Contraseña(partida.respuestas[1], contraseña1))
            {
                partida.SumarSala();
                return View("Sala2");
            }
        }
        return View("Sala1");
    }*/
    
}
