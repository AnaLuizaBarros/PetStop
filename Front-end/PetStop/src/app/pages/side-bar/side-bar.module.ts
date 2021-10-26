import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SideBarComponent } from './side-bar.component';
import { SideBardRoutingModule } from './side-bar-routing.module';

@NgModule({
  imports: [CommonModule, RouterModule, SideBardRoutingModule],
  declarations: [SideBarComponent],
  exports: [SideBarComponent],
  providers: [],
})
export class SideBarModule {
  constructor() {}
}
