import { Component, Inject, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare let $: any;


@Component({
  selector: 'app-trip-type',
  templateUrl: './trip-type.component.html',
})
export class TripTypeComponent implements OnInit{
  tripType: string[] = [];
  selectTripType: number = 0;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any[]>(baseUrl + 'api/TripType/GetTotalTripType').subscribe(result => {
      for (let i = 0; i < result.length; i++) {
        if (typeof (result[i][i]) == 'undefined')
          break;
        this.tripType.push(result[i][i])
      }
    }, error => console.error(error));
  }
  
  ngOnInit() {
    $(document).ready(function () {
      $("#datepicker").datepicker();
      });
  }
  
  selectTrip() {
    alert(this.selectTripType);
  }

  submit() {
    //alert(document.getElementById('datepicker').value)
  }
}

