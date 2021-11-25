import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonorAnimalsComponent } from './donor-animals.component';

describe('DonorAnimalsComponent', () => {
  let component: DonorAnimalsComponent;
  let fixture: ComponentFixture<DonorAnimalsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DonorAnimalsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DonorAnimalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
