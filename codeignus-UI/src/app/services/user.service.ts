import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Constants } from '../constants';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }


  getusers():Observable<any>{
    return this.http.get(Constants.API + 'User',Constants.HTTP_OPTIONS);
  }
  register(user): Observable<any> {
    user.role = "Admin";
  
    return this.http.post(Constants.API + 'User', 
      user
    , Constants.HTTP_OPTIONS);
  }
}
