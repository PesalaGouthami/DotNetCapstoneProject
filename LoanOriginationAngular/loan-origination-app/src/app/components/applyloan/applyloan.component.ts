import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApplyloanService } from 'src/app/services/applyloan/applyloan.service';

@Component({
  selector: 'applyloan',
  templateUrl: './applyloan.component.html',
  styleUrls: ['./applyloan.component.css']
})
export class ApplyloanComponent {
  title = 'Loan Calculation';
  customer_id: number = 0;
  employee_id:number=0;
  date_of_request:Date=new Date();
  net_income: number = 0;
  loan_status:string='pending';
  maxLoanAmount: number = 0;
  suggestedLoanAmount: number = 0;
  loan_amount: number = 0;
  loan_tenure: number = 24;
  rate_of_intrest: number = 6;
  showLoanForm: boolean = false;
  emi: number = 0;
  link:string="http://localhost:5133/api/loan/calculate-and-add/"
  constructor(private http:HttpClient,private loanservice:ApplyloanService,private route:ActivatedRoute){
  }
  
  fetchNetIncome() {
    this.loanservice.getNetIncome(this.customer_id).subscribe(data => {
      this.net_income = data;
      console.log(data);
      console.log(this.net_income);
      if(!data){
        alert("Customer doesnot exist");
      }
      this.calculateLoanAmount();
    });
  }
 

  calculateLoanAmount() {
    this.suggestedLoanAmount = Math.round(this.net_income / 3); 
    this.maxLoanAmount = Math.round(this.net_income / 2); 
    // this.loan_amount = this.suggestedLoanAmount;
    // console.log(this.loan_amount)
}
ngOnInit(): void {
  // Fetch the customerId from the route
  this.route.params.subscribe((params) => {
    this.customer_id = +params['id'];
    this.fetchNetIncome(); // Fetch net income based on customerId
});
}
calculateEMI() {
  const principal = this.loan_amount;
  const interestRate = this.rate_of_intrest / 12 / 100;
  const tenure = this.loan_tenure;
  this.emi = Math.round((principal * interestRate * Math.pow(1 + interestRate, tenure)) / (Math.pow(1 + interestRate, tenure) - 1));
}

  proceed() {
    this.showLoanForm = true;
  }
  submitLoan() {
    const loanData = {
      CustomerId: this.customer_id,
      LoanAmount: this.loan_amount,
      LoanTenure: this.loan_tenure,
      EmployeeId:this.employee_id,
      RateOfIntrest:this.rate_of_intrest,
      DateOfRequest:this.date_of_request.toJSON,
      LoanStatus:this.loan_status,
    };
    console.log(loanData);
    this.loanservice.addLoan(this.customer_id,loanData).subscribe(response => {
      alert('Loan application submitted successfully');
    });
  }
  cancel() {
    alert('Loan application cancelled');
  } 
}
