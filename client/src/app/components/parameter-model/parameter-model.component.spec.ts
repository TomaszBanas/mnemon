import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParameterModelComponent } from './parameter-model.component';

describe('ParameterModelComponent', () => {
  let component: ParameterModelComponent;
  let fixture: ComponentFixture<ParameterModelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParameterModelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ParameterModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
