import { LoginComponent } from './../../login/login.component';
import { Component, OnInit } from '@angular/core';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {


  constructor(private LoginModal: NgbModal) { }

  ngOnInit(): void {
  }

  login(){
    this.LoginModal.open(LoginComponent, {centered: true})
  }
}
