import { Component, OnInit, inject, signal } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
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

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit() {
    this.personService.getList().subscribe((res) => {
      if (res && res.length) {
        this.dataSource = new MatTableDataSource(
          res.map((person, index) => {
            const target = person.skills[index];
            return {
              name: person.fullName,
              birthDate: person.age.toString(),
              type: target ? target.name : '🔎',
              skillName: target && target.type ? target.type : '🔎',
              level: target && target.level ? target.level : 0,
            };
          })
        );
      } else {
        this.dataSource = new MatTableDataSource(ELEMENT_DATA);
      }
      this.loading.set(false);
    });
  }
}
