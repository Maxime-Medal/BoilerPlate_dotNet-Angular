import { Component, OnInit, ViewChild, inject, signal } from '@angular/core';
import {
  MatTable,
  MatTableDataSource,
  MatTableModule,
} from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DatePipe } from '@angular/common';
import { PersonService } from '../services/person.service';
import { ELEMENT_DATA } from '../services/mock';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

export interface PeriodicElement {
  name: string;
  birthDate: string;
  level: number;
  type: string;
  skillName: string;
}

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
  standalone: true,
  imports: [
    DatePipe,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatProgressSpinnerModule,
  ],
})
export class TableComponent implements OnInit {
  personService = inject(PersonService);
  loading = signal(true);
  displayedColumns: string[] = [
    'name',
    // 'birthDate',
    'skillName',
    'type',
    'level',
  ];

  dataSource = new MatTableDataSource<PeriodicElement>([]);
  @ViewChild(MatTable) table!: MatTable<PeriodicElement>;

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filterPredicate = function (data, filter: string): boolean {
      return data.skillName.toLowerCase().includes(filter);
    };
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit() {
    this.personService.getAllPersonne().subscribe((res) => {
debugger
      if (res && res.length) {
        this.dataSource = new MatTableDataSource(
          res
            .map((person) => {
              const target = person.skills[0];

              return {
                name: person.fullName,
                birthDate: person.age.toString(),
                skillName: target && target.name ? target.name : '🔎',
                type: target ? target.type : '🔎',
                level: target && target.level ? target.level : 0,
              };
            })
            .sort((a, b) => {
              if (a.level !== b.level) {
                return a.level < b.level ? 1 : -1;
              } else {
                return !b.name.localeCompare(a.name) ? 1 : -1;
              }
            })
        );
      } else {
        this.dataSource = new MatTableDataSource(ELEMENT_DATA);
      }
      this.table.renderRows();
      this.loading.set(false);
    });
  }
}
