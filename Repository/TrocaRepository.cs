using Fiap.Web.Donation1.Data;

namespace Fiap.Web.Donation1.Repository
{
    public class TrocaRepository
    {
        private readonly DataContext dataContext;
        public TrocaRepository(DataContext context) { this.dataContext = context; }
        public Guid Insert(Models.TrocaModel trocaModel)
        {
            dataContext.Trocas.Add(trocaModel);
            dataContext.SaveChanges();
            return trocaModel.TrocaId;
        }
    }
}
