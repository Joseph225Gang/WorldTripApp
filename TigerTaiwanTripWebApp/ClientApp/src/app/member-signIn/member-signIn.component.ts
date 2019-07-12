import { Component, Inject} from '@angular/core';

@Component({
  selector: 'app-member-signIn',
  templateUrl: './member-signIn.component.html',
  styleUrls: ['./member-signIn.component.css'],
})
export class MemberSignInComponent{
  Phase = Phase;
  phase: Phase = Phase.One;

  forgetPassword(): void {
    this.phase = Phase.Two;
  }
}

export enum Phase {
  One,
  Two,
  Three
}



