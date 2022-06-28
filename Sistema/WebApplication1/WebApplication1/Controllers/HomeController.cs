using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly EstacionamentoContext _context;

        public HomeController(EstacionamentoContext context)
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

        public IActionResult CadastrarVeiculo()
        {
            return View();
        }

        public IActionResult Cadastrar_CadastrarVeiculo(Veiculo veiculo)
        {
            //veiculo.idUsuario = 
            veiculo.idVeiculo = _context.Veiculo.Count();
            veiculo.idUsuario = (int)HttpContext.Session.GetInt32("SessionIdUser");
            _context.Veiculo.Add(veiculo);
            _context.SaveChanges();
            return RedirectToAction("Voltar", veiculo.idUsuario);
        }

        public IActionResult Selecionar(int idVeiculo)
        {
            Veiculo veiculoEncontrado = new Veiculo();
            veiculoEncontrado = _context.Veiculo.FirstOrDefault(a => idVeiculo == a.idVeiculo);
            if (veiculoEncontrado == null)
            {
                return View("Erro", "Erro no processamento");
            }
            Acesso acesso = new Acesso();
            acesso.idUsuario = veiculoEncontrado.idUsuario;
            acesso.idVeiculo = veiculoEncontrado.idVeiculo;
            acesso.idAcesso = _context.Acesso.Count()+1;
            ViewBag.idUsuario = acesso.idUsuario;
            acesso.Entrada = DateTime.Now;
            acesso.Saida = DateTime.Parse("1900/1/1 00:00");

            _context.Acesso.Add(acesso);
            _context.SaveChanges();
            return View("AcessoConfirmado");
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

        public IActionResult BuscaAcesso(int idUsuario)
        {
            Acesso acessoEncontrado = new Acesso();
            DateTime saida = DateTime.Parse("1900/1/1 00:00");
            acessoEncontrado = _context.Acesso.FirstOrDefault(a => a.idUsuario == idUsuario && a.Saida == saida);
            if(acessoEncontrado == null)
            {
                return View("Erro", "Erro no processamento");
            }
            Acesso acesso = new Acesso();
            acesso = acessoEncontrado;
            acesso.Saida = DateTime.Now;
            _context.Entry(acessoEncontrado).CurrentValues.SetValues(acesso);
            _context.SaveChanges();
            double tempoPermanencia = acesso.Saida.Subtract(acessoEncontrado.Entrada).TotalMinutes;
            ViewBag.TempoPermanencia = TimeSpan.FromMinutes(Convert.ToDouble(tempoPermanencia)).ToString(@"hh\:mm\:ss");
            ViewBag.ValorAPagar = ((int)tempoPermanencia / 10 * 2).ToString("C");
            return View("ConfirmarSaida");
        }

        public IActionResult HomeCarteira(int idUsuario)
        {
            decimal saldo;
            try
            {
                saldo = GetSaldo(idUsuario);
                ViewBag.idUsuario = idUsuario;
                ViewBag.Saldo = saldo.ToString("C");

            return View();

            }catch(Exception e)
            {
                e.ToString();
                return View("HomeCarteira");
            }

        }

        public IActionResult Voltar()
        {
            int idUsuario = (int)HttpContext.Session.GetInt32("SessionIdUser");
            Veiculo veiculoEncontrado = new Veiculo();
            veiculoEncontrado = _context.Veiculo.FirstOrDefault(a => idUsuario == a.idUsuario);
            if(veiculoEncontrado == null)
            {
                return View("Erro", "Erro no processamento, realize o login novamente");
            }

            List<Veiculo> veiculos = _context.Veiculo.ToList();
            List<Veiculo> veiculosEncontrados = new List<Veiculo>();
            for (int i = 0; i < _context.Veiculo.Count(); i++)
            {
                if (veiculos[i].idUsuario == idUsuario)
                {
                    veiculosEncontrados.Add(veiculos[i]);
                }
            }
            ViewBag.Name = HttpContext.Session.GetString("SessionName");
            ViewBag.Saldo = GetSaldo((int)HttpContext.Session.GetInt32("SessionIdUser")).ToString("C");
            //ViewBag.Ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1];
            //.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            return View("Entrar", veiculosEncontrados);
        }

        public IActionResult Entrar(Usuario usuario)
        {            
            Usuario usuarioEncontrado = new Usuario();
            usuarioEncontrado = _context.Usuario.FirstOrDefault(a => usuario.Login == a.Login && usuario.Senha == a.Senha) ;
            if(usuarioEncontrado != null)
            {
                List<Veiculo> veiculos = _context.Veiculo.ToList();
                List<Veiculo> veiculosEncontrados = new List<Veiculo>();
                for (int i = 0; i < _context.Veiculo.Count(); i++)
                {
                    if(veiculos[i].idUsuario == usuarioEncontrado.idUsuario)
                    {
                        veiculosEncontrados.Add(veiculos[i]);
                    }
                }
                //ViewBag.Ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1];
                //.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

                HttpContext.Session.SetString("SessionName", usuarioEncontrado.Nome);
                HttpContext.Session.SetInt32("SessionIdUser", usuarioEncontrado.idUsuario);
                ViewBag.Name = usuarioEncontrado.Nome;
                ViewBag.Saldo = GetSaldo(usuarioEncontrado.idUsuario).ToString("C");
                return View("Entrar", veiculosEncontrados);
            }
            if(usuarioEncontrado == null)
            {
                return View("Login");
            }
            return View("Index");
        }

        public IActionResult Listar()
        {
            return View("Listar",_context.Usuario.ToList());
        }

        public IActionResult AdicionarSaldo(decimal valor)
        {
            if(valor > 0)
            {
                decimal saldo = Convert.ToDecimal(_context.Entry("Usuario").Property("Saldo").CurrentValue);
                Usuario usuarioEncontrado = new Usuario();
                usuarioEncontrado = _context.Usuario.FirstOrDefault(a => HttpContext.Session.GetInt32("SessionIdUser") == a.idUsuario);

                Usuario usuario = new Usuario();
                usuario = usuarioEncontrado;
                usuario.Saldo += valor;

                _context.Entry(usuarioEncontrado).CurrentValues.SetValues(usuario);
                
                _context.SaveChanges();
            }
            return RedirectToAction("Voltar");
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        public decimal GetSaldo(int idUsuario)
        {
            Usuario usuarioEncontrado = _context.Usuario.FirstOrDefault(a => a.idUsuario == idUsuario);
            if (usuarioEncontrado == null)
            {
                throw new Exception();
            }
            return Convert.ToDecimal(usuarioEncontrado.Saldo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}