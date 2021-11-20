import { PagesRoutingModule } from './pages-routing.module';
import { SideBarComponent } from './side-bar/side-bar.component';
import { PetRegisterComponent } from './pet-register/pet-register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    PagesRoutingModule,
  ],
  declarations: [],
  exports: [],
  providers: [],
})
export class PagesModule {
  constructor() {}
}
