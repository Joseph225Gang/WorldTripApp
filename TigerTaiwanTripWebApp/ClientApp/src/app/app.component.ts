import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  loginUser: string = localStorage.getItem('login');
  title = 'app';

  constructor() {
    if (localStorage.getItem("login") === null) {
      localStorage.setItem('login', '');
    } 
  }

  logout() {
    localStorage.setItem('login', '');
    location.href = './trip-type';
  }
}
