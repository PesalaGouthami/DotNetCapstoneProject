import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customersearch } from 'src/app/models/customersearch/customersearch';

@Injectable({
  providedIn: 'root'
})
export class CustomersearchService {
  private apiUrl = 'http://localhost:5133/api/FindCustomer/customers/search/'; 

  constructor(private http: HttpClient) { }

  findCustomers(firstName: string, lastName: string, dateOfBirth: string): Observable<Customersearch[]> {
    return this.http.get<Customersearch[]>(this.apiUrl+firstName+'/'+lastName+'/'+dateOfBirth);
  }
}
