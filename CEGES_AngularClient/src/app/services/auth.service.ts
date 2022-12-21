import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _isLoggedIn$ = new BehaviorSubject<boolean>(false);

  isLoggedIn$ = this._isLoggedIn$.asObservable()

  constructor(private http: HttpClient,private router:Router) {
    const logged = this.checkToken();
    console.log('logged in: ', logged);
    this._isLoggedIn$.next(logged);
  }

  public signIn(email: string, password: string) {
    return this.http.post('/auth/signin', {
      email: email,
      password: password
    }).pipe(tap((response: any) => {
      this._isLoggedIn$.next(true);
      localStorage.setItem('ceges-auth', response.token)
    }))
  }


  public signOut() {
    localStorage.removeItem('ceges-auth');
    this._isLoggedIn$.next(false)
    this.router.navigate(['/login'])
  }

  public getClaims() {

    return this.http.get('/auth/claims').pipe(
      tap((response: any) => {
        console.log(response)
      }))
  }
  private checkToken(): boolean {
    const token = localStorage.getItem('ceges-auth');
    return !!token && this.tokenExpired(token);
  }

  private tokenExpired(token: string): boolean {
    if (!token) return false;
    const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
    return expiry * 1000 > Date.now();
  }

}
