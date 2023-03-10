import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SamplesContainerComponent } from './samples-container.component';

describe('SamplesContainerComponent', () => {
  let component: SamplesContainerComponent;
  let fixture: ComponentFixture<SamplesContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SamplesContainerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SamplesContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
