import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { BaseService } from './base.service';
import { API_BASE_URL } from './../injection.tokens';
import { AuthenticateRequest, AuthenticateResponse, UserDto } from '../../generated-models';
import { JwtService } from '../jwt.service';
import { GET_USERS_URL } from '../urls.const';

@Injectable({ providedIn: 'root' })
export class AuthenticationService extends BaseService {
  private currentUserSubject: BehaviorSubject<AuthenticateResponse | null>;
  public currentUser: Observable<AuthenticateResponse | null>;

  constructor(
    protected http: HttpClient,
    private jwtService: JwtService,
    private dialogRef: MatDialog,
    @Inject(API_BASE_URL) baseUrl: string
  ) {
    super(http, baseUrl);
    this.currentUserSubject = new BehaviorSubject<AuthenticateResponse | null>(
      this.jwtService.getUser()
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get isLoggedIn(): Observable<boolean> {
    return this.currentUserSubject.pipe(
      map((x) =>
        this.currentUserValue && this.currentUserValue.token ? true : false
      )
    );
  }

  public get currentUserValue(): AuthenticateResponse | null {
    return this.currentUserSubject.value;
  }

  private setAuth(user: AuthenticateResponse): AuthenticateResponse {
    this.jwtService.saveUser(user);
    this.currentUserSubject.next(user);
    return user;
  }
  
  login(request: AuthenticateRequest): Observable<AuthenticateResponse> {
    return of(new AuthenticateResponse({ email: request.email, username: request.email, token: request.email }))
      .pipe(map((user) => this.setAuth(user)));
  }
  

  logout() {
    this.dialogRef.closeAll();
    this.jwtService.destroyUser();
    this.currentUserSubject.next(null);
  }
  
  getUsers() : Observable<UserDto[]> {
    return this.http      
      .get<UserDto[]>(
        `${this.apiBaseUrl}${GET_USERS_URL}`
      )
      .pipe(
        map((x) => x),
        catchError(this.handleError)
      );
  }
}
