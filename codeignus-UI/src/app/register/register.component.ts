import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(private userService:UserService) { }

  ngOnInit(): void {
  }
  registerUser(data:any){
    this.userService.register(data).subscribe(data => {
      alert("Registration successful now you can login")
    })
  }
}
