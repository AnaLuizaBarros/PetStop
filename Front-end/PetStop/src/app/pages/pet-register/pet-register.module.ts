import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PetRegisterComponent } from './pet-register.component';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [CommonModule, ReactiveFormsModule, NgbModule, FormsModule],
  declarations: [PetRegisterComponent],
  exports: [PetRegisterComponent],
  providers: [],
})
export class PetRegisterModule {
  constructor() {}
}
