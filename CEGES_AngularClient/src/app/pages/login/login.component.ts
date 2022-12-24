import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  @Input() error?: string | null;


  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) {

    if (this.authService.checkToken()) {
      this.router.navigate(['/home'])
    }
  }

  ngOnInit() {

  }

  submit() {
    if (this.form.valid) {
      console.log('submiting')

      const email = this.form.get('email')?.value;
      const password = this.form.get('password')?.value;

      this.authService.signIn(email, password)
        .subscribe(
          res => console.log(res),
          err => console.log(err),
          () => {
            this.router.navigate(['/home'])
          }
        );

    }
  }

  getErrorMessage(controlName: string) {
    if (this.form.get(controlName)?.hasError('required')) {
      return 'You must enter a value';
    }

    return this.form.get(controlName)?.hasError('email') ? 'Not a valid email' : '';
  }


}
