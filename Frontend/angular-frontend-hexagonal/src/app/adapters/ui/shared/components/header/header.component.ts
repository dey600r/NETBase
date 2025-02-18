import { Component, inject, Input } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { UrlConstants } from '@utils/index';
import { SharedModule } from '@modules/shared.module';
// import { KeycloakService } from 'keycloak-angular';

// import { ISecurityApiPort } from '@ports/index';

@Component({
  selector: 'app-header',
  imports: [ SharedModule ],
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

  //private securityService: ISecurityApiPort = inject(SecurityService);
  private readonly router: Router = inject(Router);

  @Input() drawer: MatDrawer | null = null;
  
  userName: string = '';
  userLocation: string = '';
  userRole: string[] = [];

  constructor() {
  }

  ngOnInit(): void {
  //   this.securityService.user()
  //     .then(user => {
  //       this.userName = `${user.firstName} ${user.lastName}`;
  //       this.userLocation = user.location;
  //       this.userRole = user.roles;
  //       //user.roles.forEach((x, index) => this.userRole += `${(index != 0 ? ',' : '')}${x}`);
  //     })
  //     .catch(err => console.error(err));
  }

  logout(): void {
    //this.securityService.logout();
  }

  navigateToHome(): void {
    this.router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
  }
}
