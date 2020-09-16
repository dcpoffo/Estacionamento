import { Component, OnInit } from '@angular/core';
import { Preco } from 'src/app/models/Preco';
import { Router } from '@angular/router';
import { MensagemService } from 'src/app/services/mensagem.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { PrecoService } from 'src/app/services/preco.service';

@Component({
  selector: 'app-preco-create',
  templateUrl: './preco-create.component.html',
  styleUrls: ['./preco-create.component.scss']
})
export class PrecoCreateComponent implements OnInit {

  preco: Preco = {
    vigenciaInicial: null,
    vigenciaFinal: null,
    valorHora: null,
  }

  constructor(
    private precoServico: PrecoService,
    private router: Router,
    private mensagemServico: MensagemService
  ) { }

  ngOnInit() {
  }

  cadastrarPreco(): void {
    this.precoServico.post(this.preco).subscribe(() => {
      this.mensagemServico.showMessage('Vigencia cadastrada com sucesso!')
      this.router.navigate(['/precos']);
    });
  }

  cancelar(): void {
    this.router.navigate(['/precos']);
  }

}
