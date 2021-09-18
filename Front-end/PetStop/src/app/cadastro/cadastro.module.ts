import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { CadastroRoutingModule } from './cadastro-routing.module';
import { CadastroComponent } from './cadastro.component';
@NgModule({
  imports: [CommonModule, SharedModule, CadastroRoutingModule],
  declarations: [CadastroComponent],
  exports: [CadastroComponent],
  providers: [],
})
export class CadastroModule {
  constructor() {}
}
