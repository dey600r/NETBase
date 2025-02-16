import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/adapters/ui/app.component';
import { config } from './app/adapters/ui/app.config.server';

const bootstrap = () => bootstrapApplication(AppComponent, config);

export default bootstrap;
