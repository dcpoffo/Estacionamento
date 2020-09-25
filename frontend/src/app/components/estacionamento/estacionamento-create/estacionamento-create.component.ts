import { MAT_DATE_LOCALE } from '@angular/material/core';
import { PrecoService } from './../../../services/preco.service';
import { VeiculoService } from './../../../services/veiculo.service';
import { Preco } from 'src/app/models/Preco';
import { Veiculo } from './../../../models/Veiculo';
import { EstacionamentoService } from './../../../services/estacionamento.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MensagemService } from 'src/app/services/mensagem.service';
import { Estacionamento } from 'src/app/models/Estacionamento';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-estacionamento-create',
  templateUrl: './estacionamento-create.component.html',
  styleUrls: ['./estacionamento-create.component.scss']
})
export class EstacionamentoCreateComponent implements OnInit {

  veiculos: Veiculo[];
  precos: Preco[];
  dataEstrada: Date = new Date();

  estacionamento: Estacionamento = {
    entrada: null,
    saida: null,
    valorTotal: 0.0,
    tabelaPrecoId: 0,
    veiculoId: 0
  };

  constructor(
    private estacionamentoServico: EstacionamentoService,
    private veiculoServico: VeiculoService,
    private precoServico: PrecoService,
    private router: Router,
    private mensagemServico: MensagemService,
  ) { }

  ngOnInit() {
    this.carregarPrecos();
    this.carregarVeiculos();
    //this.estacionamento.entrada = this.dataEstrada;
  }

  carregarVeiculos(): void {
    this.veiculoServico.getAll().subscribe(a => {
      this.veiculos = a;
    });
  }

  carregarPrecos(): void {
    this.precoServico.getAll().subscribe(a => {
      this.precos = a;
    });
  }

  cadastrarEstacionamento(): void {
    this.estacionamentoServico.post(this.estacionamento).subscribe(() => {
      this.mensagemServico.showMessage('Estacionamento cadastrado com sucesso!');
      this.router.navigate(['/estacionamentos']);
    });
  }

  cancelar(): void {
    this.router.navigate(['/estacionamentos']);
  }

  procurarData(): void {
    console.log('ALTEROU!!!')
    this.estacionamento.tabelaPrecoId = 1;
  }

}
