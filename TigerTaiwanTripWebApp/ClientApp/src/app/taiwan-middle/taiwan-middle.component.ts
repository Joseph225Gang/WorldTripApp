import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare let $: any;

@Component({
  selector: 'app-taiwan-middle',
  templateUrl: './taiwan-middle.component.html',
  styleUrls: ['../asia-trip/asia-trip.component.css'],
})
export class TaiwanMiddleComponent implements OnInit{

  baseUrl: string;
  taiwanMiddleResult: string[] = [];
  taiwanMiddleRegionTrips: TripInformation[] = [];
  selectCountryName: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    var component = this;

    component.http.get<any[]>(component.baseUrl + 'api/Taiwan/GetTaiwanRegion?countryCode=2').subscribe(
      result => {
        component.taiwanMiddleResult = result;
      },
      error => { console.log(error); });
  }

  getCountryTripList(country: string) {
    var component = this;
    component.http.get<any[]>(component.baseUrl + 'api/Taiwan/GetTaiwanRegionTrips?countryCode=2&country=' + country).subscribe(
      result => {
        component.selectCountryName = country;
        component.taiwanMiddleRegionTrips = result;
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

