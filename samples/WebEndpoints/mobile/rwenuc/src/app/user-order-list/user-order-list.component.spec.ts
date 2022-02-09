import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { UserOrderListComponent } from './user-order-list.component';

describe('UserOrderListComponent', () => {
  let component: UserOrderListComponent;
  let fixture: ComponentFixture<UserOrderListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserOrderListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserOrderListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
