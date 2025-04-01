import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApplyloanService {
  baseUrl="http://localhost:5133/api/loan";
  constructor(private http:HttpClient) { }
  getNetIncome(id:number=1):Observable<any>{
    return this.http.get(this.baseUrl+'?customerId='+id);
  }
  addLoan(id:number,loan:any):Observable<any>{
    return this.http.post(this.baseUrl+'/calculate-and-add/'+id,loan);
  }

}
// baseUrl="http://localhost:5194/api/Contacts/";
//   constructor(private http:HttpClient) {
//    }
//    getContacts():Observable<Contact[]>{
//     return this.http.get<Contact[]>(this.baseUrl+'GetContacts');
//    }