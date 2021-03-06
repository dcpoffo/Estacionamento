using System.Collections.Generic;

namespace backend.models
{
     public class Veiculo
     {
          public int Id { get; set; }
          public string Placa { get; set; }
          public string Marca { get; set; }
          public string Modelo { get; set; }
          public string Cor { get; set; }
          public IEnumerable<Estacionamento> Estacionameto { get; set; }

          public Veiculo(int id, string placa, string marca, string modelo, string cor)
          {
               this.Id = id;
               this.Placa = placa;
               this.Marca = marca;
               this.Modelo = modelo;
               this.Cor = cor;
          }
     }
}