create database loan_origination;


create table Users(
id serial primary key,
username varchar(20) not null,
firstname varchar(20) not null,
lastname varchar(20) not null,
pin varchar not null
);


create table Customer(
id serial primary key,
firstname varchar(20) not null,
lastname varchar(20) not null,
date_of_birth date not null,
phone char(10) not null,
email varchar(20) not null,
address varchar not null,
company_name varchar(20) not null,
salary decimal not null,
net_income decimal not null,
last_salary_date date not null
);


create table LoanApplication(
loan_id serial primary key,
customer_id int not null,
employee_id int not null,
loan_amount decimal not null,
loan_status varchar(20) not null,
date_of_request date not null,
loan_tenure int not null,
rate_of_intrest int not null,
foreign key(customer_id) references Customer(id),
foreign key(employee_id) references Users(id)
);


create table LoanHistory(
loan_id int primary key,
customer_id int not null,
status varchar(20) not null,
loan_amount decimal not null,
amount_paid decimal not null,
remaining_balance decimal not null,
due_date date null,
foreign key(loan_id) references LoanApplication(loan_id),
foreign key(customer_id) references Customer(id)
);

create table Transactions(
transaction_id serial primary key,
loan_id int not null,
amount_paid decimal not null,
date_of_transcation date not null,
foreign key(loan_id) references LoanApplication(loan_id)
);
