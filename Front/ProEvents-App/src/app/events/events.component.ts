import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {

  public events: any = [
    {
      theme: 'Angular',
      local: 'Entroncamento'
    },
    {
      theme: '.Net5',
      local: 'Torres Novas'
    },
]

  constructor() { }

  ngOnInit(): void {
  }

}
