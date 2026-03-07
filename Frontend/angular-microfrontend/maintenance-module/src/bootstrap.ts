import { bootstrapApplication } from '@angular/platform-browser';
import { buildConfiguration } from './app/app.config';
import { AppComponent } from './app/app.component';
import { loadAppConfig } from 'security-lib';
import { environment } from '@environments/environment';

(async () => {
  const config = await loadAppConfig(environment.configPath);
  
  await bootstrapApplication(AppComponent, buildConfiguration(config))
    .catch((err) => console.error(err));
})();
