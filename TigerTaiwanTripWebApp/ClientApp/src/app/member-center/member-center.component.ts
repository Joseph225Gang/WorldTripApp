import { Component, Inject, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { MemberCenterService } from './member-center.service';
import { Transaction } from '../ticket-sell/ticket-sell.component';
declare let $: any;

@Component({
  selector: 'app-member-center',
  templateUrl: './member-center.component.html',
  styleUrls: ['./member-center.component.css'],
  providers: [MemberCenterService],
})
export class MemberCenterComponent implements AfterViewInit {
  member: Member = new Member();
  transactionList: Transaction[] = [];
  userId: string;
  message: string;
  success: boolean = false;
  profileForm = this.fb.group({
    Password: ['', Validators.required],
    Name: ['', Validators.required],
    BirthDay: ['', Validators.required],
    MobilePhone: ['', Validators.required],
    Email: ['', Validators.required],
  });

  constructor(private fb: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private memberService: MemberCenterService) { }

  modalClose() {
    $('#myModal').modal('hide');
    if (this.success) {
      localStorage.setItem('login', this.member.Name);
      location.href = "/trip-type";
    }
  }
  ngAfterViewInit() {
    this.http.get<any[]>(this.baseUrl + 'api/Member/GetCurrentUserInfo?userName=' + localStorage.getItem("login")).subscribe(result => {
      var user = result as any;
      this.userId = user.id;
      $('#name').val(user.name);
      $('#birthDay').val(user.birthDay);
      $('#passWord').val(user.passWord);
      $('#mobilePhone').val(user.mobilePhone);
      $('#email').val(user.email);
      
    },
    );

    this.http.get<any[]>(this.baseUrl + 'api/Transaction/ShowTransactionInformation?userName=' + localStorage.getItem("login")).subscribe(result => {
      this.transactionList = result;
    },
      error => { console.error(error); }
    );
  }

  onSubmit() {
    this.member.Id = this.userId;
    this.member.Name = $('#name').val();
    this.member.BirthDay = $('#birthDay').val();
    this.member.MobilePhone = $('#mobilePhone').val();
    this.member.Email = $('#email').val();
    this.member.Password = $('#passWord').val();
    this.memberService.update(this.member).subscribe(result => {
      this.message = "更新成功";
      this.success = true;
      $('#myModal').modal('show');
    },
      error => {
        this.message = error.error.errorMessage;
        this.success = false;
        $('#myModal').modal('show');
        
      });
  }
}

export class Member {
  Id: string;
  Name: string;
  BirthDay: string;
  MobilePhone: string;
  Email: string;
  Password: string;
}

