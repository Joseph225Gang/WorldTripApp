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
    this.member.Password = this.profileForm.value.Password;
    this.memberService.registerMember(this.member).subscribe(result => {
      alert("註冊成功");
      location.href = "/trip-type";
    },
      error => {
        console.log(error);
        alert(error.error.errorMessage)
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

