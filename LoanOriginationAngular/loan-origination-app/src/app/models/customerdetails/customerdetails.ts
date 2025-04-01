export class Customerdetails {
    id: number=0;
  firstName: string='';
  lastName: string='';
  date_of_Birth ?: string='';
  phone: string='';
  email: string='';
  address: string='';
  company_Name: string='';
  salary: number=0;
  net_Income: number=0;
  last_salary_date: string='';

  constructor( id: number, firstName: string,lastName: string,date_of_Birth : string,
    phone: string,email: string,address: string,company_Name: string,salary: number,
    net_Income: number, last_salary_date: string){
        this.id=id;
        this.firstName=firstName;
        this.lastName=lastName;
        this.date_of_Birth=date_of_Birth;
        this.phone=phone;
        this.email=email;
        this.address=address;
        this.company_Name=company_Name;
        this.salary=salary;
        this.net_Income=net_Income;
        this.last_salary_date=last_salary_date
}
}