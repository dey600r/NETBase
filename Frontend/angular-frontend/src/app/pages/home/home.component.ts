import { Component } from '@angular/core';
import { SecurityService } from '@services/index';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  userName: string = '';

  constructor(private securityService: SecurityService) {
  }

  ngOnInit(): void {
    this.securityService.user()
      .then(user => this.userName = `${user.firstName} ${user.lastName}`)
      .catch(err => console.error(err));
  }

  logout(): void {
    this.securityService.logout();
  }
}
