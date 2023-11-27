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
import { ISkill } from '../models/skill.model';

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
  skillForm;
  model!: any;

  constructor(private fb: FormBuilder, private personService: PersonService) {
    this.personForm = this.fb.group({
      firstName: this.fb.control('', Validators.required),
      lastName: this.fb.control('', Validators.required),
      birthDate: this.fb.control('', [Validators.required, this.ageValidator(70)]),
      skills: this.fb.array([this.newSkill()]),
    });

    this.skillForm = this.fb.group({
      name: this.fb.control('', Validators.required),
      type: this.fb.control('', Validators.required),
    });
  }

  get skillsForm(): FormArray {
    return this.skillsForm.get('skills') as FormArray;
  }

  public onSubmit() {
    const personFormValue = this.personForm.getRawValue() as IPerson;
    const skillFormValue = this.skillForm.getRawValue() as ISkill;

    this.personService.createPerson(personFormValue).subscribe((personRes) => {
      console.log(personRes);
  
      // Associez la compétence à la personne (si nécessaire)
      if (personRes && personRes.id) {
        // Vous devrez peut-être ajuster cela en fonction de la structure de votre backend
        skillFormValue.id = personRes.id;
  
        // Soumettez la compétence
        this.personService.createSkill(skillFormValue).subscribe((skillRes) => {
          console.log(skillRes);
        });
      }
    });
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
