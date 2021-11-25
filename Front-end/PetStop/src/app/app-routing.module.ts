import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DonorAnimalsComponent } from './pages/donor-animals/donor-animals.component';
import { FilterComponent } from './pages/filter/filter.component';
import { PesquisaComponent } from './pages/pesquisa/pesquisa.component';
import { SideBarComponent } from './pages/side-bar/side-bar.component';

const routes: Routes = [
  {
    path: 'cadastroDoador',
    loadChildren: () =>
      import('./cadastroDoador/cadastro.doador.module').then(
        (m) => m.CadastroDoadorModule
      ),
  },
  {
    path: 'cadastroAdotante',
    loadChildren: () =>
      import('./cadastroAdotante/cadastro.adotante.module').then(
        (m) => m.CadastroAdotanteModule
      ),
  },
  {
    path: 'dashboard',
    component: SideBarComponent,
    children: [
      { path: 'pesquisa', component: PesquisaComponent },
      { path: 'filtro/:id', component: FilterComponent },
      { path: 'pets', component: DonorAnimalsComponent },
    ],
  },
  {
    path: 'pet-register',
    loadChildren: () => import('./pages/pet-register/pet-register.module'),
  },
  {
    path: 'edit-profile',
    loadChildren: () => import('./pages/edit-profile/edit-profile.module'),
  },
  {
    path: '**',
    redirectTo: '/home',
    pathMatch: 'full',
    runGuardsAndResolvers: 'always',
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      paramsInheritanceStrategy: 'always',
      onSameUrlNavigation: 'reload',
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
