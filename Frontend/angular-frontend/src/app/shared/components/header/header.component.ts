import { Component } from '@angular/core';
import { SecurityService } from '@services/index';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  
  userName: string = '';
  userLocation: string = '';
  userRole: string = '';

  constructor(private securityService: SecurityService) {
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
}
