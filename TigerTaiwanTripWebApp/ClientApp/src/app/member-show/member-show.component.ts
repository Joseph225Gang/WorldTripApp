import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare let $: any;

@Component({
  selector: 'member-show',
  templateUrl: './member-show.component.html'
})
export class MemberShowComponent{
  memberList: Member[] = []

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any[]>(baseUrl + 'api/Member/ShowAllMember').subscribe(result => {
      this.memberList = result;
    }, error => console.error(error));
  }
}

export class Member {
  id: string;
  Name: string;
  BirthDay: Date;
  MobilePhone: string;
  Email: string;
  PassWord: string;
};

