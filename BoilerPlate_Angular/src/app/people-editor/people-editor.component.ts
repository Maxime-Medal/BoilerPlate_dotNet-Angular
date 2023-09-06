import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { PeopleService } from '../Services/people.service';
import { People } from '../Models/people';

@Component({
  selector: 'app-people-editor',
  templateUrl: './people-editor.component.html',
  styleUrls: ['./people-editor.component.css']
})
export class PeopleEditorComponent {
  get name() { return this.peopleForm.get('name'); }
  get job() { return this.peopleForm.get('job'); }
  get age() { return this.peopleForm.get('age'); }

  peopleForm = this._fb.group({
    name: ['', Validators.required],
    job: ['', Validators.required],
    age: ['', Validators.required],
  });

  constructor(
    private _fb: FormBuilder,
    private _peopleService: PeopleService) { }

  onSubmit() {
    const newPeople: People = {
      name: this.name.value,
      job: this.job.value,
      age: Number.parseInt(this.age.value)
    }
    this._peopleService.sendPeople(newPeople).subscribe(p => {
      if (p) {
        this._peopleService.getPeoples().subscribe();
      }
    })
  }

  getErrorMessage() {
    if (this.name.hasError('required')) {
      return 'You must enter a value';
    }

    return this.peopleForm.hasError('name') ? 'Not a valid name' : '';
  }
}
