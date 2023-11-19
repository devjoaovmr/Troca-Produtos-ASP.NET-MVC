using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation1.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        //DataContext
        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext ctx)
        {
            dataContext = ctx;
        }
        //Métodos que simulam as operaçoes do banco

        //Listar Todos
        public IList<ProdutoModel> FindAll()
        {
            var produtos = dataContext.Produtos.ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }
        public IList<ProdutoModel> FindAllWithTipo()
        {
            var produtos = dataContext.Produtos.Include(p => p.TipoProduto).ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }
        public IList<ProdutoModel> FindByNome(string nome)
        {
            var produtos = dataContext.Produtos.Include(p => p.TipoProduto).Where(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }
        public IList<ProdutoModel> FindAllByDisponivel(bool disponivel)
        {
            var produtos = dataContext.Produtos.Include(p => p.TipoProduto).Where(p => p.Disponivel == disponivel).ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }
        public IList<ProdutoModel> FindAllDisponivelDoUsuario(bool disponivel, int usuarioId)
        {
            var produtos = dataContext.Produtos.Include(p => p.TipoProduto).Where(p => p.Disponivel == disponivel && p.UsuarioId == usuarioId).ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }
        public IList<ProdutoModel> FindAllDisponivelParaTroca(bool disponivel, int usuarioId)
        {
            var produtos = dataContext.Produtos.Include(p => p.TipoProduto).Where(p => p.Disponivel == disponivel && p.UsuarioId != usuarioId).ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }
        public IList<ProdutoModel> FindAllWithTipoAndUsuario()
        {
            var produtos = dataContext.Produtos.Include(p => p.TipoProduto).Include(p => p.Usuario).ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }
        public IList<ProdutoModel> FindAllWithTipoOrderByName(int usuarioId)
        {
            var produtos = dataContext.Produtos.Include(p => p.TipoProduto).Where(p => p.UsuarioId == usuarioId).OrderBy(p => p.Nome).ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }
        //Detalhe (Consulta por id)
        public ProdutoModel FindById(int id)
        {
            var produto = dataContext.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            return produto;
        }

        //Inserir
        public int Insert(ProdutoModel produtoModel)
        {
            produtoModel.DataCadastro = DateTime.Now;
            dataContext.Produtos.Add(produtoModel);
            dataContext.SaveChanges();
            return produtoModel.ProdutoId;
        }

        //Alterar
        public void Update(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Update(produtoModel);
            dataContext.SaveChanges();
        }

        //Excluir
        public void Delete(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Remove(produtoModel);
            dataContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var produtoModel = new ProdutoModel()
            {
                ProdutoId = id,
            };
            Delete(produtoModel);
        }
    }
}
