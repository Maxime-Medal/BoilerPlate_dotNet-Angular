import { ISkill, ISkillDTO, Skill } from './skill.model';

export interface IPersonDTO {
  id: string;
  nom: string;
  prenom: string;
  dateNaissance: string;
  evaluations: ISkillDTO[];
}

export interface IPerson {
  id: string;
  lastName: string;
  firstName: string;
  birthDate: string;
  skills: ISkill[];
}


export class Person implements IPerson {
  id: string;
  lastName: string;
  firstName: string;
  birthDate: string;
  skills: ISkill[];

  constructor(person: IPersonDTO) {
    this.id = person.id,
      this.lastName = person.nom,
      this.firstName = person.prenom,
      this.birthDate = person.dateNaissance,
      this.skills = person.evaluations.map(e => new Skill(e))
  }

  get fullName() {
    return `${this.firstName} ${this.lastName}`;
  }

  get age() {
    const ageDifMs = Date.now() - new Date(this.birthDate).getTime();
    const ageDate = new Date(ageDifMs); // miliseconds from epoch
    return Math.abs(ageDate.getUTCFullYear() - 1970);
  }
}
