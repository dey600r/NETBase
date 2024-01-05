import { Component, Input } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { UrlConstants } from '@utils/index';
import { SecurityService } from '@services/index';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

  @Input() drawer: MatDrawer | null = null;
  
  userName: string = '';
  userLocation: string = '';
  userRole: string = '';

  constructor(private securityService: SecurityService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.securityService.user()
      .then(user => {
        this.userName = `${user.firstName} ${user.lastName}`;
        this.userLocation = user.location;
        user.roles.forEach((x, index) => this.userRole += `${(index != 0 ? ',' : '')}${x}`);
      })
      .catch(err => console.error(err));
  }

  logout(): void {
    this.securityService.logout();
  }

  navigateToHome(): void {
    this.router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
  }
}
