import { Component, OnInit, ViewChild } from '@angular/core';
import {UserService} from '../services/user.service';
import { from } from 'rxjs';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public tableData: any[];
  public displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  public dataSource:any;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.userService.getusers().subscribe(data => {
      this.dataSource =new MatTableDataSource(data) ;
      this.dataSource.sort = this.sort;
      console.log(this.dataSource);
    })
  }



}
