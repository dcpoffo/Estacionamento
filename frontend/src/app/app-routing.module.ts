import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './views/home/home.component';

import { PrecoComponent } from './views/preco/preco.component';
import { PrecoCreateComponent } from './components/preco/preco-create/preco-create.component';

import { VeiculoComponent } from './views/veiculo/veiculo.component';
import { VeiculoCreateComponent } from './components/veiculo/veiculo-create/veiculo-create.component';
import { VeiculoDeleteComponent } from './components/veiculo/veiculo-delete/veiculo-delete.component';
import { VeiculoUpdateComponent } from './components/veiculo/veiculo-update/veiculo-update.component';

import { EstacionamentoComponent } from './views/estacionamento/estacionamento.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'precos', component: PrecoComponent },
  { path: 'precos/create', component: PrecoCreateComponent },
  { path: 'veiculos', component: VeiculoComponent },
  { path: 'veiculos/create', component: VeiculoCreateComponent },
  { path: 'veiculos/delete/:id', component: VeiculoDeleteComponent },
  { path: 'veiculos/update/:id', component: VeiculoUpdateComponent },
  { path: 'estacionamentos', component : EstacionamentoComponent },
  // { path: 'estacionamentos/create', component: EstacionamentoCreateComponent },
  // { path: 'estacionamentos/delete/:id', component: EstacionamentoDeleteComponent },
  // { path: 'estacionamentos/update/:id', component: EstacionamentoUpdateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
