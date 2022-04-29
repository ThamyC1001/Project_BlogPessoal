using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using System.Collections.Generic;

namespace Blogpessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de postagem</para>
    /// <para>Criado por: Thamyres Cavalcanti </para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public interface IPostagem
    {
        void NovaPostagem(NovaPostagemDTO postagem);
        void AtualizarPostagem(AtualizarPostagemDTO postagem);
        void DeletarPostagem(int id );
        PostagemModelo PegarPostagemPeloId(int id);
        List<PostagemModelo> PegarTodasPostagens(string titulo);
        List<PostagemModelo> PegarPostagensPeloTitulo();
        List<PostagemModelo> PegarPostagensPelaDescricao(string descricao);

    }
}
