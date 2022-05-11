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

        public IActionResult Recover()
        {
            return View();
        }

        public void Cadastrar_CadastrarUsuario(Usuario usuario)
        {
            if (usuario.Name == null)
            {
                Response.Redirect("CadastrarUsuario");
            }
            else
            {
                usuario.Id = Usuario.listagem.Count();
                Usuario.listagem.Add(usuario);
                Response.Redirect("Login");
            }
        }

        public IActionResult Entrar()
        {
            /*
            for (int i = 0; i < Usuario.listagem.Count; i++)
            {
                if (Usuario.listagem[i].Login == usuario.Login)
                {
                    Usuario.listagem[i] = usuario;
                    return View("Entrar", usuario);

                }                
            }*/
            return View("Index");
        }

        public IActionResult Listar()
        {
            return View("Listar", Usuario.listagem);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}