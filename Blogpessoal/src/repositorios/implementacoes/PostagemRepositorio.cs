using Blogpessoal.src.data;
using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Blogpessoal.src.repositorios.implementacoes
{
    public class PostagemRepositorio : IPostagem
    {
        #region Atributos
        private readonly BlogPessoalContext _context;
        #endregion Atributos
        
        #region Construtores
        public PostagemRepositorio(BlogPessoalContext context) 
        {
           _context = context;
        }
        #endregion Construtores 
        
        #region Métodos
             
        public void AtualizarPostagem(AtualizarPostagemDTO postagem)
        {
            var postagemExistente = PegarPostagemPeloId(postagem.Id);
            postagemExistente.Titulo = postagem.Titulo;
            postagemExistente.Descricao = postagem.Descricao;
            postagemExistente.Foto = postagem.Foto;
            postagemExistente.Tema = _context.Temas.FirstOrDefault(t => t.Descricao == postagem.DescricaoTema);
            _context.Postagens.Update(postagemExistente);
            _context.SaveChanges();
        }

        public void DeletarPostagem(int id)
        {
            _context.Postagens.Remove(PegarPostagemPeloId(id));
            _context.SaveChanges();
        }

        public void NovaPostagem(NovaPostagemDTO postagem)
        {
            _context.Postagens.Add(new PostagemModelo 
            { Titulo = postagem.Titulo, 
              Descricao = postagem.Descricao,
              Foto = postagem.Foto,
              Criador = _context.Usuarios.FirstOrDefault(u => u.Email == postagem.EmailCriador),
              Tema = _context.Temas.FirstOrDefault(t => t.Descricao == postagem.DescricaoTema)

            });
            _context.SaveChanges();
        }

        public PostagemModelo PegarPostagemPeloId(int id)
        {
           return _context.Postagens.FirstOrDefault(p => p.Id == id); 
        }

        public List<PostagemModelo> PegarPostagensPorPesquisa(string titulo, string descricaoTema, string nomeCriador)
        {
            switch (titulo, descricaoTema, nomeCriador)
            {
                case (null, null, null): return PegarTodasPostagens();
                case (null, null, _):
                return _context.Postagens.Include(p => p.Tema)                                              
                .Include(p => p.Criador)
                .Where(p => p.Criador.Nome.Contains(nomeCriador))
                .ToList();

                case (null, _, null): return _context.Postagens.Include(p => p.Tema)
                .Include(p => p.Criador)
                .Where(p => p.Tema.Descricao.Contains(descricaoTema))
                .ToList();
             
                case (_, null, null): return _context.Postagens.Include(p => p.Tema)
                .Include(p => p.Criador)
                .Where(p => p.Titulo.Contains(titulo))
                .ToList();

                case (_, _, null): return _context.Postagens.Include(p => p.Tema)
               .Include(p => p.Criador)
               .Where(p => p.Titulo.Contains(titulo) & p.Tema.Descricao.Contains(descricaoTema))
               .ToList();

                case (null, _, _): return _context.Postagens.Include(p => p.Tema)
                .Include(p => p.Criador)
                .Where(p => p.Tema.Descricao.Contains(descricaoTema) & p.Criador.Nome.Contains(nomeCriador))
                .ToList();

                case (_, null, _): return _context.Postagens.Include(p => p.Tema)
                .Include(p => p.Criador)
                .Where(p => p.Titulo.Contains(titulo) & p.Criador.Nome.Contains(nomeCriador))
                .ToList();

                case (_, _, _): return _context.Postagens.Include(p => p.Tema)
                .Include(p => p.Criador)
                .Where(p => p.Titulo.Contains(titulo) | p.Tema.Descricao.Contains(descricaoTema) | p.Criador.Nome.Contains(nomeCriador))
                .ToList();
            }
        }

        public List<PostagemModelo> PegarTodasPostagens()
        {
            return _context.Postagens.ToList();
        }
       
        #endregion Métodos
    }

}
