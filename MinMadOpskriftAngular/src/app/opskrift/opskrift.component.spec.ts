import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpskriftComponent } from './opskrift.component';

describe('OpskriftComponent', () => {
  let component: OpskriftComponent;
  let fixture: ComponentFixture<OpskriftComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpskriftComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpskriftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
