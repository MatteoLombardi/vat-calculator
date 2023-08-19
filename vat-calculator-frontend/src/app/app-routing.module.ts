import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found.component';

const routes: Routes = [
  { path: '', redirectTo: 'calculator', pathMatch: 'full' },
  {
    path: 'calculator',
    loadChildren: () =>
      import('./calculator/modules/calculator.module').then(
        (m) => m.CalculatorModule
      ),
  },
  { path: '**', component: PageNotFoundComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
