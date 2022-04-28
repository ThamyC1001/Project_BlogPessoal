using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogpessoal.src.modelos
{
    [Table("tb_postagens")]
    public class PostagemModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Titulo { get; set; }

        [Required, StringLength(150)]
        public string Descricao { get; set; }

        public string Foto { get; set; }

        [ForeignKey("fk_usuario")]
        public UsuarioModelo Criador { get; set; }

        [ForeignKey("fk_tema")]
        public TemaModelo Tema { get; set; }

    }
}
