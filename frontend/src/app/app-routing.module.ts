import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './views/home/home.component';
import { PrecoComponent } from './views/preco/preco.component';
import { PrecoCreateComponent } from './components/preco-create/preco-create.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'precos', component: PrecoComponent},
  { path: 'precos/create', component: PrecoCreateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
