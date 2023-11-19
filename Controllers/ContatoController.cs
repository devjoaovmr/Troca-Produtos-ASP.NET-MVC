using Fiap.Web.Donation1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace Fiap.Web.Donation1.Controllers
{

    public class ContatoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Gravar(ContatoModel contatoModel) 
        {            
            string mensagem = string.Empty;
            if (contatoModel.Email.Equals("JV@JV.JV"))
            {
                mensagem = $"Contato do usuario {contatoModel.Nome} não registrado, pois já existe um contato aberto na plataforma com o mesmo email";
            }
            else
            {
                mensagem = "Contato registrado com sucesso";
            }            
            ViewBag.Mensagem = mensagem;

            return View("Sucesso");
        }       
        
    }
}
