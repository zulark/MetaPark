using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly SistemaContext _context;

        public HomeController(SistemaContext context)
        {
            _context = context;
        }

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
        /*
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
        }*/

        public IActionResult BuscarUsuario()
        {
            return RedirectToAction("Entrar");
        }

        public IActionResult Entrar(string Login, string Senha)
        {
            
            Usuario usuarioEncontrado = new Usuario();
            usuarioEncontrado = _context.Usuario.FirstOrDefault(a => Login == a.Login);

            if(usuarioEncontrado == null)
            {
                return View("Index");
            }
            for (int i = 0; i < _context.Usuario.Count(); i++)
            {
                if(_context.Usuario.ToList()[i].Login == Login && _context.Usuario.ToList()[i].Senha == Senha)
                {
                    usuarioEncontrado = _context.Usuario.ToList()[i];
                    break;
                }              
            }
            return View("Index");
        }

        public IActionResult Listar()
        {
            return View("Listar",_context.Usuario.ToList());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}