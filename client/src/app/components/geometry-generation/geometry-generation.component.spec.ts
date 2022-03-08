import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeometryGenerationComponent } from './geometry-generation.component';

describe('GeometryGenerationComponent', () => {
  let component: GeometryGenerationComponent;
  let fixture: ComponentFixture<GeometryGenerationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GeometryGenerationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GeometryGenerationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
