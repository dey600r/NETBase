import { Component } from '@angular/core';
import { SecurityService } from '@services/index';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  constructor(private securityService: SecurityService) {

  }

  ngOnInit(): void {
    this.securityService.user().then(user => console.log(user)).catch(err => console.error(err));
  }
}
