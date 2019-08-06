import { Component, Inject } from '@angular/core';
import { MemberSignInService } from './member-signIn.service';
declare let $: any;

@Component({
  selector: 'app-member-signIn',
  templateUrl: './member-signIn.component.html',
  styleUrls: ['./member-signIn.component.css'],
  providers: [MemberSignInService],
})
export class MemberSignInComponent{
  Phase = Phase;
  phase: Phase = Phase.One;
  message: string;

  constructor(private memberSiginService: MemberSignInService) { }
 
  modalClose() {
    $('#myModal').modal('hide');
  }

  login() {
    this.memberSiginService.login($('#userName').val(), $('#password').val()).subscribe(result => {
      localStorage.setItem('login', result.toString());
      if (result.toString().length > 0)
        location.href = './trip-type';
      else {
        this.message = '無此帳號';
        $('#myModal').modal('show');
      }
    },
      error => {
        console.log(error);
    })
  }
}

export enum Phase {
  One,
  Two,
  Three
}



