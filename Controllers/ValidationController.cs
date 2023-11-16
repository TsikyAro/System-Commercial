using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System_Commercial.Models;
using Systeme_Commerciale.Models;
using System;
using System.IO;

namespace System_Commercial.Controllers
{
    [Route("Validation")]
    public class ValidationController : Controller
    {
        private readonly ILogger<ValidationController> _logger;

        public ValidationController(ILogger<ValidationController> logger)
        {
            _logger = logger;
        }

        [HttpGet ("direction")]
        public IActionResult direction(){
            Connexion con = new Connexion();
            Besoin b = new Besoin();
            Besoin [] besoins = b.GetAllDonnee(con);
            ViewBag.besoins = besoins;
            return View("ValidationDirection");
        }
        [HttpGet ("exportExel")]
        public IActionResult exportExel(){
            Connexion con = new Connexion();
            Besoin b = new Besoin();
            Besoin [] besoins = b.GetService(con);
            b.exel(besoins);
            ViewBag.besoins = besoins;
            return View();
        }
        
        [HttpGet ("service")]
        public IActionResult service(){
            Connexion con = new Connexion();
            Besoin b = new Besoin();
            Besoin [] besoins = b.GetService(con);
            ViewBag.besoins = besoins;
            return View("ServiceDachat");
        }

        [HttpGet ("besoin",Name ="iddepartement")]
        public IActionResult besoin(int iddepartement){
            Connexion con = new Connexion();
            Besoin b = new Besoin();
            Besoin [] besoins = b.GetDonnee(con,iddepartement);
            ViewBag.besoins = besoins;
            return View("ValidationResponsable");
        }
        
        [HttpGet ("validerResponsable",Name ="idDemande,idDepartement")]
        public IActionResult validerResponsable(int idDemande,int idDepartement){
            Connexion con = new Connexion();
            Demande d = new Demande();
            int etat = 1;
            d.Update(con,idDemande,etat);
            Besoin b = new Besoin();
            Besoin [] besoins = b.GetDonnee(con,idDepartement);
            ViewBag.besoins = besoins;
            return View("ValidationResponsable");
        }
        [HttpGet ("validerDirection",Name ="idDemande")]
        public IActionResult validerDirection(int idDemande){
            Connexion con = new Connexion();
            Demande d = new Demande();
            int etat = 2;
            d.Update(con,idDemande,etat);
            Besoin b = new Besoin();
            Besoin [] besoins = b.GetAllDonnee(con);
            ViewBag.besoins = besoins;
            return View("ValidationDirection");
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}