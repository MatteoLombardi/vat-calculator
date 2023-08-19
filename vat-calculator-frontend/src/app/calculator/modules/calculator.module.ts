import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalculatorComponent } from '../components/calculator/calculator.component';
import { CalculatorRoutingModule } from './calculator-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [
    CalculatorComponent
  ],
  imports: [
    CommonModule,
    CalculatorRoutingModule,
    SharedModule
  ]
})
export class CalculatorModule { }
