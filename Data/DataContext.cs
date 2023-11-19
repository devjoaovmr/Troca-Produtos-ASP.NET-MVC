using Fiap.Web.Donation1.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation1.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TipoProdutoModel> TipoProdutos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<TrocaModel> Trocas { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
