using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Systeme_Commerciale.Models;

namespace Systeme_Commerciale.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    [HttpPost]
    public IActionResult Upload(IFormFile file){
        if (file != null && file.Length > 0){
            // Récupérer le nom du fichier
            string fileName = Path.GetFileName(file.FileName);

            // Sauvegarder le fichier dans un répertoire
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Connexion c = new Connexion();
            Person pers = new Person();
            pers.ImportDataFromExcel(filePath,c);

            // Traitez ici le fichier (par exemple, importation dans la base de données)

             Console.WriteLine("Fichier téléchargé avec succès.");
        }
        else{
             Console.WriteLine("Aucun fichier sélectionné.");
        }

        return View("Index"); // Vous pouvez rediriger ou retourner une vue avec un message de confirmation
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
