import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ExercisePageComponent } from './exercise-page/exercise-page.component';
import { WrongPageComponent } from './wrong-page/wrong-page.component';
import { FormComponent } from './form/form.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'Home', component: HomeComponent, pathMatch: 'full' },
  { path: 'Exercise', component: ExercisePageComponent, pathMatch: 'full' },
  { path: 'Form', component: FormComponent, pathMatch: 'full' },
  { path: '**', component: WrongPageComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
