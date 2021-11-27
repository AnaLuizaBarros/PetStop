import { SideBardRoutingModule } from './side-bar-routing.module';
import { EspecieService } from './../../service/especie.service';
import { RacaService } from './../../service/raca.service';
import { AnimalService } from './../../service/animal.service';
import { DoadorService } from './../../service/doador.service';
import { AdotanteService } from './../../service/adotante.service';
import { EditProfileComponent } from './../edit-profile/edit-profile.component';
import { DonorAnimalsComponent } from './../donor-animals/donor-animals.component';
import { FilterComponent } from './../filter/filter.component';
import { PesquisaComponent } from './../pesquisa/pesquisa.component';
import { PetRegisterComponent } from './../pet-register/pet-register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from './../../shared/shared.module';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SideBarComponent } from './side-bar.component';
@NgModule({
  imports: [
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    RouterModule,
    NgbModule,
  ],
  declarations: [
    SideBarComponent,
    PesquisaComponent,
    FilterComponent,
    DonorAnimalsComponent,
  ],
  exports: [SideBarComponent],
  providers: [
    AdotanteService,
    DoadorService,
    AnimalService,
    RacaService,
    EspecieService,
  ],
})
export class SideBarModule {
  constructor() {}
}
