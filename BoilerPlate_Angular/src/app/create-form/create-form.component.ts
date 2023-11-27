import { Component, OnInit } from '@angular/core';

import {
  Validators,
  FormGroup,
  FormArray,
  FormsModule,
  FormBuilder,
} from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

import { IPerson, Person } from '../models/person.model';
import { PersonService } from '../services/person.service';
import { NgStyle } from '@angular/common';

@Component({
  selector: 'app-create-form',
  templateUrl: './create-form.component.html',
  styleUrls: ['./create-form.component.scss'],
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatButtonModule,
    MatIconModule,
    NgStyle,
  ],
})
export class CreateFormComponent {
  personForm;
  model = new Person('1', 'Tom', 'Cruise', new Date().toString(), []);

  constructor(private fb: FormBuilder, private personService: PersonService) {
    this.personForm = this.fb.group({
      firstName: this.fb.control('', Validators.required),
      lastName: this.fb.control('', Validators.required),
      birthDate: this.fb.control('', Validators.required),
      skills: this.fb.array([this.newJob()]),
    });
  }

  get skillsForm(): FormArray {
    return this.personForm.get('skills') as FormArray;
  }

  public onSubmit() {
    const form = this.personForm.getRawValue() as IPerson;
    form.skills = [];
    console.log(form);
    this.personService.createPerson(form).subscribe((res) => console.log(res));
  }

  public addJob() {
    this.skillsForm.push(this.newJob());
  }

  public removeJob(i: number) {
    this.skillsForm.removeAt(i);
  }

  private newJob(): FormGroup {
    return this.fb.group({
      name: this.fb.control('', Validators.required),
      skillName: this.fb.control('', Validators.required),
      startDate: this.fb.control('', Validators.required),
      endDate: this.fb.control(''),
    });
  }
}
