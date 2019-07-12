import { Inject  } from '@angular/core';
import { HttpParams, HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { MemberRegister} from './member-register.component'

export class MemberRegisterService {
  baseUrl: string;
  memberJson;
  body;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  registerMember(member: MemberRegister) {
    this.body = { member: member };
    return this.http.post(this.baseUrl + 'api/Member/Register',
      this.body,
      {
        headers: new HttpHeaders()
          .set('Content-Type', 'application/json')
      }
    )
  }
}
