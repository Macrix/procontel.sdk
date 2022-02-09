import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReloadButtonComponent } from './reload-button.component';

describe('ReloadButtonComponent', () => {
  let component: ReloadButtonComponent;
  let fixture: ComponentFixture<ReloadButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReloadButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReloadButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
