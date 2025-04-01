import { Component } from '@angular/core';

@Component({
  selector: 'dashboad',
  templateUrl: './dashboad.component.html',
  styleUrls: ['./dashboad.component.css']
})
export class DashboadComponent {
  firstname = localStorage.getItem('firstname');
  lastname = localStorage.getItem('lastname');
}
