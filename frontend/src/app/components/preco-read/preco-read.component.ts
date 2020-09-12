import { PrecoService } from './../../services/preco.service';
import { Preco } from './../../models/Preco';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-preco-read',
  templateUrl: './preco-read.component.html',
  styleUrls: ['./preco-read.component.scss']
})
export class PrecoReadComponent implements OnInit {

  precos: Preco[];

  displayedColumns = ['id', 'vigenciaInicial', 'vigenciaFinal', 'valorHora', 'acoes'];

  constructor(
    private precoServico: PrecoService
  ) { }

  ngOnInit() {
    this.precoServico.getAll().subscribe(precos => {
      this.precos = precos;
      console.log(precos);
    });
  }

}
