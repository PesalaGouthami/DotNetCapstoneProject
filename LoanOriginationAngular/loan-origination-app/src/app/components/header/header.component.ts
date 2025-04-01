import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  constructor(private router:Router) {
  }
  onLogout() {
      localStorage.removeItem('token');
      this.router.navigate(['/login']);
      
  }
}
