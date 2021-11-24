import { PagesModule } from './pages/pages.module';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'cadastroDoador',
    loadChildren: () =>
      import('./cadastroDoador/cadastro.doador.module').then((m) => m.CadastroDoadorModule),
  },
  {
    path: 'cadastroAdotante',
    loadChildren: () =>
      import('./cadastroAdotante/cadastro.adotante.module').then((m) => m.CadastroAdotanteModule),
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./pages/pages.module').then((m) => m.PagesModule),
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
