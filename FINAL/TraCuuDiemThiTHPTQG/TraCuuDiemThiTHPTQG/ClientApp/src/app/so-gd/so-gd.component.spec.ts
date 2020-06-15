import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SoGDComponent } from './so-gd.component';

describe('SoGDComponent', () => {
  let component: SoGDComponent;
  let fixture: ComponentFixture<SoGDComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SoGDComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SoGDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
