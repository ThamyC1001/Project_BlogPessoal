using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogpessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de tema</para>
    /// <para>Criado por: Thamyres Cavalcanti</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/05/2022</para>
    /// </summary>
    public interface ITema
    {
        Task NovoTemaAsync(NovoTemaDTO Tema);
        Task AtualizarTemaAsync(AtualizarTemaDTO tema);

        Task DeletarTemaAsync(int id);
        Task<TemaModelo> PegarTemaPeloIdAsync(int id);
        Task<List<TemaModelo>> PegarTemaPelaDescricaoAsync(string Descricao);
        Task<List<TemaModelo>> PegarTodosTemasAsync();

    }
}
