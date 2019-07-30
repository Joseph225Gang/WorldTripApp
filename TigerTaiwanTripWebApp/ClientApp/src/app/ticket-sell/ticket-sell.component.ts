import { Component, Inject, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { TicketSellInService } from './ticket-sell.service';
declare let $: any;

@Component({
  selector: 'app-ticket-sell',
  templateUrl: './ticket-sell.component.html',
  providers: [TicketSellInService],
})
export class TicketSellComponent implements OnInit{
  baseUrl: string;
  http: HttpClient;
  tickets: Ticket[] = [];
  tripName: string;
  Step = Step;
  step: Step = Step.One;
  payment: PaymentMethod;
  adultTicketNum: number = 0;
  childTicketNum: number = 0;
  userName: string = "";

  constructor(private ticketSellService: TicketSellInService, private route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  isLogin() {
    return this.userName.length > 2 ? true: false;
  }

  ngOnInit() {
    var component = this;
    var sub = this.route.params.subscribe(params => {
      let trip: TripInformation = params as TripInformation;
      this.tripName = trip.tripName;
      this.userName = localStorage.getItem("login");
      this.http.get<any[]>(this.baseUrl + 'api/TripTicket/GetRelevantTicket?tripName=' + trip.tripName).subscribe(result => {
        this.tickets = result;
      });
    });
  }

  goToStep2() {
    this.adultTicketNum = $("#adultTicketNumber").val();
    this.childTicketNum = $("#childrenTicketNumber").val();
    this.step = Step.Two;
  }

  goToStep3() {
    this.payment = $("input[name='payment']:checked").val();
    this.step = Step.Three;
  }

  goToStep4() {
    let transaction: Transaction = new Transaction();
    transaction.memberName = this.userName;
    transaction.tripName = this.tripName;
    transaction.paymentMethod = this.payment;
    transaction.adultTicket = this.adultTicketNum;
    transaction.childTicket = this.childTicketNum;
    transaction.totalAmount = this.tickets.filter(i => i.ticketType = TicketType.Adult)[0].amount * this.adultTicketNum
      + this.tickets.filter(i => i.ticketType = TicketType.Child)[0].amount * this.childTicketNum;
    console.log(transaction);
    this.ticketSellService.addTransaction(transaction).subscribe(result => {
      this.step = Step.Four;
    },
      error => {
        alert(error);
      })
  }
}

export interface TripInformation {
  tripId: string;
  imgUrl: string;
  tripDescription: string;
  tripName: string
  cost: number;
}

export interface Ticket {
  ticketId: string;
  paymentExpireDay: Date;
  travelStrateDate: Date;
  amount: number;
  ticketType: TicketType;
  tripName: string;
}

export class Transaction {
  id: string;
  memberName: string;
  paymentMethod: PaymentMethod;
  tripName: string;
  adultTicket: number;
  childTicket: number;
  totalAmount: number;
}

export enum PaymentMethod {
  None = 0,
  Visa,
  Master,
  ATM,
  SevenEleven
}

export enum TicketType {
  None = 0,
  Child,
  Adult
}

export enum Step {
  One = 1,
  Two,
  Three,
  Four
}

