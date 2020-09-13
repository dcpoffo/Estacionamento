import { Component, OnInit } from '@angular/core';
import { Preco } from 'src/app/models/Preco';
import { PrecoService } from 'src/app/services/preco.service';

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
