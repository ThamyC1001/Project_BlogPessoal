using Blogpessoal.src.data;
using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using System.Collections.Generic;
using System.Linq;

namespace Blogpessoal.src.repositorios.implementacoes
{
    public class TemaRepositorio : ITema
    {
        #region Atributos

        private readonly BlogPessoalContext _context;

        #endregion Atributos

        #region Construtores

        public TemaRepositorio(BlogPessoalContext context)
        {
            _context = context;
        }

        #endregion Construtores

        #region Metodos
        public void AtualizarTema(AtualizarTemaDTO tema)
        {
            var temaExistente = PegarTemaPeloId(tema.Id);
            temaExistente.Descricao = tema.Descricao;
        }

        public void DeletarTema(int id)
        {
            _context.Temas.Remove(PegarTemaPeloId(id));
            _context.SaveChanges();
        }

        public void NovoTema(NovoTemaDTO tema)
        {
            _context.Temas.Add(new TemaModelo
            {
                Descricao = tema.Descricao
               
            });
        }
        public TemaModelo PegarTemaPeloId(int id)
        {
            return _context.Temas.FirstOrDefault(t => t.Id == id);
        }
        public List<TemaModelo> PegarTemaPelaDescricao(string descricao)
        {
            return _context.Temas
                .Where(t => t.Descricao.Contains(descricao))
                .ToList();            
        }
        public List<TemaModelo> PegarTodosTemas()
        {
            return _context.Temas
                .ToList();
        }

        #endregion Metodos
    }
}
