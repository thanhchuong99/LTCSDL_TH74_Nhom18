import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThisinhComponent } from './thisinh.component';

describe('ThisinhComponent', () => {
  let component: ThisinhComponent;
  let fixture: ComponentFixture<ThisinhComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThisinhComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThisinhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
