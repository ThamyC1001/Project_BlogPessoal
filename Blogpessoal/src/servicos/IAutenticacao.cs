using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using System.Threading.Tasks;

namespace Blogpessoal.src.servicos
{
    /// <summary>
    /// <para>Resumo: Interface Responsavel por representar ações de autenticação</para>
    /// <para>Criado por: Thamyres Cavalcanti</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/05/2022</para>
    /// </summary>
    public interface IAutenticacao
        { 
            string CodificarSenha(string senha); 
            Task CriarUsuarioSemDuplicarAsync(NovoUsuarioDTO dto);
            string GerarToken(UsuarioModelo usuario);
            Task<AutorizacaoDTO> PegarAutorizacaoAsync(AutenticarDTO dto);
        }
}

