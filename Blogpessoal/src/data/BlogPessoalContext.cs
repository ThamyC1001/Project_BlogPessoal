﻿using Blogpessoal.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace Blogpessoal.src.data
{
    /// <summary>
    /// <para>Resumo: Classe contexto, responsavel por carregar contexto e definir DbSets</para>
    /// <para>Criado por: Thamyres Cavalcanti </para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/05/2022</para>
    /// </summary>
    public class BlogPessoalContext : DbContext
    {
        public DbSet<UsuarioModelo> Usuarios { get; set; }
        public DbSet<TemaModelo> Temas { get; set; }
        public DbSet<PostagemModelo> Postagens { get; set; }

        public BlogPessoalContext(DbContextOptions<BlogPessoalContext> opt) : base(opt)
        {

        }
    }
}
