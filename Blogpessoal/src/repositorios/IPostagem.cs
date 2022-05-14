using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogpessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de postagem</para>
    /// <para>Criado por: Thamyres Cavalcanti </para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/54/2022</para>
    /// </summary>
    public interface IPostagem
    {
        Task NovaPostagemAsync(NovaPostagemDTO postagem);
        Task AtualizarPostagemAsync(AtualizarPostagemDTO postagem);
        Task DeletarPostagemAsync(int id );
        Task<PostagemModelo> PegarPostagemPeloIdAsync(int id);
        Task<List<PostagemModelo>> PegarTodasPostagensAsync();
        Task<List<PostagemModelo>> PegarPostagensPorPesquisaAsync(string titulo, string descricaoTema, string nomeCriador);
    }
}
