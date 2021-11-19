import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SideBarComponent } from './side-bar.component';
@NgModule({
  imports: [CommonModule, RouterModule, NgbModule],
  declarations: [SideBarComponent],
  exports: [SideBarComponent],
  providers: [],
})
export class SideBarModule {
  constructor() {}
}
