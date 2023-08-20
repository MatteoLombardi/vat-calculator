import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Country } from '../../models/country.model';
import { Subscription } from 'rxjs';
import { NationService } from '../../services/nation.service';
import { map } from 'rxjs';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss'],
})
export class CalculatorComponent implements OnInit, OnDestroy {
  countrySelected: Country;
  vatRate: number = 0;
  subs: Subscription[] = [];
  calculatorForm = this.fb.group({
    netControl: ['', Validators.min(0.01)],
    vatRateControl: ['', Validators.min(0.01)],
    grossControl: ['', Validators.min(0.01)],
  });

  countries: Array<Country> = [];

  constructor(private fb: FormBuilder, private nationService: NationService) {}
  ngOnInit(): void {
    this.subs.push(
      this.nationService.retrieveCountries().subscribe((res) => {
        this.countries = res;
      })
    );
    this.subs.push(
      this.calculatorForm.controls.netControl.valueChanges.subscribe(
        (value) => {
          const vatValue: number = +value * (this.vatRate / 100);
          const grossValue: number = +value + vatValue;
          this.calculatorForm.controls.vatRateControl.setValue(
            vatValue.toFixed(2).toString(),
            { emitEvent: false }
          );
          this.calculatorForm.controls.grossControl.setValue(
            grossValue.toFixed(2).toString(),
            { emitEvent: false }
          );
        }
      )
    );

    this.subs.push(
      this.calculatorForm.controls.vatRateControl.valueChanges.subscribe(
        (value) => {
          const netValue: number = (+value * 100) / this.vatRate;
          const grossValue: number = +value + netValue;
          this.calculatorForm.controls.netControl.setValue(
            netValue.toFixed(2).toString(),
            { emitEvent: false }
          );
          this.calculatorForm.controls.grossControl.setValue(
            grossValue.toFixed(2).toString(),
            { emitEvent: false }
          );
        }
      )
    );

    this.subs.push(
      this.calculatorForm.controls.grossControl.valueChanges.subscribe(
        (value) => {
          const netValue: number = +value / (this.vatRate / 100 + 1);
          const vatValue: number = +value - netValue;
          this.calculatorForm.controls.netControl.setValue(
            netValue.toFixed(2).toString(),
            { emitEvent: false }
          );
          this.calculatorForm.controls.vatRateControl.setValue(
            vatValue.toFixed(2).toString(),
            { emitEvent: false }
          );
        }
      )
    );
  }

  ngOnDestroy(): void {
    this.subs.forEach((sub) => sub.unsubscribe());
  }

  resetVat() {
    this.vatRate = 0;
    this.resetForm();
  }

  resetForm() {
    this.calculatorForm.reset();
  }
}
