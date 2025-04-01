import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
// import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { CustomerdetailsComponent } from './components/customerdetails/customerdetails.component';
import { CustomersearchComponent } from './components/customersearch/customersearch.component';
import { LoanhistoryComponent } from './components/loanhistory/loanhistory.component';
import { ApplyloanComponent } from './components/applyloan/applyloan.component';
import { DashboadComponent } from './components/dashboad/dashboad.component';
//import { AppRoutingModule } from './components/app-routing/app-routing.component';
import { RouterModule, Routes } from '@angular/router';
import { LoginService } from './services/login/login.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { ContentComponent } from './components/content/content.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboadComponent },
  { path: 'customer-detail', component: CustomerdetailsComponent },
  { path: 'customer-search', component: CustomersearchComponent },
  { path: 'apply-loan/:id', component: ApplyloanComponent },
  // { path: 'apply-loan', component: ApplyloanComponent },
  { path: 'loan-history', component: LoanhistoryComponent },
];
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CustomerdetailsComponent,
    CustomersearchComponent,
    LoanhistoryComponent,
    ApplyloanComponent,
    DashboadComponent,
    ContentComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  providers: [LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
