import { Component } from '@angular/core';
import { PagesModule } from './pages.module';

@Component({
  selector: 'app-home',
  imports: [ PagesModule ],
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  constructor() {
  }

  ngOnInit(): void {
  }
}
