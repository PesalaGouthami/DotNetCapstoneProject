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




create table LoanHistory(
loan_id int primary key,
status varchar(20) not null,
loan_amount decimal not null,
amount_paid decimal not null,
remaining_balance decimal not null,
due_date date null,
foreign key(loan_id) references LoanApplication(loan_id)

);

create table Transactions(
transaction_id serial primary key,
loan_id int not null,
amount_paid decimal not null,
date_of_transcation date not null,
foreign key(loan_id) references LoanApplication(loan_id)
);

INSERT INTO Users (username, firstname, lastname, pin) VALUES
('johndoe', 'John', 'Doe', '1234'),
('janedoe', 'Jane', 'Doe', '5678'),
('alicew', 'Alice', 'Williams', '9101'),
('bobm', 'Bob', 'Marley', '1122'),
('ellasmith', 'Ella', 'Smith', '3344');

INSERT INTO Customer (firstname, lastname, date_of_birth, phone, email, address, company_name, salary, net_income, last_salary_date) VALUES
('John', 'Doe', '1990-05-15', '9876543210', 'john.doe@gmail.com', '123 Main St, Cityville', 'TechCorp', 75000, 65000, '2025-03-31'),
('Jane', 'Smith', '1985-10-20', '8765432109', 'jane.smith@gmail.com', '456 Elm St, Townsville', 'HealthInc', 82000, 70000, '2025-03-28'),
('Alice', 'Johnson', '1992-01-10', '7654321098', 'alice.j@gmail.com', '789 Oak St, Village', 'EduWorld', 64000, 58000, '2025-03-25'),
('Bob', 'Brown', '1988-07-25', '6543210987', 'bob.brown@gmail.com', '101 Pine St, Metro City', 'FinancePro', 90000, 78000, '2025-03-30'),
('Ella', 'Davis', '1995-03-05', '5432109876', 'ella.davis@gmail.com', '202 Birch St, Seaside', 'DesignStudio', 58000, 51000, '2025-03-29');

select * from customer;
select * from loanapplication;
select * from users;
delete from users;

insert into users(username,firstname,lastname,pin) values ('Gouthami','Gouthami','Pesala','abcd1234');

INSERT INTO public.loanhistory (loan_id, status, loan_amount, amount_paid, remaining_balance, due_date) VALUES
(1, 'Active', 50000.00, 10000.00, 40000.00, '2025-06-30'),
(2, 'Closed', 75000.00, 75000.00, 0.00, '2024-12-31'),
(6, 'Defaulted', 30000.00, 15000.00, 15000.00, '2023-11-15'),
(4, 'Active', 100000.00, 25000.00, 75000.00, '2025-09-01'),
(5, 'Closed', 45000.00, 45000.00, 0.00, '2024-05-20');



INSERT INTO public.transactions (loan_id, amount_paid, date_of_transcation) VALUES
(1, 5000.00, '2025-01-15'),
(1, 75000.00, '2024-12-31'),
(4, 10000.00, '2023-10-10'),
(2, 25000.00, '2025-02-20'),
(2, 45000.00, '2024-05-20');