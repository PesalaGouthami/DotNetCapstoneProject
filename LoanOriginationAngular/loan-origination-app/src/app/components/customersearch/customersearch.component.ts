import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customersearch } from 'src/app/models/customersearch/customersearch';
import { CustomersearchService } from 'src/app/services/customersearch/customersearch.service';

@Component({
  selector: 'customersearch',
  templateUrl: './customersearch.component.html',
  styleUrls: ['./customersearch.component.css']
})
export class CustomersearchComponent {
  firstName: string = '';
  lastName: string = '';
  dateOfBirth: string = '';
  customers: Customersearch[] = [];
  totalResults: number = 0;
  isHidden:boolean=true;
  constructor(
    private route: ActivatedRoute,
    private customerService: CustomersearchService,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.route.queryParams.subscribe(params => {
      this.firstName = params['firstName'] || '';
      this.lastName = params['lastName'] || '';
      this.dateOfBirth = params['dateOfBirth'] || '';

      if (this.firstName || this.lastName || this.dateOfBirth) {
        this.searchCustomers();
      }
    });
  }

  searchCustomers(): void {
    this.customerService.findCustomers(this.firstName, this.lastName, this.dateOfBirth)
      .subscribe(customers => {
        this.customers = customers;
        this.totalResults = customers.length;
        if(customers.length>0){
          this.isHidden=true;
        }else{
          this.isHidden=false;
        }
      });
  }

  addCustomer(){
    this.router.navigate(["/customer-detail"]);
  }
}
