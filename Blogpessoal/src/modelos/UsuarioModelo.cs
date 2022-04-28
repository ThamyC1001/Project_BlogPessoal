﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Blogpessoal.src.modelos
{
   [Table("tb_usuario")]
    public class UsuarioModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Senha { get; set; }

        public string Foto { get; set; }

        [JsonIgnore]
        public List<PostagemModelo> MinhasPostagens { get; set; }


    }
}