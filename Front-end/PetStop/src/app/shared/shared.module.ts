import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SideBarComponent } from './side-bar/side-bar.component';

@NgModule({
  imports: [CommonModule],
  declarations: [NavBarComponent, SideBarComponent],
  exports: [NavBarComponent, SideBarComponent],
  entryComponents: [],
  providers: [],
})
export class SharedModule {}
