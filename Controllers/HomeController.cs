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
    public IActionResult Historia()
    {
        return View();
    }
    public IActionResult Creditos()
    {
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        if (partida != null)
        {
            ViewBag.creadores = partida.creadores;
        }
        return View();
    }
    [HttpGet]
   public IActionResult Identificarse(string nj)
    {
        if (nj != null)
        {
            Escape partida = new Escape(nj);
            HttpContext.Session.SetString("juego", Objeto.ObjectToString(partida));
        }
        return RedirectToAction("JugarSala");
    }
    public IActionResult JugarSala()
    {
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        if (partida == null)
        {
            return View("Sala0");
        }
        else
        {
            ViewBag.Nombre = partida.nombreJugador;
            ViewBag.sala = partida.salaActual;
            ViewBag.adivinadas = partida.SecuenciasAdivinadas;
            if (partida.salaActual == 5)
            {
                ViewBag.qrs = partida.qrs;
            }
            if (partida.salaActual == 2)
            {
                return RedirectToAction("JugarWordle");
            }
            else
            {
                if (partida.salaActual == 4)
                {
                    //return RedirectToAction("PasarSala", new { contraseña = "c" });
                    ViewBag.secuencia = partida.simon.respuestas;
                    ViewBag.numero = partida.simon.contador;
                    return RedirectToAction("JugarSimon");
                }
            }
            return View("Sala" + partida.salaActual);
        }
    }
    public IActionResult JugarWordle()
    {
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        if (partida.salaActual == 2)
        {
            ViewBag.intentos = partida.wordle.intentos;
            return View("Sala2");
        }
        else
        {
            return RedirectToAction("JugarSala");
        }
    }

    [HttpPost]
    public IActionResult ValidarWordle(string intento)
    {
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        if (partida.salaActual == 2)
        {
            partida.wordle.DevolverResultado(intento);
            HttpContext.Session.SetString("juego", Objeto.ObjectToString(partida));
            if(partida.wordle.intentos[partida.wordle.intentos.Count() - 1].correctas == 5)
            {
                return RedirectToAction("PasarSala", new { contraseña = "a" });
            }
            if (partida.wordle.intentos.Count > 15)
            {
                partida.ReiniciarWordle();
                HttpContext.Session.SetString("juego", Objeto.ObjectToString(partida));
                return RedirectToAction("JugarSala");
            }
            else
            {
                ViewBag.intentos = partida.wordle.intentos;
                return View("Sala2");
            }
        }
        else
        {
            return RedirectToAction("JugarSala");
        }
    }

    public IActionResult JugarSimon()
    {
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        if (partida.salaActual == 4)
        {
            ViewBag.secuencia = partida.simon.respuestas;
            ViewBag.numero = partida.simon.contador;
            return View("Sala4");
        }
        else
        {
            return RedirectToAction("JugarSala");
        }
    }

    [HttpPost]
    public IActionResult ValidarSimon(string intento)
    {
        
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
                
        if (partida.salaActual == 4)
        {
            if (partida.simon.ValidarContraseña(intento))
            {
                if (partida.simon.contador == partida.simon.meta)
                {
                    return RedirectToAction("PasarSala", new { contraseña = "c" });
                }
                else
                {
                    return RedirectToAction("JugarSimon");
                }
            }
            else
            {
                return RedirectToAction("JugarSimon");
            }
        }
        else
        {
            return RedirectToAction("JugarSala");
        }
    }
    public IActionResult IrPista()
    {
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        if (partida.pistas[partida.salaActual] != null)
        {
            ViewBag.pista = partida.pistas[partida.salaActual];
            return View("Pista");
        }
        else
        {
            return RedirectToAction("JugarSala");
        }
    }
    [HttpGet]
    public IActionResult PasarSala(string contraseña)
    {
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        if (partida.Contraseña(contraseña.ToLower()))
        {
            HttpContext.Session.SetString("juego", Objeto.ObjectToString(partida));
        }
        return RedirectToAction("JugarSala");
    }
    [HttpPost]
    public IActionResult ValidarSecuencia(string secuencia, int num)
    {
        Escape partida = Objeto.StringToObject<Escape>(HttpContext.Session.GetString("juego"));
        partida.IntentarSecuencia(num, secuencia);
        HttpContext.Session.SetString("juego", Objeto.ObjectToString(partida));
        ViewBag.adivinadas = partida.SecuenciasAdivinadas;
        return View("Sala1");
    }
}
