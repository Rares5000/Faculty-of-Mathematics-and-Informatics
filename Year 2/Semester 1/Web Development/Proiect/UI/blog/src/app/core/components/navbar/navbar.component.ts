import { Component, OnDestroy, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { User } from 'src/app/features/auth/models/user.model';
import { AuthService } from 'src/app/features/auth/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.sass']
})
export class NavbarComponent implements OnInit, OnDestroy {
  user?: User;

  constructor(private authService: AuthService, private router: Router)
  {

  }
  
  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }
  ngOnInit(): void {
    this.authService.user()
    .subscribe({
      next: (response) => {
        this.user = response;
      }
    });

    this.user = this.authService.getUser();
  }

  onLogout(): void {
    this.authService.logout();
    this.router.navigateByUrl('/');
  }

}
