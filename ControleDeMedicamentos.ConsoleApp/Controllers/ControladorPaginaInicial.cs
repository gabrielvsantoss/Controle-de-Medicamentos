using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("/")]
    public class ControladorPaginaInicial : Controller
    {
        public IActionResult PaginaInicial()
        {
            // Colocando o system pro IO o arquivo entende qual file é 
            // IO pe de input e output
            string conteudo = System.IO.File.ReadAllText("Compartilhado/Html/PaginaInicial.html");
            return Content(conteudo, "text/html");
        }
    }
}
