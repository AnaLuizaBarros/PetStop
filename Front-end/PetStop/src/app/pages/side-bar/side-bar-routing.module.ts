import { DonorAnimalsComponent } from './../donor-animals/donor-animals.component';
import { FilterComponent } from './../filter/filter.component';
import { PesquisaComponent } from './../pesquisa/pesquisa.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SideBarComponent } from './side-bar.component';
import { HomeComponent } from 'src/app/home/home.component';

const routes: Routes = [
  {
    path: '',
    component: SideBarComponent,
    children: [
      { path: 'pesquisa', component: PesquisaComponent },
      { path: 'filtro/:id', component: FilterComponent },
      { path: 'pets', component: DonorAnimalsComponent },
    ],
  },
  {
    path: 'pet-register',
    loadChildren: () => import('../pet-register/pet-register.module'),
  },
  {
    path: 'edit-profile',
    loadChildren: () => import('../edit-profile/edit-profile.module'),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SideBardRoutingModule {}
