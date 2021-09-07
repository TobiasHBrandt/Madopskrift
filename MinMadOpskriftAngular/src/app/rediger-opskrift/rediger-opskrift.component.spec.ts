import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RedigerOpskriftComponent } from './rediger-opskrift.component';

describe('RedigerOpskriftComponent', () => {
  let component: RedigerOpskriftComponent;
  let fixture: ComponentFixture<RedigerOpskriftComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RedigerOpskriftComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RedigerOpskriftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
