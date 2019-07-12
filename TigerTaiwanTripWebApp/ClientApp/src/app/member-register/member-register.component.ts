import { Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { MemberRegisterService} from './member-register.service';



@Component({
  selector: 'app-member-register',
  templateUrl: './member-register.component.html',
  styleUrls: ['./member-register.component.css'],
  providers: [MemberRegisterService],
})
export class MemberRegisterComponent{
  member: MemberRegister = new MemberRegister();
  profileForm = this.fb.group({
    Password: ['', Validators.required],
    Name: ['', Validators.required],
    BirthDay: ['', Validators.required],
    MobilePhone: ['', Validators.required],
    Email: ['', Validators.required],
  });

  constructor(private fb: FormBuilder, private memberService: MemberRegisterService) { }

  onSubmit() {
    console.warn(this.profileForm.value);
    this.member.Id = ""
  this.member.Name = this.profileForm.value.Name;
  this.member.BirthDay = this.profileForm.value.BirthDay;
  this.member.MobilePhone = this.profileForm.value.MobilePhone;
  this.member.Email = this.profileForm.value.Email;
    this.member.PassWord = this.profileForm.value.PassWord;
    this.member.BirthDay = new Date();
    this.memberService.registerMember(this.member).subscribe(result => {
      alert("註冊成功");
      location.href = "/trip-type";
      },
      error => console.error(error));
  }
}

export class MemberRegister {
  Id: string;
  Name: string;
  BirthDay: Date;
  MobilePhone: string;
  Email: string;
  PassWord: string;
}

