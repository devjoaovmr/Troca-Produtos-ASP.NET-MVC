using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation1.Models
{
    [Table("TipoProduto")]
    public class TipoProdutoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoProdutoId { get; set; }
        //[Column("NM_TIPO")]
        [Required(ErrorMessage = "O nome do tipo de produto é obrigatório.")]
        [StringLength(55)]
        [MinLength(3)]
        [Display(Name = "Nome do tipo de produto: ")]
        public string NomeTipoProduto { get; set; }
        public string? DescricaoDetalhada { get; set; }

        [NotMapped]
        public string? Token { get; set; }
    }
}
