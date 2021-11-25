import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { CadastroRoutingModule } from './cadastro.adotante-routing.module';
import { CadastroAdotanteComponent } from './cadastro.adotante.component';
@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    CadastroRoutingModule,
    ReactiveFormsModule,
  ],
  declarations: [CadastroAdotanteComponent],
  exports: [CadastroAdotanteComponent],
  providers: [CadastroAdotanteComponent],
})
export class CadastroAdotanteModule {
  constructor() {}
}
