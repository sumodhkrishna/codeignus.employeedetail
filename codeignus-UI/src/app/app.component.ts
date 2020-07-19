import { Component } from '@angular/core';
import {AuthService} from './services/auth.service'
import {TokenStorageService} from './services/token-storage.service'
import { Router } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'codeignus-UI';
  items;
  checkoutForm;
  constructor(private authService: AuthService, private tokenStorgeService:TokenStorageService, public router: Router){}
  loginUser(formVal:any){
    this.authService.login(formVal).subscribe(data =>{
      this.tokenStorgeService.saveToken(data.token);
      if(data.token){
        alert("logged in successfully")
        this.router.navigate(['/home']);
      }
    
    }, error =>{
      alert("The user can't be found. Please register")
    })
  }
}
