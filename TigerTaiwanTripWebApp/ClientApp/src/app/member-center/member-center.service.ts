import { Inject } from '@angular/core';
import { HttpParams, HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Member } from './member-center.component';

export class MemberCenterService {
  baseUrl: string;
  memberJson;
  body;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  update(member: Member) {
    this.body = { member: member };
    return this.http.put(this.baseUrl + 'api/Member/Update',
      this.body,
      {
        headers: new HttpHeaders()
          .set('Content-Type', 'application/json')
      }
    )
  }
}
