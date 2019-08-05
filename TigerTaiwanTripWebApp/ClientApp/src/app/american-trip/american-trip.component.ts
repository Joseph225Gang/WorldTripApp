import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare let $: any;

@Component({
  selector: 'app-american-trip',
  templateUrl: './american-trip.component.html',
  styleUrls: ['../asia-trip/asia-trip.component.css'],
})
export class AmericanTripComponent implements OnInit{
  baseUrl: string;
  americanResult: string[] = [];
  americanRegionTrips: TripInformation[] = [];
  selectCountryName: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    var component = this;
    
          component.http.get<any[]>(component.baseUrl + 'api/AmericanContinent/GetAmericanCountries').subscribe(
            result => {
              component.americanResult = result;
            },
            error => { console.log(error); });
  }

  getCountryTripList(country: string) {
    var component = this;
    component.http.get<any[]>(component.baseUrl + 'api/AmericanContinent/GetSelectedAmericanTrips?country=' + country).subscribe(
          result => {
            component.selectCountryName = country;
            component.americanRegionTrips = result;
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

