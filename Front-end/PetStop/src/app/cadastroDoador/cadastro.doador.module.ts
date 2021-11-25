import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { CadastroRoutingModule } from './cadastro.doador-routing.module';
import { CadastroDoadorComponent } from './cadastro.doador.component';
@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    CadastroRoutingModule,
    ReactiveFormsModule,
  ],
  declarations: [CadastroDoadorComponent],
  exports: [CadastroDoadorComponent],
  providers: [CadastroDoadorComponent],
})
export class CadastroDoadorModule {
  constructor() {}
}
