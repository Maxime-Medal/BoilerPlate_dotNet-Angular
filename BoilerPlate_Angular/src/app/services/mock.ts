import { PeriodicElement } from '../table/table.component';

export const ELEMENT_DATA: PeriodicElement[] = [
  {
    birthDate: new Date().toISOString(),
    level: Math.floor(Math.random() * (5 - 1 + 1) + 1),
    name: 'Hydrogen',
    type: '1.0079',
    skillName: 'H',
  },
  {
    birthDate: new Date().toISOString(),
    level: Math.floor(Math.random() * (5 - 1 + 1) + 1),
    name: 'Hydrogen',
    type: '1.0079',
    skillName: 'H',
  },
];
