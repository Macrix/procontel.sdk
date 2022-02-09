import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { from, Observable, Observer, of, Subject } from 'rxjs';
import { catchError, map, scan, switchMap } from 'rxjs/operators';
import { BaseService } from './base.service';
import { API_BASE_URL } from './../injection.tokens';
import { OrderDto, OrderStatus } from '../../generated-models';
import { JwtService } from '../jwt.service';
import { CANCEL_ORDER_URL, GET_ORDERS_URL, GET_ORDER_BY_ID_URL, REGISTER_ORDER_URL, START_ORDER_URL } from '../urls.const';
import { AuthenticationService } from './authentication.service';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

export enum OrderListAction {
  AddItem,
  RemoveItem,
  ChangeOrderPriority
}

export interface IOrderListChangedInfo {
  action: OrderListAction;
  orderId: number;
  userId: string;
  newPriority: number | null;
}

export interface IOrderStatusInfo {
  status: OrderStatus;
  orderId: number;
  userId: string;
}

export interface IOrderPositionInfo {
  orderId: number | null; //when null than position properties changed 
  posId: number;
  positionId: string;
  positionName: string;
}
@Injectable({ providedIn: 'root' })
export class OrdersService extends BaseService {

  private readonly orderStatusChangedSubject: Subject<IOrderStatusInfo>;
  private readonly orderListForCurrentUserChangedSubject: Subject<IOrderListChangedInfo>;
  private readonly orderPositionChangedSubject: Subject<IOrderPositionInfo>;

  constructor(
    protected http: HttpClient,
    private authenticationService: AuthenticationService,
    private jwtService: JwtService,
    @Inject(API_BASE_URL) baseUrl: string
  ) {
    super(http, baseUrl);
    this.orderStatusChangedSubject = new Subject<IOrderStatusInfo>();
    this.orderListForCurrentUserChangedSubject = new Subject<IOrderListChangedInfo>();
    this.orderPositionChangedSubject = new Subject<IOrderPositionInfo>();

    authenticationService.currentUser
      .pipe(
        switchMap((user) =>
          user !== undefined && user !== null
            ? this.subscribeForUserOperations()
            : of(null)
        ),
        scan((prev, current) => {
          prev?.stop();
          return current;
        }),
        catchError((err) => of())
      )
      .subscribe();
  }

  getOrderPositionChanged(): Observable<IOrderPositionInfo> {
    return this.orderPositionChangedSubject.asObservable();
  }

  getOrderStatusChanged(): Observable<IOrderStatusInfo> {
    return this.orderStatusChangedSubject.asObservable();
  }

  orderListForCurrentUserChanged(): Observable<IOrderListChangedInfo> {
    return this.orderListForCurrentUserChangedSubject.asObservable();
  }

