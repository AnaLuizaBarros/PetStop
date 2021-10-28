import { PesquisaComponent } from './../pesquisa/pesquisa.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SideBarComponent } from './side-bar.component';

const routes: Routes = [
  {
    path: '',
    component: SideBarComponent,
    children: [{ path: 'pesquisa', component: PesquisaComponent }],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SideBardRoutingModule {}
