import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, of, Subject } from 'rxjs';
import { first, map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { OrderDto, OrderStatus } from '../core/generated-models';
import { AuthenticationService, OrderListAction, OrdersService } from '../core/services';
import { QrScannerComponent } from '../qr-scanner/qr-scanner.component';

export const fadeAnimation = trigger('fadeAnimation', [
  transition(':enter', [
    style({ opacity: 0, height: 0 }), animate('1000ms', style({ opacity: 1, height: '*' }))]
  ),
  transition(':leave',
    [style({ opacity: 1, height: '*' }), animate('1000ms', style({ opacity: 0, height: 0 }))]
  )
]);
@Component({
  selector: 'app-user-order-list',
  templateUrl: './user-order-list.component.html',
  styleUrls: ['./user-order-list.component.scss'],
  animations: [fadeAnimation]
})
export class UserOrderListComponent implements OnInit, OnDestroy {

  ordersBehaviorSubject: BehaviorSubject<OrderDto[]> = new BehaviorSubject<OrderDto[]>([]);
  orders$: Observable<OrderDto[]>;
  selectedOrder: OrderDto | null = null;
  isOrderInProgress: boolean = false;
  isOperationInProgress: boolean = false;
  OrderStatus = OrderStatus;
  private unsubscriber: Subject<void> = new Subject<void>();
  private orders: OrderDto[] = [];

  constructor(
    private router: Router,
    public dialog: MatDialog,
    public authenticationService: AuthenticationService,
    private ordersService: OrdersService) { 
      this.orders$ = this.ordersBehaviorSubject.asObservable(); 
    }

  ngOnInit(): void {
    this.getOrders();

    this.ordersService.getOrderPositionChanged()
      .pipe(
        takeUntil(this.unsubscriber),
        tap(evt => {
          if (evt.orderId) {
            //change position in order
            var ord = this.orders.find(o => o.id == evt.orderId);
            if (ord) {
              ord.endId = evt.posId;
              ord.endPositionId = evt.positionId;
              ord.endPositionName = evt.positionName; 
              return;
            }
          } else {
            //change position properties
            var ordStarts = this.orders.filter(o => o.startId == evt.posId);
            ordStarts.forEach(x => {
              x.startPositionId = evt.positionId;
              x.startPositionName = evt.positionName; 
            });
            var ordEnds = this.orders.filter(o => o.endId == evt.posId);
            ordEnds.forEach(x => {
              x.endPositionId = evt.positionId;
              x.endPositionName = evt.positionName; 
            });
            return;
          }
        })
      )
      .subscribe({
        error: (err) => { }
      });

    this.ordersService.getOrderStatusChanged()
      .pipe(
        takeUntil(this.unsubscriber),
        tap(x => {
          var ord = this.orders.find(o => o.id == x.orderId);
          if (!ord && x.userId == this.authenticationService.currentUserValue?.email) {
            this.getOrders(); //there is not order which is operated by me
            return;
          }

          if (ord) {
            ord.status = x.status;
            switch (x.status) {
              case OrderStatus.ReadyToTransport:
                {
                  this.selectedOrder = null;
                  this.isOrderInProgress = false;
                  break;
                }
              case OrderStatus.Registered:
                {
                  this.selectedOrder = ord;
                  this.isOrderInProgress = false;
                  break;
                }
              case OrderStatus.InProgress:
                {
                  this.selectedOrder = ord;
                  this.isOrderInProgress = true;
                  break;
                }
              case OrderStatus.Finished:
                {
                  this.applyRemoveItem(x.orderId);
                  break;
                }
              default:
                this.getOrders();
            }
          }
        })
      )
      .subscribe({
        error: (err) => { }
      })

    this.ordersService.orderListForCurrentUserChanged()
      .pipe(
        takeUntil(this.unsubscriber),
        tap(x => {
          switch (x.action) {
            case OrderListAction.AddItem:
              if (x.userId == this.authenticationService.currentUserValue?.email) {
                this.applyAddItem(x.orderId);
              }
              break;
            case OrderListAction.RemoveItem:
              this.applyRemoveItem(x.orderId);         
              break;
            case OrderListAction.ChangeOrderPriority:
              this.applyNewPriority(x.orderId, x.newPriority);
              break;
          }
        })
      )
      .subscribe({
        error: (err) => { }
      })
  }

  ngOnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }

  registerOrder(order: OrderDto) {
    if (!this.checkIfUserIsLogin()) {
      return;
    }
    if (!order) {
      return;
    }
    if (this.isOrderInProgress) {
      return;
    }

    this.isOperationInProgress = true;
    this.ordersService
      .registerOrder(this.authenticationService.currentUserValue!.email!, order.id!, !(this.selectedOrder && this.selectedOrder.id == order.id))
      .pipe(
        first()
      )
      .subscribe({
        error: (err) => { },
        complete: () => this.isOperationInProgress = false
      })
  }

  startOrder() {
    if (!this.checkIfUserIsLogin()) {
      return;
    }

    if (this.selectedOrder) {
      const dialogRef = this.dialog.open(QrScannerComponent, { data: { expected: this.selectedOrder.containerId } });

      dialogRef.afterClosed()
        .pipe(
          first(),
          switchMap((result) => {
            if (result) {
              this.isOperationInProgress = true
              return this.ordersService
                .startOrder(this.authenticationService.currentUserValue!.email!, this.selectedOrder?.id ?? undefined)
                .pipe(
                  first()
                )
            } else {
              return of(undefined);
            }
          })
        )
        .subscribe({
          error: (err) => { },
          complete: () => this.isOperationInProgress = false
        });
    }
  }

  cancelOrder() {
    if (!this.checkIfUserIsLogin()) {
      return;
    }

    if (this.selectedOrder) {
      this.isOperationInProgress = true;
      this.ordersService
        .cancelOrder(this.authenticationService.currentUserValue!.email!, this.selectedOrder.id ?? undefined)
        .pipe(
          first()
        )
        .subscribe({
          error: (err) => { },
          complete: () => this.isOperationInProgress = false
        })
    }
  }

  setSelectedOrderAndIsOrderInProgress = () => {
    this.selectedOrder = this.orders.find(x => (x.status == OrderStatus.Registered || x.status == OrderStatus.InProgress)
      && x.operatedBy == this.authenticationService.currentUserValue?.email) ?? null;
    if (this.selectedOrder && this.selectedOrder.status == OrderStatus.InProgress) {
      this.isOrderInProgress = true;
    }
  }

  getOrders() {
    if (!this.checkIfUserIsLogin()) {
      return;
    }

    this.ordersService
      .getOrdersOfUser(this.authenticationService.currentUserValue!.email!)
      .pipe(
        first(),
        tap(x => {
          this.isOrderInProgress = false;
          this.orders = x;
          this.ordersBehaviorSubject.next(x);
          this.setSelectedOrderAndIsOrderInProgress();          
        }),
        map(x => x.sort((o1, o2) =>
          (o1 && o2 && o1.priority && o2.priority && o1.priority < o2.priority) ? -1 : 1
        ))
      )
      .subscribe({
        error: (err) => { }        
      });
  }
  
  applyAddItem(orderId: number) : boolean {
    if (this.orders.find(o => o.id == orderId)) {
      return false;
    }

    this.ordersService.getOrderById(orderId)
    .pipe(
      first(),
      map(newOrder => [...this.orders, newOrder]),
      map(x => x.sort((o1, o2) =>
        (o1 && o2 && o1.priority && o2.priority && o1.priority < o2.priority) ? -1 : 1
      )),
      tap(os => {
        this.orders = os;
        this.ordersBehaviorSubject.next(this.orders);
      })
    )
    .subscribe({
      error: (err) => console.error(err)
    });

    return true;
  }

  applyRemoveItem(orderId: number) : boolean {
    if (!this.orders.find(o => o.id == orderId)) {
      return false;
    }
    this.orders = this.orders
      .filter(o => o.id != orderId)
      .sort((o1, o2) =>
        (o1 && o2 && o1.priority && o2.priority && o1.priority < o2.priority) ? -1 : 1
      );
    this.ordersBehaviorSubject.next(this.orders);
    this.setSelectedOrderAndIsOrderInProgress();
    return true;
  }

  applyNewPriority(orderId: number, newPriority: number | null) : boolean {
    if (!this.orders.find(o => o.id == orderId)) {
      return false;
    }

    if (!newPriority) {
      return false;
    }
    this.orders = this.orders.map(x => {
          if (x.id == orderId) {
            x.priority = newPriority;
          }
          return x;
        })
        .sort((o1, o2) =>        
        (o1 && o2 && o1.priority && o2.priority && o1.priority < o2.priority) ? -1 : 1);
    this.ordersBehaviorSubject.next(this.orders);    
    return true;
  }

  checkIfUserIsLogin(): boolean {
    if (this.authenticationService.currentUserValue?.email) {
      return true;
    }
    this.router.navigate(['/']);
    return false;
  }
}


