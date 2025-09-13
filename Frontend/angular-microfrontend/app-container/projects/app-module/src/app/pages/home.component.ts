import { Component, ElementRef, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { PagesModule } from './pages.module';
import { loadRemoteModule } from '@angular-architects/module-federation';

@Component({
  selector: 'app-home',
  imports: [ PagesModule ],
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  

  // @ViewChild('placeHolder', { read: ViewContainerRef })
  //  viewContainer!: ViewContainerRef;

  async ngOnInit() {
    // const m = await import('vehicle-module/Component');
    // const ref = this.viewContainer.createComponent(m.AppComponent);
  }
}
