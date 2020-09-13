export class Veiculo {
  id?: number;
  placa: string;
  marca: string;
  modelo: string;
  cor: string;

  constructor (){
    this.id = 0;
    this.placa = '';
    this.marca = '';
    this.modelo = '';
    this.cor = '';
  }
}
