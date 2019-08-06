import { Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { MemberRegisterService} from './member-register.service';
declare let $: any;


@Component({
  selector: 'app-member-register',
  templateUrl: './member-register.component.html',
  styleUrls: ['./member-register.component.css'],
  providers: [MemberRegisterService],
})
export class MemberRegisterComponent{
  message: string;
  member: MemberRegister = new MemberRegister();
  profileForm = this.fb.group({
    Password: ['', Validators.required],
    Name: ['', Validators.required],
    BirthDay: ['', Validators.required],
    MobilePhone: ['', Validators.required],
    Email: ['', Validators.required],
  });
  success: boolean = false;

  constructor(private fb: FormBuilder, private memberService: MemberRegisterService) { }

  modalClose() {
    $('#myModal').modal('hide');
    if (this.success)
      location.href = "/trip-type";
  }

  onSubmit() {
    this.member.Id = ""
  this.member.Name = this.profileForm.value.Name;
  this.member.BirthDay = this.profileForm.value.BirthDay;
  this.member.MobilePhone = this.profileForm.value.MobilePhone;
  this.member.Email = this.profileForm.value.Email;
    this.member.Password = this.profileForm.value.Password;
    this.memberService.registerMember(this.member).subscribe(result => {
      this.message = "註冊成功";
      this.success = true;
      $('#myModal').modal('show');
    },
      error => {
        this.success = false;
        this.message = error.error.errorMessage;
        $('#myModal').modal('show');
      });
  }
}

export class MemberRegister {
  Id: string;
  Name: string;
  BirthDay: string;
  MobilePhone: string;
  Email: string;
  Password: string;
}

