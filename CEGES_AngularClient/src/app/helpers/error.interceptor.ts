import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService, private router: Router) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(catchError(err => {
      //401 is not logged in 
      //403 no enough privileges
      // console.log('interceptor',request)
      if (err.status === 401) {
        // redirect to the login page
        this.authService.signOut();
      }
      if (err.status === 403) {
        // redirect to the login page
        this.router.navigate(['/403'])
      }

      const error = err.error?.message || err.statusText;
      console.error(err);
      return throwError(() => error);
    }))
  }
}
