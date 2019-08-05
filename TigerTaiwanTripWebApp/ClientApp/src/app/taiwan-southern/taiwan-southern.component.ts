import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare let $: any;

@Component({
  selector: 'app-taiwan-southern',
  templateUrl: './taiwan-southern.component.html',
  styleUrls: ['../asia-trip/asia-trip.component.css'],
})
export class TaiwanSouthernComponent{
  baseUrl: string;
  taiwanSouthResult: string[] = [];
  taiwanSouthRegionTrips: TripInformation[] = [];
  selectCountryName: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    var component = this;

    component.http.get<any[]>(component.baseUrl + 'api/Taiwan/GetTaiwanRegion?countryCode=3').subscribe(
      result => {
        component.taiwanSouthResult = result;
      },
      error => { console.log(error); });
  }

  getCountryTripList(country: string) {
    var component = this;
    component.http.get<any[]>(component.baseUrl + 'api/Taiwan/GetTaiwanRegionTrips?countryCode=3&country=' + country).subscribe(
      result => {
        component.selectCountryName = country;
        component.taiwanSouthRegionTrips = result;
      });
  }
}

export interface TripInformation {
  tripId: string;
  imgUrl: string;
  tripDescription: string;
  tripName: string
  cost: number;
}

