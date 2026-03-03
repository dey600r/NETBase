import { Component, inject, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { PagesModule } from './pages.module';
import { loadRemoteModule } from '@angular-architects/module-federation';
import { APP_CONFIG, AppConfig } from 'security-lib';
import { AppConstants } from '@app-utils/index';

@Component({
  selector: 'app-home',
  imports: [ PagesModule ],
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  
  private readonly _appConfig: AppConfig = inject(APP_CONFIG);
  @ViewChild('placeHolder', { read: ViewContainerRef }) viewContainer!: ViewContainerRef;
  private unmount?: () => void;
   
  async ngAfterViewInit() {
    try {
      const setting = this._appConfig.remotes.find(r => r.name === AppConstants.HOME_MODULE);
      const m = await loadRemoteModule({
        type: 'script',
        remoteEntry: setting?.remoteEntry || '',
        remoteName: setting?.name || '',
        exposedModule: setting?.exposedModule || '',
      });
      const fetch_el = document.getElementById('placeHolder');
      //const ref = this.viewContainer.createComponent(m.mount);
      const mount = m.mount;
      mount(fetch_el);

      this.unmount = () => m.unmount();
    } catch (error) {
        import('security-lib').then(m => this.viewContainer.createComponent(m.ErrorPageComponent));
    }
  }

  ngOnDestroy() {
    if (this.unmount) this.unmount();
  }
  async ngOnInit() {
    
  }
}
