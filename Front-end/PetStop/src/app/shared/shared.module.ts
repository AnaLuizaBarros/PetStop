import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { LoadingComponent } from './loading/loading.component';

@NgModule({
  imports: [CommonModule],
  declarations: [NavBarComponent, LoadingComponent],
  exports: [NavBarComponent, LoadingComponent],
  entryComponents: [],
  providers: [],
})
export class SharedModule {}
