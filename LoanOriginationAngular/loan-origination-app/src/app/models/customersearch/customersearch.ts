export class Customersearch {
    id : number=0;
    firstName : string = '';
    lastName : string = '';
    date_of_Birth : string = '';
    email : string = '';
    phone : string = '';
    address : string = '';
    company_Name : string = '';
    salary : number = 0;
    net_Income : number = 0;
    last_salary_date : string = '';

    constructor(id : number, firstName : string, lastName : string, dateOfBirth : string, email : string, phone : string, address : string, companyName : string, salary : number, netIncome : number, lastSalaryDate : string) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.date_of_Birth = dateOfBirth;
        this.email = email;
        this.phone = phone;
        this.address = address;
        this.company_Name = companyName;
        this.salary = salary;
        this.net_Income = netIncome;
        this.last_salary_date = lastSalaryDate;
    }

}
