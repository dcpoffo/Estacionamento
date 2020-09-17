import { Estacionamento } from 'src/app/models/Estacionamento';
import { Component, OnInit } from '@angular/core';
import { Veiculo } from 'src/app/models/Veiculo';
import { Preco } from 'src/app/models/Preco';
import { EstacionamentoService } from 'src/app/services/estacionamento.service';
import { VeiculoService } from 'src/app/services/veiculo.service';
import { PrecoService } from 'src/app/services/preco.service';
import { MensagemService } from 'src/app/services/mensagem.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-estacionamento-update',
  templateUrl: './estacionamento-update.component.html',
  styleUrls: ['./estacionamento-update.component.scss']
})
export class EstacionamentoUpdateComponent implements OnInit {

  veiculos: Veiculo[];
  precos: Preco[];
  estacionamento: Estacionamento;

  dataSaida: Date = new Date();
  valorHora: number;

  constructor(
    private estacionamentoServico: EstacionamentoService,
    private veiculoServico: VeiculoService,
    private precoServico: PrecoService,
    private mensagemServico: MensagemService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.estacionamentoServico.getById(id).subscribe((estacionamento) => {
      this.estacionamento = estacionamento;

      //atribui automaticamente a data atuali à data de saida, ao clicar em marcar saida
      this.estacionamento.saida = this.dataSaida;

      //chamar funcao de calculo do valor passando estacionamento

    });
    this.carregarVeiculos();
    this.carregarPrecos();
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

  atualizarEstacionamento(): void {
    this.estacionamentoServico.put(this.estacionamento).subscribe(() => {
      this.mensagemServico.showMessage('Estacionamento atualizado com sucesso!');

      this.router.navigate(['/estacionamentos']);
    });
  }

  cancelar(): void {
    this.router.navigate(['/estacionamentos']);
  }

}
