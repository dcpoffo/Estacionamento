import { PrecoService } from './../../../services/preco.service';
import { VeiculoService } from './../../../services/veiculo.service';
import { Preco } from 'src/app/models/Preco';
import { Veiculo } from './../../../models/Veiculo';
import { EstacionamentoService } from './../../../services/estacionamento.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MensagemService } from 'src/app/services/mensagem.service';
import { Estacionamento } from 'src/app/models/Estacionamento';

@Component({
  selector: 'app-estacionamento-create',
  templateUrl: './estacionamento-create.component.html',
  styleUrls: ['./estacionamento-create.component.scss']
})
export class EstacionamentoCreateComponent implements OnInit {

  veiculos: Veiculo[];
  precos: Preco[];

  estacionamento: Estacionamento = {
    entrada: null,
    saida: null,
    valorTotal: 0.0,
    tabelaPrecoId: 0,
    veiculoId: 0
  }

  constructor(
    private estacionamentoServico: EstacionamentoService,
    private veiculoServico: VeiculoService,
    private precoServico: PrecoService,
    private router: Router,
    private mensagemServico: MensagemService
  ) { }

  ngOnInit() {
    this.carregarPrecos();
    this.carregarVeiculos();
  }

  carregarVeiculos(): void {
    this.veiculoServico.getAll().subscribe(prob => {
      this.veiculos = prob;
    });
  }

  carregarPrecos(): void {
    this.precoServico.getAll().subscribe(prob => {
      this.precos = prob;
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

}
