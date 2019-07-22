import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TripTypeComponent } from './trip-type/trip-type.component';
import { MemberRegisterComponent } from './member-register/member-register.component';
import { MemberCenterComponent } from './member-center/member-center.component';
import { MemberSignInComponent } from './member-signIn/member-signIn.component';
import { MemberShowComponent } from './member-show/member-show.component';
import { AsiaTripComponent } from './asia-trip/asia-trip.component';
import { AmericanTripComponent } from './american-trip/american-trip.component';
import { EuropeanTripComponent } from './european-trip/european-trip.component';
import { TaiwanNorthernComponent } from './taiwan-northern/taiwan-northern.component';
import { TaiwanMiddleComponent } from './taiwan-middle/taiwan-middle.component';
import { TaiwanSouthernComponent } from './taiwan-southern/taiwan-southern.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TripTypeComponent,
    MemberRegisterComponent,
    MemberCenterComponent,
    MemberSignInComponent,
    MemberShowComponent,
    AsiaTripComponent,
    AmericanTripComponent,
    EuropeanTripComponent,
    TaiwanNorthernComponent,
    TaiwanMiddleComponent,
    TaiwanSouthernComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: TripTypeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'trip-type', component: TripTypeComponent },
      { path: 'member-register', component: MemberRegisterComponent },
      { path: 'member-center', component: MemberCenterComponent },
      { path: 'member-signIn', component: MemberSignInComponent },
      { path: 'member-show', component: MemberShowComponent },
      { path: 'asia-trip', component: AsiaTripComponent },
      { path: 'american-trip', component: AmericanTripComponent },
      { path: 'european-trip', component: EuropeanTripComponent },
      { path: 'taiwan-northern', component: TaiwanNorthernComponent },
      { path: 'taiwan-middle', component: TaiwanMiddleComponent },
      { path: 'taiwan-southern', component: TaiwanSouthernComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
