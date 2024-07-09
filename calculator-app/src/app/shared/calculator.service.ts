import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Calculator } from './calculator.model';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  url:string = environment.apiBaseUrl + '/Calculator'
  formData:Calculator = new Calculator
  constructor(private http:HttpClient) { }

  storeLeft(){
    if (this.formData.leftNumber != null) {
      const params = new HttpParams()
            .set('guid', this.formData.guid)
            .set('number', this.formData.leftNumber);
      this.http.post(this.url, null, { params }).subscribe(
        data => {
          this.formData.canAdd = (data as number[]).includes(0)
          this.formData.canSubtract = (data as number[]).includes(1)
          this.formData.canMultiply = (data as number[]).includes(2)
          this.formData.canDivide = (data as number[]).includes(3)
        }
      );
    }
    
  }

  storeRight(){
    if (this.formData.rightNumber != null) {
      const params = new HttpParams()
            .set('guid', this.formData.guid)
            .set('number', this.formData.rightNumber);
      this.http.post(this.url + '/' + this.formData.guid, null, { params }).subscribe(
        data => {
          this.formData.canAdd = (data as number[]).includes(0)
          this.formData.canSubtract = (data as number[]).includes(1)
          this.formData.canMultiply = (data as number[]).includes(2)
          this.formData.canDivide = (data as number[]).includes(3)
        }
      );
    }
  }

  calculate(operation:number){
    const params = new HttpParams()
        .set('guid', this.formData.guid)
        .set('operation', operation);
    this.http.put(this.url + '/' + this.formData.guid, null, { params }).subscribe(
      data => {
        if (data == null) {
          this.formData.leftNumber = null
          this.formData.rightNumber = null
        }
        this.formData.result = data as number
        this.formData.canAdd = false;
        this.formData.canSubtract = false;
        this.formData.canMultiply = false;
        this.formData.canDivide = false;
      }
    );
  }

}
