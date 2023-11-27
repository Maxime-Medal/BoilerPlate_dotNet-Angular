import { Component } from '@angular/core';

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
import { AbstractControl, ValidatorFn } from '@angular/forms';

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
      birthDate: this.fb.control('', [Validators.required, this.ageValidator(70)]),
      skills: this.fb.array([this.newSkill()]),
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

  public addSkill() {
    this.skillsForm.push(this.newSkill());
  }

  public removeSkill(i: number) {
    this.skillsForm.removeAt(i);
  }

  private newSkill(): FormGroup {
    return this.fb.group({
      name: this.fb.control('', Validators.required),
      level: this.fb.control('', Validators.required),
      type: this.fb.control('', Validators.required),
    });
  }

  private ageValidator(maxAge: number): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const birthDate = new Date(control.value);
      const currentDate = new Date();
      const age = currentDate.getFullYear() - birthDate.getFullYear();

      return age <= maxAge ? null : { 'invalidAge': { value: control.value } };
    };
  }
}
