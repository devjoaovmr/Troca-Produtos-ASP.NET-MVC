using Fiap.Web.Donation1.Models;

namespace Fiap.Web.Donation1.Repository
{
    public interface IProdutoRepository
    {
        public IList<ProdutoModel> FindAll();
        public IList<ProdutoModel> FindAllWithTipo();
        public IList<ProdutoModel> FindByNome(string nome);
        public IList<ProdutoModel> FindAllByDisponivel(bool disponivel);
        public IList<ProdutoModel> FindAllDisponivelDoUsuario(bool disponivel, int usuarioId);
        public IList<ProdutoModel> FindAllDisponivelParaTroca(bool disponivel, int usuarioId);
        public IList<ProdutoModel> FindAllWithTipoAndUsuario();
        public IList<ProdutoModel> FindAllWithTipoOrderByName(int usuarioId);
        //Detalhe (Consulta por id)
        public ProdutoModel FindById(int id);

        //Inserir
        public int Insert(ProdutoModel produtoModel);

        //Alterar
        public void Update(ProdutoModel produtoModel);

        //Excluir
        public void Delete(ProdutoModel produtoModel);
        public void Delete(int id);
    }
}

