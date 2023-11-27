import { Component, WritableSignal, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './core/header/header.component';
import { TableComponent } from './table/table.component';
import { CreateFormComponent } from './create-form/create-form.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    CreateFormComponent,
    TableComponent,
    MatButtonModule,
    MatIconModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'RH-WAPP-Front';

  displayForm: WritableSignal<boolean> = signal(false);
}
