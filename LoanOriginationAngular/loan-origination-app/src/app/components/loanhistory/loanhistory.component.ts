import { Component } from '@angular/core';
import { LoanhistoryService } from 'src/app/services/loanhistory/loanhistory.service';


@Component({
  selector: 'loanhistory',
  templateUrl: './loanhistory.component.html',
  styleUrls: ['./loanhistory.component.css']
})
export class LoanhistoryComponent {
  customerId: number = 0;
  loanHistory: any[] = [];
  transactions: { [key: number]: any[] } = {}; 
  selectedLoanId: number | null = null; 
  hasSearched: boolean = false; 
 
 

  constructor(private service:LoanhistoryService) {}

  getLoanHistory() {
    this.hasSearched = true; 
    this.selectedLoanId = null; 
    this.service.getLoanHistory(this.customerId).subscribe(
      (data: any) => {
        this.loanHistory = data.data; 
        console.log('Loan History:', this.loanHistory);
      },
      error => {
        this.loanHistory = []; 
        console.error('Error fetching loan history:', error);
        
      }
    );
  }

  getTransactionHistory(loanId: number) {
   
    if (this.selectedLoanId === loanId) {
      
      this.selectedLoanId = null;
    } else {
     
      this.selectedLoanId = loanId;

      if (!this.transactions[loanId]) {
       
        this.service.getTransactions(loanId).subscribe(
          (data: any) => {
            this.transactions[loanId] = data.data; 
            console.log(`Transactions for Loan ID ${loanId}:`, this.transactions[loanId]);
          },
          error => {
            this.transactions[loanId] = [];
            console.error('Error fetching transcations:', error);
          }
        );
      }
    }
  }
}
