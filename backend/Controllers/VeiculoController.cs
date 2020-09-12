using System;
using System.Threading.Tasks;
using backend.data;
using backend.models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

     [ApiController]
     [Route("[controller]")]

     public class VeiculoController : ControllerBase
     {
          private readonly IRepository _repositorio;

          public VeiculoController(IRepository repositorio)
          {
               _repositorio = repositorio;
          }

          [HttpGet]
          public async Task<IActionResult> GetAll()
          {
               try
               {
                    var result = await _repositorio.GetAllVeiculosAsync();
                    return Ok(result);
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao obter Veículos: \n{ex.Message}");
               }
          }

          [HttpGet("{placaId}")]
          public async Task<IActionResult> GetById(int veiculoId)
          {
               try
               {
                    var result = await _repositorio.GetVeiculoAsyncById(veiculoId);
                    return Ok(result);
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao obter Veículo pelo Id: \n{ex.Message}");
               }
          }

          [HttpGet("{placa}")]
          public async Task<IActionResult> GetByPlaca(string placa)
          {
               try
               {
                    var result = await _repositorio.GetVeiculoAsyncByPlaca(placa);
                    return Ok(result);
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao obter Veículo pela placa: \n{ex.Message}");
               }
          }

          [HttpPost]
          public async Task<IActionResult> Post(Veiculo veiculo)
          {
               try
               {
                    _repositorio.Add(veiculo);
                    if (await _repositorio.SaveChangesAsync())
                    {
                         return Ok(veiculo);
                    }
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao salvar Veículo: {ex.Message}");
               }
               return BadRequest();
          }

          [HttpPut("{veiculoId}")]
          public async Task<IActionResult> Put(int veiculoId, Veiculo veiculo)
          {
               try
               {
                    var veiculoCadastrado = await _repositorio.GetVeiculoAsyncById(veiculoId);

                    if (veiculoCadastrado == null)
                    {
                         return NotFound();
                    }

                    _repositorio.Update(veiculo);
                    if (await _repositorio.SaveChangesAsync())
                    {
                         return Ok(veiculo);
                    }
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao editar Veículo: {ex.Message}");
               }
               return BadRequest();
          }

          [HttpDelete("{veiculoId}")]
          public async Task<IActionResult> Delete(int veiculoId)
          {
               try
               {
                    var veiculoCadastrado = await _repositorio.GetVeiculoAsyncById(veiculoId);
                    if (veiculoCadastrado == null)
                    {
                         return NotFound();
                    }

                    _repositorio.Delete(veiculoCadastrado);
                    if (await _repositorio.SaveChangesAsync())
                    {
                         return Ok(
                              new
                              {
                                   message = "Veículo removido com sucesso"
                              }
                         );
                    }
               }
               catch (Exception ex)
               {
                    return BadRequest($"Erro ao deletar Veículo: {ex.Message}");
               }
               return BadRequest();
          }
     }
}