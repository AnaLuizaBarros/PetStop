import { CadastroModule } from './cadastro/cadastro.module';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroComponent } from './cadastro/cadastro.component';

const routes: Routes = [
  {
    path: 'cadastro',
    loadChildren: () =>
      import('./cadastro/cadastro.module').then((m) => m.CadastroModule),
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./pages/side-bar/side-bar.module').then((m) => m.SideBarModule),
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
