import { Component } from '@angular/core';
import { CalculatorService } from '../shared/calculator.service';
import { Calculator } from '../shared/calculator.model';
import { v4 as uuid } from 'uuid';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-calculator-form',
  templateUrl: './calculator-form.component.html',
  styleUrl: './calculator-form.component.css'
})
export class CalculatorFormComponent {

  calculator : Calculator = new Calculator();

  constructor(public service: CalculatorService){
    this.service.formData.guid = uuid();
  }

}
