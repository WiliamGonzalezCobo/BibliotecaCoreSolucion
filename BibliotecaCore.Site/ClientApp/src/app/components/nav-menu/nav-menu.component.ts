import { Component } from '@angular/core';
import { AuthService } from '../../service/auth.service';
import { Router } from '@angular/router';
import { ResponseAuth } from '../../model/response-auth';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  returnUrl = '/login';
  isExpanded = false;
  securityObject: ResponseAuth = null;


  constructor(
    private authService: AuthService,
    private router: Router
    ) {
      this.securityObject = this.authService.securityObject;
    }


  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logOut() {
    this.authService.logout();
  }
}
