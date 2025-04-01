import { Component } from '@angular/core';
import { Customerdetails } from 'src/app/models/customerdetails/customerdetails';
import { CustomerdetailsService } from 'src/app/services/customerdetails/customerdetails.service';
@Component({
  selector: 'customerdetails',
  templateUrl: './customerdetails.component.html',
  styleUrls: ['./customerdetails.component.css']
})
export class CustomerdetailsComponent {
  customerdetails: Customerdetails={
    id:0,
    firstName: '',
    lastName: '',
    date_of_Birth : '',
    phone: '',
    email: '',
    address: '',
    company_Name: '',
    salary: 0,
    net_Income: 0,
    last_salary_date: '',
  };
  constructor(private service:CustomerdetailsService){}


  onSubmit() {
    console.log('Form Submitted:', this.customerdetails);
    
    this.service.AddCustomerDetails(this.customerdetails).subscribe(
      (data: any) => {
        console.log('Customer added:', data);
        // alert('Loan Application Submitted Successfully');
        alert(data.msg);
      },
      (error: any) => {
        console.error('error adding Customer details', error);
      }
    );
  }
    onCancel() {
    if (this.customerdetails) {
      this.customerdetails = {
        id: 0,
        firstName: '',
        lastName: '',
        date_of_Birth: '',
        phone: '',
        email: '',
        address: '',
        company_Name: '',
        salary: 0,
        net_Income: 0,
        last_salary_date: '',
      };
    }
  }
}
