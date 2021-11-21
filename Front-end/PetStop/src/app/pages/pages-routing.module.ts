import { PesquisaComponent } from './pesquisa/pesquisa.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FilterComponent } from './filter/filter.component';

const routes: Routes = [
  {
    path: '',
    component: SideBarComponent,
    children: [
      { path: 'pesquisa', component: PesquisaComponent },
      { path: 'filtro', component: FilterComponent },
    ],
  } /*,
  {
    path: 'pesquisa',
    loadChildren: () =>
      import('./pesquisa/pesquisa.module').then((m) => m.PesquisaModule),
  },*/,
  {
    path: 'pet-register',
    loadChildren: () => import('./pet-register/pet-register.module'),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
