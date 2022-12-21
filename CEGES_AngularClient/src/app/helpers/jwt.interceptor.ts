import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private authService:AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    // add auth header with jwt if account is logged in and request is to the api url
    const isLoggedIn = this.authService.isLoggedIn$;
    console.log(request)
    if (isLoggedIn) {
        request = request.clone({
            setHeaders: { Authorization: `Bearer ${localStorage.getItem('ceges-auth')}` }
        });
  }
    return next.handle(request);
  }
}
