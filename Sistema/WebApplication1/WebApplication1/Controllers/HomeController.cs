﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult CadastrarVeiculo(int idUsuario)
        {
            ViewBag.IdUsuario = idUsuario;
            return View("CadastrarVeiculo");
        }

        public IActionResult Cadastrar_CadastrarVeiculo(Veiculo veiculo)
        {
            //veiculo.idUsuario = 
            veiculo.idVeiculo = _context.Veiculo.Count();
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

        public IActionResult Voltar(int idUsuario)
        {
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}