import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders
} from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { PageRequest } from '../../models';
import { API_BASE_URL } from './../injection.tokens';

@Injectable()
export class BaseService {
  protected httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
    observe: 'response' as 'response',
  };
  
  protected baseUrl: string;
  protected apiBaseUrl: string;
  
  constructor(
    protected http: HttpClient,
    @Inject(API_BASE_URL) baseUrl: string
  ) {
    this.baseUrl = `${baseUrl}/`;
    this.apiBaseUrl = `${baseUrl}/api/v1.0/`;
  }

  protected rangeQueryString = (pageRequest?: PageRequest) =>
    pageRequest !== undefined
      ? `&Page=${pageRequest.pagenNumber}&Results=${pageRequest.pageSize}`
      : ''

  protected handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    return throwError('Something bad happened; please try again later.');
  }
}
