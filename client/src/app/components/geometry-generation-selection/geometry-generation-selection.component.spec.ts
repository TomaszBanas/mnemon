import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeometryGenerationSelectionComponent } from './geometry-generation-selection.component';

describe('GeometryGenerationSelectionComponent', () => {
  let component: GeometryGenerationSelectionComponent;
  let fixture: ComponentFixture<GeometryGenerationSelectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GeometryGenerationSelectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GeometryGenerationSelectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
