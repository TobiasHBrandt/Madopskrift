import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpretOpskriftComponent } from './opret-opskrift.component';

describe('OpretOpskriftComponent', () => {
  let component: OpretOpskriftComponent;
  let fixture: ComponentFixture<OpretOpskriftComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpretOpskriftComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpretOpskriftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
