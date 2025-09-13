import { loadRemoteModule } from '@angular-architects/module-federation';
import { Component, ElementRef, ViewChild, ViewContainerRef } from '@angular/core';
import { SettingsModule } from './settings.module';
import { AppConstants } from '@app-utils/index';
import { environment } from '@app-environments/environment';


@Component({
  selector: 'app-maintenance',
  imports: [ SettingsModule ],
  standalone: true,
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.scss'
})
export class SettingsComponent {

  @ViewChild('reactRoot', { static: true }) reactRoot!: ElementRef<HTMLDivElement>;
  @ViewChild('reactRoot', { read: ViewContainerRef })
  viewContainer!: ViewContainerRef; 
  
  private unmount?: () => void;

  async ngAfterViewInit() {
    try {
      const setting = environment.remotes.find(r => r.name === AppConstants.SETTING_MODULE)
      const m = await loadRemoteModule({
        type: 'script',
        remoteEntry: setting?.remoteEntry || '',
        remoteName: setting?.name || '',
        exposedModule: setting?.exposedModule || '',
      });

      const React = await import('react');
      const ReactDOM = await import('react-dom/client');

      const root = ReactDOM.createRoot(this.reactRoot.nativeElement);
      root.render(React.createElement(m.default));

      this.unmount = () => root.unmount();
    } catch (error) {
        import('security-lib').then(m => this.viewContainer.createComponent(m.ErrorPageComponent));
    }
  }

  ngOnDestroy() {
    if (this.unmount) this.unmount();
  }
}
