using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using System.Collections.Generic;

namespace Blogpessoal.src.repositorios
{
    public interface ITema
    {
        void NovoTema(NovoTemaDTO Tema);
        void AtualizarTema(AtualizarTemaDTO tema);

        void DeletarTema(int id);
        TemaModelo PegarTemaPeloId(int id);
        List<TemaModelo> PegarTemaPelaDescricao(string Descricao);
    }
}
