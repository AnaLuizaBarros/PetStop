import { FilterComponent } from './filter.component';
import { SharedModule } from '../../shared/shared.module';

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
    SharedModule,
  ],
  declarations: [FilterComponent],
  exports: [FilterComponent],
  providers: [],
})
export class FilterModule {
  constructor() {}
}
