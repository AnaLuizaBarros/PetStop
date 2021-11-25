import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroAdotanteComponent } from './cadastro.adotante.component';

describe('CadastroComponent', () => {
  let component: CadastroAdotanteComponent;
  let fixture: ComponentFixture<CadastroAdotanteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroAdotanteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroAdotanteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
