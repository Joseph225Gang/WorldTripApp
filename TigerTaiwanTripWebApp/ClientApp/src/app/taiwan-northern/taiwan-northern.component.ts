import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare let $: any;

@Component({
  selector: 'app-taiwan-northern',
  templateUrl: './taiwan-northern.component.html',
  styleUrls: ['../asia-trip/asia-trip.component.css'],
})
export class TaiwanNorthernComponent implements OnInit{
  baseUrl: string;
  taiwanNorthResult: string[] = [];
  taiwanNorthRegionTrips: TripInformation[] = [];
  selectCountryName: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    var component = this;

    component.http.get<any[]>(component.baseUrl + 'api/Taiwan/GetTaiwanRegion?countryCode=1').subscribe(
      result => {
        component.taiwanNorthResult = result;
      },
      error => { console.log(error); });
  }

  getCountryTripList(country: string) {
    var component = this;
    component.http.get<any[]>(component.baseUrl + 'api/Taiwan/GetTaiwanRegionTrips?countryCode=1&country=' + country).subscribe(
      result => {
        component.selectCountryName = country;
        component.taiwanNorthRegionTrips = result;
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

