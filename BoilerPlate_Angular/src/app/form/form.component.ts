import { Component, OnInit } from '@angular/core';
import { PeopleService } from '../Services/people.service';
import { People } from '../Models/people';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  peoples: People[] = [];
  constructor(private _peopleService: PeopleService) {
  }

  ngOnInit() {
    this._peopleService.peoples$.subscribe(p => this.peoples = p);
  }
}
