import { SharedModule } from './../../shared/shared.module';
import { AdotanteService } from './../../service/adotante.service';
import { DoadorService } from './../../service/doador.service';
import { EditProfileComponent } from './edit-profile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AnimalService } from 'src/app/service/animal.service';
import { EspecieService } from 'src/app/service/especie.service';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgbModule,
    FormsModule,
    SharedModule,
  ],
  declarations: [EditProfileComponent],
  exports: [EditProfileComponent],
  providers: [],
})
export class EditProfileModule {
  constructor() {}
}
