using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        public void Cadastrar_CadastrarUsuario(Usuario usuario)
        {
            usuario.Id = BancoDados.usuarios.Count();
            BancoDados.usuarios.Add(usuario);
            Response.Redirect("Login");
        }

        public IActionResult Listar()
        {
            return View("Listar", BancoDados.usuarios);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}