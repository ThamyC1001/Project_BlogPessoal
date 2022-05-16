using Blogpessoal.src.data;
using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogpessoal.src.repositorios.implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar ITema</para>
    /// <para>Criado por: Thamyres Cavalcanti</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/05/2022</para>
    /// </summary>
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
        /// <summary>
        /// <para>Resumo: Método assíncrono para atualizar um tema</para>
        /// </summary>
        /// <param name="tema">AtualizarTemaDTO</param>
        public async Task AtualizarTemaAsync(AtualizarTemaDTO tema)
        {
            var temaExistente = await PegarTemaPeloIdAsync(tema.Id);
            temaExistente.Descricao = tema.Descricao;
            _context.Temas.Update(temaExistente);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para deletar um tema</para>
        /// </summary>
        /// <param name="id">Id do tema</param>
        public async Task DeletarTemaAsync(int id)
        {
            _context.Temas.Remove(await PegarTemaPeloIdAsync(id));
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo tema</para>
        /// </summary>
        /// <param name="tema">NovoTemaDTO</param>
        public async Task NovoTemaAsync(NovoTemaDTO tema)
        {
           await _context.Temas.AddAsync(new TemaModelo
            {
                Descricao = tema.Descricao
               
            });

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar um tema pelo Id</para>
        /// </summary>
        /// <param name="id">Id do tema</param>
        /// <return>TemaModelo</return>
        public async Task<TemaModelo> PegarTemaPeloIdAsync(int id)
        {
            return await _context.Temas.FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar temas pela descrição</para>
        /// </summary>
        /// <param name="descricao">Descrição do tema</param>
        /// <return>Lista TemaModelo</return>
        public async Task<List<TemaModelo>> PegarTemaPelaDescricaoAsync(string descricao)
        {
            return await _context.Temas
                .Where(t => t.Descricao.Contains(descricao))
                .ToListAsync();            
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar todos temas</para>
        /// </summary>
        /// <return>Lista TemaModelo</return>
        public async Task<List<TemaModelo>> PegarTodosTemasAsync()
        {
            return await _context.Temas.ToListAsync();
        }

        #endregion Metodos
    }
}
