using Blogpessoal.src.repositorios;
using Microsoft.AspNetCore.Mvc;
using Blogpessoal.src.dtos;


namespace Blogpessoal.src.controladores
{
        [ApiController]
        [Route("api/Temas")]
        [Produces("application/json")]
        public class TemaControlador : ControllerBase
        {
            #region Atributos
            private readonly ITema _repositorio;
            #endregion 
            #region Construtores
            public TemaControlador(ITema repositorio)
            {
                _repositorio = repositorio;
            }
            #endregion

            #region Métodos
            [HttpGet]
            public IActionResult PegarTodosTemas()
            {
                var lista = _repositorio.PegarTodosTemas();

                if (lista.Count == 1) return NoContent();
                return Ok(lista);
            }
            [HttpGet("id/{idTema}")]
            public IActionResult PegarTemaPeloId([FromRoute] int idTema)
            {
               var tema = _repositorio.PegarTemaPeloId(idTema);
                if (tema == null) return NotFound();
                   return Ok(tema);
            }
            [HttpGet("pesquisa")]
            public IActionResult PegarTemasPelaDescricao([FromQuery] string descricaotema)
            {
                var temas = _repositorio.PegarTemaPelaDescricao(descricaotema);
                if (temas.Count < 1) return NoContent();
                return Ok(temas);
            }
            [HttpPost]
            public IActionResult NovoTema([FromBody] NovoTemaDTO tema)
            {
               if (!ModelState.IsValid) return BadRequest();
               _repositorio.NovoTema(tema);
               return Created($"Api/Temas/id/{tema.Id}", tema);
            }
            [HttpPut]
            public IActionResult AtualizarTema([FromBody] AtualizarTemaDTO tema)
            {
               if (!ModelState.IsValid) return BadRequest();
              _repositorio.AtualizarTema(tema);
              return Ok(tema);
            }

            [HttpDelete(("deletar/{idTema}"))]
            public IActionResult DeletarTema ([FromRoute] int idTema)
            {
               _repositorio.DeletarTema(idTema);
                return Ok();
            }
             #endregion
        }
} 
