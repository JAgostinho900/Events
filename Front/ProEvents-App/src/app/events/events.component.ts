import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {

  public events : any = [];
  public filteredEvents : any = [];
  widthImg : number = 100;
  showImages : boolean = true;

  private _searchText : string = "";
  public get searchText() : string {
    return this._searchText;
  }
  public set searchText(v : string) {
    this._searchText = v;
    this.filteredEvents = this.searchText ? this.filterEvents() : this.events;
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEvents();
  }

  //Get Events
  public getEvents(): void {
    this.http.get('https://localhost:5001/events').subscribe(
      response => {
        this.events = response;
        this.filteredEvents = response;
      },
      error => console.log(error)
    );
  }

  public ToggleImages(): void {
    this.showImages = !this.showImages;
  }

  private filterEvents(): any {
    let filterFor : string = this.searchText.toLowerCase();
    return this.events.filter(
      (event : {theme: string; local: string}) => event.theme.toLowerCase().indexOf(filterFor) !== -1 ||
      event.local.toLowerCase().indexOf(filterFor) !== -1
    );
  }
}
