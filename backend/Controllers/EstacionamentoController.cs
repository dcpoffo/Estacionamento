using System;
using System.Threading.Tasks;
using backend.data;
using Microsoft.AspNetCore.Mvc;
using backend.models;

namespace backend.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class EstacionamentoController : ControllerBase
     {
         private readonly IRepository _repositorio;

          public EstacionamentoController(IRepository repositorio)
          {
               _repositorio = repositorio;
          }
          
          [HttpGet]
          public async Task<IActionResult> GetAll()
          {
               try
               {
                    var result = await _repositorio.GetAllEstacionamentosAsync(true, true);
                    return Ok(result);
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao obter Estacionamentos: \n{ex.Message}");
               }
          }

          [HttpGet("{estacionamentoId}")]
          public async Task<IActionResult> GetById(int estacionamentoId)
          {
               try
               {
                    var result = await _repositorio.GetEstacionamentoAsyncById(estacionamentoId, true, true);
                    return Ok(result);
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao obter Estacionamento: \n{ex.Message}");
               }
          }

          [HttpPost]
          public async Task<IActionResult> Post(Estacionamento estacionamento)
          {
               try
               {
                    _repositorio.Add(estacionamento);
                    if (await _repositorio.SaveChangesAsync())
                    {
                         return Ok(estacionamento);
                    }
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao salvar Estacionamento: {ex.Message}");
               }
               return BadRequest();
          }

          [HttpPut("{estacionamentoId}")]
          public async Task<IActionResult> Put(int estacionamentoId, Estacionamento estacionamento)
          {
               try
               {
                    var estacionamentoCadastrado = await _repositorio.GetEstacionamentoAsyncById(estacionamentoId, true, true);

                    if (estacionamentoCadastrado == null)
                    {
                         return NotFound();
                    }

                    CalculoValorTotalEstacionamentoServico calcular = new CalculoValorTotalEstacionamentoServico();
                    estacionamento.ValorTotal =  calcular.CalculoValorTotal(estacionamento);

                    _repositorio.Update(estacionamento);
                    if (await _repositorio.SaveChangesAsync())
                    {
                         return Ok(estacionamento);
                    }
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao editar Estacionamento: {ex.Message}");
               }
               return BadRequest();
          }

          [HttpDelete("{estacionamentoId}")]
          public async Task<IActionResult> Delete(int estacionamentoId)
          {
               try
               {
                    var estacionamentoCadastrado = await _repositorio.GetEstacionamentoAsyncById(estacionamentoId, true, true);
                    if (estacionamentoCadastrado == null)
                    {
                         return NotFound();
                    }

                    _repositorio.Delete(estacionamentoCadastrado);
                    if (await _repositorio.SaveChangesAsync())
                    {
                         return Ok(
                              new
                              {
                                   message = "Estacionamento removido com sucesso"
                              }
                         );
                    }
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao deletar Estacionamento: {ex.Message}");
               }
               return BadRequest();
          }
     }
}