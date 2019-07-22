import { Component, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  loginUser: string = "";
  title = 'app';

  constructor() {
    console.log(localStorage.getItem("login"));
    if (localStorage.getItem("login") === null) {
      localStorage.setItem('login', '');
    } 
  }

  logout() {
    localStorage.setItem('login', '');
    location.href = './trip-type';
  }

  ngAfterViewInit() {
    this.loginUser = localStorage.getItem('login');
  }
}
