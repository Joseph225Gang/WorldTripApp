import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare let $: any;

@Component({
  selector: 'app-asia-trip',
  templateUrl: './asia-trip.component.html',
  styleUrls: ['./asia-trip.component.css'],
})
export class AsiaTripComponent implements OnInit{
  baseUrl: string;
  asiaRegion: string[] = ["無", "北亞", "東南亞", "南亞"];
  asiaResult: string[] = [];
  asiaRegionTrips: TripInformation[] = [];
  asiaIndex: number;
  selectCountryName: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  
  ngOnInit() {
    var component = this;
    $('button').click(function () {
      for (let selectRegionCode = 0; selectRegionCode < component.asiaRegion.length; selectRegionCode++)
        if (this.innerHTML == component.asiaRegion[selectRegionCode]) {
          component.asiaIndex = selectRegionCode;
          component.http.get<any[]>(component.baseUrl + 'api/AsiaContinent/GetAsiaCountries?countryCode=' + selectRegionCode).subscribe(
            result => {
              component.asiaResult = result;
            });
          break;
        }
    });
  }

  getCountryTripList(country: string) {
    var component = this;
    for (let selectRegionCode = 0; selectRegionCode < component.asiaRegion.length; selectRegionCode++)
      if (component.asiaIndex == selectRegionCode) {
        component.http.get<any[]>(component.baseUrl + 'api/AsiaContinent/GetSelectedAsiaTrips?countryCode=' + selectRegionCode + "&country=" + country).subscribe(
          result => {
            component.selectCountryName = country;
            component.asiaRegionTrips = result;
          });
        break;
      }
  }
}

export interface TripInformation {
  tripId: string;
  imgUrl: string;
  tripDescription: string;
  tripName: string
  cost: number;
}

