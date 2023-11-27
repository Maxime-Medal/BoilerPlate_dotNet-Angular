
export interface ISkillDTO {
  id: string;
  competence: string;
  type: string;
  note: number;
}

export interface ISkill {
  id: string;
  name: string;
  type: string;
  level: number;
}

export class Skill implements ISkill {
  id: string;
  name: string;
  type: string;
  level: number;

  constructor(skill: ISkillDTO
  ) {
    this.id = skill.id;
    this.name = skill.competence;
    this.type = skill.type;
    this.level = skill.note;
  }
}
