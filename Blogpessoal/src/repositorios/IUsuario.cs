using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogpessoal.src.repositorios
{

    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de usuario</para>
    /// <para>Criado por: Thamyres Cavalcanti </para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/05/2022</para>
    /// </summary>
    public interface IUsuario 
    {
        Task NovoUsuarioAsync(NovoUsuarioDTO Usuario);
       Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario);

       Task DeletarUsuarioAsync(int id);
       Task<UsuarioModelo> PegarUsuarioPeloIdAsync(int id);
       Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email);
       Task<List<UsuarioModelo>> PegarUsuarioPeloNomeAsync(string nome);
    }
}
