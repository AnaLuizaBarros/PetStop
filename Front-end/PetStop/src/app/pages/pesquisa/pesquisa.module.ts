import { PesquisaRoutingModule } from './pesquisa.routing.module';
import { PesquisaComponent } from './pesquisa.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgbModule,
    FormsModule,
    PesquisaRoutingModule,
  ],
  declarations: [PesquisaComponent],
  exports: [PesquisaComponent],
  providers: [],
})
export class PesquisaModule {
  constructor() {}
}
