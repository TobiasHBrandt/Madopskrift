import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MineOpskrifterComponent } from './mine-opskrifter.component';

describe('MineOpskrifterComponent', () => {
  let component: MineOpskrifterComponent;
  let fixture: ComponentFixture<MineOpskrifterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MineOpskrifterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MineOpskrifterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
