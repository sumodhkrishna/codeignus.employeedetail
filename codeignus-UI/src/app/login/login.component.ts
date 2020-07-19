import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../services/token-storage.service';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  ngOnInit(): void {
  }

  constructor(private authService: AuthService, private tokenStorgeService:TokenStorageService, public router: Router){}
  loginUser(formVal:any){
    this.authService.login(formVal).subscribe(data =>{
      this.tokenStorgeService.saveToken(data.token);
      this.tokenStorgeService.saveUser(data);
      if(data.token){
        this.router.navigate(['/home']);
      }
    
    }, error =>{
      alert("The user can't be found. Please register")
    })
  }
}
