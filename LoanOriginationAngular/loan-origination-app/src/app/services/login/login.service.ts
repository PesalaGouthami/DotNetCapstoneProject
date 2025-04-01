import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  // private apiUrl = 'http://localhost:5133/api/Account';

  constructor(private http: HttpClient) { }

  login(username: string, pin: string): Observable<any> {
    return this.http.post<any>(`http://localhost:5133/api/Account/Login/${username}/${pin}`, {});
  }
}
