import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare let $: any;

@Component({
  selector: 'app-european-trip',
  templateUrl: './european-trip.component.html',
  styleUrls: ['../asia-trip/asia-trip.component.css'],
})
export class EuropeanTripComponent implements OnInit{
  baseUrl: string;
  europeRegion: string[] = ["無", "西", "南"];
  europeResult: string[] = [];
  europeRegionTrips: TripInformation[] = [];
  europeIndex: number;
  selectCountryName: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    var component = this;
    $('button').click(function () {
      for (let selectRegionCode = 0; selectRegionCode < component.europeRegion.length; selectRegionCode++)
        if ($(this).text() == component.europeRegion[selectRegionCode]) {
          component.europeIndex = selectRegionCode;
          component.http.get<any[]>(component.baseUrl + 'api/EuropeContinent/GetEuropeCountries?countryCode=' + selectRegionCode).subscribe(
            result => {
              component.europeResult = result;
            },
            error => { console.log(error); });
          break;
        }
    });
  }

  getCountryTripList(country: string) {
    var component = this;
    for (let selectRegionCode = 0; selectRegionCode < component.europeRegion.length; selectRegionCode++)
      if (component.europeIndex == selectRegionCode) {
        component.http.get<any[]>(component.baseUrl + 'api/EuropeContinent/GetSelectedEuropeTrips?countryCode=' + selectRegionCode + "&country=" + country).subscribe(
          result => {
            component.selectCountryName = country;
            component.europeRegionTrips = result;
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