  private subscribeForUserOperations(
  ): Observable<HubConnection> {
    return new Observable((obs: Observer<HubConnection>) => {
      const operationsHubConnection = new HubConnectionBuilder()
        .withUrl(this.baseUrl + 'ordersHub'
          //, {
          //   accessTokenFactory: () =>
          //     this.authenticationService.currentUserValue.token,
          // }
        )
        .withAutomaticReconnect()
        .build();
      operationsHubConnection.onclose((error) => {
        if (error) {
          console.error(`Connection close with error ${error}`);
        } else {
          console.debug('Connection stoped.');
        }
      });
      operationsHubConnection.onreconnected((id) => {
        operationsHubConnection.invoke('SubscribeAsync', 'test');
      });

      operationsHubConnection.on('OrderRegistered', (evt) => {
        console.log(evt);
        this.orderStatusChangedSubject.next({
          orderId: evt.orderId,
          userId: evt.operatedBy,
          status: (evt.register) ? OrderStatus.Registered : OrderStatus.ReadyToTransport
        });
      });

      operationsHubConnection.on('OrderStarted', (evt) => {
        console.log(evt);
        this.orderStatusChangedSubject.next({
          orderId: evt.orderId,
          userId: evt.operatedBy,
          status: OrderStatus.InProgress
        });
      });

      operationsHubConnection.on('OrderFinished', (evt) => {
        console.log(evt);
        this.orderStatusChangedSubject.next({
          orderId: evt.orderId,
          userId: evt.operatedBy,
          status: OrderStatus.Finished
        });
      });

      operationsHubConnection.on('OrderCanceled', (evt) => {
        console.log(evt);
        this.orderStatusChangedSubject.next({
          orderId: evt.orderId,
          userId: evt.operatedBy,
          status: OrderStatus.ReadyToTransport
        });
      });

      operationsHubConnection.on('OrderCreated', (evt) => {
        console.log(evt);
        this.orderListForCurrentUserChangedSubject.next({
          action: OrderListAction.AddItem,
          orderId: evt.orderId,
          userId: evt.operatedBy,
          newPriority: null
        });
      });

      operationsHubConnection.on('OrderRemoved', (evt) => {
        console.log(evt);
        this.orderListForCurrentUserChangedSubject.next({
          action: OrderListAction.RemoveItem,
          orderId: evt.orderId,
          userId: evt.operatedBy,
          newPriority: null
        });
      });

      operationsHubConnection.on('OrderReasigned', (evt) => {
        console.log(evt);
        this.orderListForCurrentUserChangedSubject.next({
          action: OrderListAction.RemoveItem,
          orderId: evt.orderId,
          userId: evt.oldOperatedBy,
          newPriority: null
        });
        this.orderListForCurrentUserChangedSubject.next({
          action: OrderListAction.AddItem,
          orderId: evt.orderId,
          userId: evt.newOperatedBy,
          newPriority: null
        });
      });

      operationsHubConnection.on('OrderTestResult', (evt) => {
        console.log(evt);
        this.orderListForCurrentUserChangedSubject.next({
          action: OrderListAction.AddItem,
          orderId: evt.orderId,
          userId: evt.operatedBy,
          newPriority: null
        });
      });

      operationsHubConnection.on('OrderPriorityChanged', (evt) => {
        console.log(evt);
        this.orderListForCurrentUserChangedSubject.next({
          action: OrderListAction.ChangeOrderPriority,
          orderId: evt.orderId,
          userId: evt.operatedBy,
          newPriority: evt.orderNewPriority
        });

        if (evt.relatedOrderNewPriority) {
          this.orderListForCurrentUserChangedSubject.next({
            action: OrderListAction.ChangeOrderPriority,
            orderId: evt.relatedOrderId,
            userId: evt.relatedOperatedBy,
            newPriority: evt.relatedOrderNewPriority
          });
        }
      });

      operationsHubConnection.on('OrderPositionToChanged', (evt) => {
        console.log(evt);
        this.orderPositionChangedSubject.next({
          orderId: evt.orderId,
          posId: evt.endId,
          positionId: evt.endPositionId,
          positionName: evt.endPositionName
        });
      });
      
      operationsHubConnection.on('PositionPropertiesChanged', (evt) => {
        console.log(evt);
        this.orderPositionChangedSubject.next({
          orderId: null,
          posId: evt.id,
          positionId: evt.newPositionId,
          positionName: evt.newPositionName
        });
      });

      return from(operationsHubConnection.start())
        .pipe(
          map((x) => {
            operationsHubConnection.invoke('SubscribeAsync', 'test');
          }),
          map((x) => operationsHubConnection)
        )
        .subscribe(obs);
    });
  }

  getOrderById(orderId: number) : Observable<OrderDto> {
    return this.http
      .get<OrderDto>(
        `${this.apiBaseUrl}${GET_ORDER_BY_ID_URL}/${orderId}`
      )
      .pipe(
        map((x) => x),
        catchError(this.handleError)
      );
  }

  getOrdersOfUser(email: string): Observable<OrderDto[]> {
    return this.http
      .get<OrderDto[]>(
        `${this.apiBaseUrl}${GET_ORDERS_URL}/${email}`
      )
      .pipe(
        map((x) => x),
        catchError(this.handleError)
      );
  }

  registerOrder(email: string, orderId: number, register: boolean): Observable<boolean> {
    return this.http
      .post(
        `${this.apiBaseUrl}${REGISTER_ORDER_URL}`,
        { email: email, orderId: orderId, register: register },
        this.httpOptions
      )
      .pipe(
        map(x => true),
        catchError(this.handleError)
      );
  }
  startOrder(email: string, orderId: number | undefined): Observable<boolean> {
    return this.http
      .post(
        `${this.apiBaseUrl}${START_ORDER_URL}`,
        { email: email, orderId: orderId },
        this.httpOptions
      )
      .pipe(
        map(x => true),
        catchError(this.handleError)
      );
  }

  cancelOrder(email: string, orderId: number | undefined): Observable<boolean> {
    return this.http
      .post(
        `${this.apiBaseUrl}${CANCEL_ORDER_URL}`,
        { email: email, orderId: orderId },
        this.httpOptions
      )
      .pipe(
        map(x => true),
        catchError(this.handleError)
      );
  }
}
