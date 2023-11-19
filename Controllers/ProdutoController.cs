using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;
using Fiap.Web.Donation1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation1.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly TipoProdutoRepository tipoProdutoRepository;

        private readonly IProdutoRepository produtoRepository;
        public ProdutoController(DataContext dataContext, IProdutoRepository _produtoRepository,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            produtoRepository = _produtoRepository;
            tipoProdutoRepository = new TipoProdutoRepository(dataContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (UsuarioId != 0)
            {
                var produtos = produtoRepository.FindAllWithTipoOrderByName(UsuarioId);
                return View(produtos);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult Novo()
        {
            ComboTipoProduto();

            return View(new ProdutoModel());
        }
        [HttpPost]
        public IActionResult Novo(ProdutoModel produtoModel)
        {
            if (produtoModel.Nome == null || produtoModel.Descricao == null || produtoModel.SugestaoTroca == null)
            {
                ComboTipoProduto();

                ViewBag.Mensagem = "Todos os campos são obrigatórios";
                return View(produtoModel);
            }
            else
            {
                produtoModel.UsuarioId = UsuarioId;
                produtoRepository.Insert(produtoModel);
                TempData["Mensagem"] = $"{produtoModel.Nome} cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Editar(int Id)
        {
            ComboTipoProduto();

            var produto = produtoRepository.FindById(Id);
            return View(produto);
        }
        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {
            if (string.IsNullOrEmpty(produtoModel.Nome))
            {
                ComboTipoProduto();
                ViewBag.Mensagem = "O campo nome é requerido";
                return View(produtoModel);
            }
            else
            {
                produtoModel.UsuarioId = UsuarioId;
                produtoRepository.Update(produtoModel);
                TempData["Mensagem"] = $"{produtoModel.Nome} alterado com sucesso!";
                return RedirectToAction("Index");
            }
        }
        private void ComboTipoProduto()
        {
            var tiposProdutos = tipoProdutoRepository.FindAll();
            var comboTipoProdutos = new SelectList(tiposProdutos, "TipoProdutoId", "NomeTipoProduto");
            ViewBag.TipoProdutos = comboTipoProdutos;
        }
    }
}
