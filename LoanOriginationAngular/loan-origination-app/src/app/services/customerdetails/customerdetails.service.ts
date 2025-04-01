import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customerdetails } from 'src/app/models/customerdetails/customerdetails';


@Injectable({
  providedIn: 'root'
})
export class CustomerdetailsService {

 // http://localhost:5133/api/AddCustomer/AddCustomerDetails
 baseUrl:string = 'http://localhost:5133/api/';
 constructor(private http:HttpClient) { }
  
 AddCustomerDetails(customerdetails:any):Observable<any>{
     return this.http.post(this.baseUrl+'AddCustomer/AddCustomerDetails',customerdetails);
   } 
}
