import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { PagesModule } from './pages.module';

@Component({
  selector: 'app-home',
  imports: [ PagesModule ],
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  constructor() {
  }

  // @ViewChild('placeHolder', { read: ViewContainerRef })
  //  viewContainer!: ViewContainerRef;

  async ngOnInit() {
    // const m = await import('vehicle-module/Component');
    // const ref = this.viewContainer.createComponent(m.AppComponent);
  }
}
