import { Component } from '@angular/core';
import { LoginService } from 'src/app/services/login/login.service';
import { Router } from '@angular/router';
import { Login } from '../../models/login/login'

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginData:Login = {
    username: '',
    pin: ' '
  };
  constructor(private authService: LoginService, private router: Router) {}

  login() {
    this.authService.login(this.loginData.username!, this.loginData.pin!).subscribe(response => {
      console.log('token:',response.token);
      if (response.token) {
        localStorage.setItem('token', response.token);
        localStorage.setItem('firstname', response.firstname);
        localStorage.setItem('lastname', response.lastname);
        this.router.navigate(['/dashboard']);
      }
    },(err)=>{
      console.log('error:',err.error.msg);
    });
    ;
  }
}
