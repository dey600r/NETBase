import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/adapters/ui/app.config';
import { AppComponent } from './app/adapters/ui/app.component';

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
