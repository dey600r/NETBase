import { Component, inject, Input } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { Router } from '@angular/router';
// import { KeycloakService } from 'keycloak-angular';
// MODULES
import { SharedModule } from '@modules/shared.module';

// MODELS
import { UrlConstants } from '@utils/index';

// PORTS
import { LoginUIPort, ILoginUIPort } from '@ports/index';

@Component({
  selector: 'app-header',
  imports: [ SharedModule ],
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

  private readonly _loginPort: ILoginUIPort = inject(LoginUIPort);
  private readonly router: Router = inject(Router);

  @Input() drawer: MatDrawer | null = null;
  
  userName: string = '';
  userLocation: string = '';
  userRole: string[] = [];

  constructor() {
  }

  ngOnInit(): void {
    this._loginPort.user().then(user => {
        this.userName = `${user.firstName} ${user.lastName}`;
        this.userLocation = user.location;
        this.userRole = user.roles;
        //user.roles.forEach((x, index) => this.userRole += `${(index != 0 ? ',' : '')}${x}`);
      })
      .catch(err => console.error(err));
  }

  logout(): void {
    this._loginPort.logout();
  }

  navigateToHome(): void {
    this.router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
  }
}
