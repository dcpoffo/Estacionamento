using System;
using System.Threading.Tasks;
using backend.data;
using backend.models;
using backend.services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
     [ApiController]
     [Route("[controller]")]

     public class PrecoController : ControllerBase
     {
          private readonly IRepository _repositorio;

          public PrecoController(IRepository repositorio)
          {
               _repositorio = repositorio;
          }

          [HttpGet]
          public async Task<IActionResult> GetAll()
          {
               try
               {
                    var result = await _repositorio.GetAllPrecosAsync();
                    return Ok(result);
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao obter Preços: \n{ex.Message}");
               }
          }

          [HttpGet("{precoId}")]
          public async Task<IActionResult> GetById(int precoId)
          {
               try
               {
                    var result = await _repositorio.GetPrecoAsyncById(precoId);
                    return Ok(result);
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao obter Preço: \n{ex.Message}");
               }
          }

          [HttpPost]
          public async Task<IActionResult> Post(TabelaPreco preco)
          {
               var listaTodosPrecos = await _repositorio.GetAllPrecosAsync();
               // verificar se datas ja fazem parte de uma vigência
               VerificaSeNovaVigenciaJaExisteServico verificaDatas = new VerificaSeNovaVigenciaJaExisteServico();

               try
               {
                    if (!verificaDatas.VerificaSeNovaVigenciaJaExiste(preco, listaTodosPrecos))
                    {
                         _repositorio.Add(preco);
                         if (await _repositorio.SaveChangesAsync())
                         {
                              return Ok(preco);
                         }                         
                    }
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao salvar Preço: {ex.Message}");
               }
               return Conflict("Esta data já está sendo usada como vigência!");

          }

          [HttpPut("{precoId}")]
          public async Task<IActionResult> Put(int precoId, TabelaPreco preco)
          {
               try
               {
                    var precoCadastrado = await _repositorio.GetPrecoAsyncById(precoId);

                    if (precoCadastrado == null)
                    {
                         return NotFound();
                    }

                    _repositorio.Update(preco);
                    if (await _repositorio.SaveChangesAsync())
                    {
                         return Ok(preco);
                    }
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao editar Preço: {ex.Message}");
               }
               return BadRequest();
          }

          [HttpDelete("{precoId}")]
          public async Task<IActionResult> Delete(int precoId)
          {
               try
               {
                    var precoCadastrado = await _repositorio.GetPrecoAsyncById(precoId);
                    if (precoCadastrado == null)
                    {
                         return NotFound();
                    }

                    _repositorio.Delete(precoCadastrado);
                    if (await _repositorio.SaveChangesAsync())
                    {
                         return Ok(
                              new
                              {
                                   message = "Preço removido com sucesso"
                              }
                         );
                    }
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao deletar Preço: {ex.Message}");
               }
               return BadRequest();
          }
     }
}