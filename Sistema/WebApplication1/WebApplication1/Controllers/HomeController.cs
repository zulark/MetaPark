using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext _context;

        public HomeController(DBContext context)
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

        public IActionResult Entrar(Usuario usuario)
        {
            /*
            Usuario usuarioEncontrado = new Usuario();
            usuarioEncontrado = _context.Usuario.FirstOrDefault(a => usuario.Login == a.Login && usuario.Password == a.Password);
            if(usuarioEncontrado == null)
            {
                return View("Index");
            }
            for (int i = 0; i < Usuario.listagem.Count; i++)
            {
                if(Usuario.listagem[i].Login == login && Usuario.listagem[i].Password == senha)
                {
                    usuarioEncontrado = Usuario.listagem[i];
                    break;
                }              
            }
            if(usuarioEncontrado == null)
            {
                return View("Login");
            }*/
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