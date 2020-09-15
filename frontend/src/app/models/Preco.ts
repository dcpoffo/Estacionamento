export class Preco {
  id?: number;
  vigenciaInicial: Date;
  vigenciaFinal: Date;
  valorHora: number;
  valorHoraAdicional: number;

  constructor(){
    this.id = 0;
    this.vigenciaInicial = null;
    this.vigenciaFinal = null;
    this.valorHora = 0.0;
    this.valorHoraAdicional = 0.0;
  }
}
