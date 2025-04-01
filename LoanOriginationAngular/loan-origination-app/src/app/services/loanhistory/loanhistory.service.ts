import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Loanhistory } from 'src/app/models/loanhistory/loanhistory';
import { Transactions } from 'src/app/models/loanhistory/Transcations';

@Injectable({
  providedIn: 'root'
})
export class LoanhistoryService {

  baseUrl="http://localhost:5133/api/LoanHistory/";
  constructor(private http:HttpClient) {
   }
    

   

   getLoanHistory(customerId: number=1): Observable<Loanhistory> {
    return this.http.get<Loanhistory>(`${this.baseUrl}GetLoanHistoryByCustomerId/${customerId}`);
  }


  getTransactions(loanId: number=1): Observable<Transactions> {
    return this.http.get<Transactions>(`${this.baseUrl}GetTransactionsByLoanId/${loanId}`);
  }
  
  

}
