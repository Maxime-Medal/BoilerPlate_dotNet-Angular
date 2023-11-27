export interface ISkill {
  id: string;
  name: string;
  type: string;
  level: number;
}

export class Skill implements ISkill {
  constructor(
    public id: string,
    public name: string,
    public type: string,
    public level: number
  ) {}
}
