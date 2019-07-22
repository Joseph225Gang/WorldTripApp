import { Inject } from '@angular/core';
import { HttpParams, HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

export class MemberSignInService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  login(userName: string, password: string) {
    let login = { userName: userName, password: password };
    let body = { login};
    return this.http.post(this.baseUrl + 'api/Member/Login',
      JSON.stringify(body),
      {
        headers: new HttpHeaders()
          .set('Content-Type', 'application/json')
          .append("Accept", "application/json")
      }
    )
  }
}
