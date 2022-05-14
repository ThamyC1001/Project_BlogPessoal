using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using System.Threading.Tasks;
using static Blogpessoal.src.dtos.AutenticacaoDTO;

namespace Blogpessoal.src.servicos
{
        public interface IAutenticacao
        { 
            string CodificarSenha(string senha); 
            Task CriarUsuarioSemDuplicarAsync(NovoUsuarioDTO usuario);
            string GerarToken(UsuarioModelo usuario);
            Task<AutorizacaoDTO> PegarAutorizacaoAsync(AutenticarDTO autenticacao);
        }
}

