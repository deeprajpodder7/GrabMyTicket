import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  qrValue!:string;
  constructor(
    private route:ActivatedRoute,

  ) { }

  ngOnInit(): void {
   this.route.params.subscribe((params: { [x: string]: string; })=> {this.qrValue = "Ticket:"+ params['paymentID'];});

  }

}
