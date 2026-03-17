import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/adapters/ui/app.component';
import { loadAppConfig } from '@providers/index';
import { environment } from '@environments/environment';
import { buildConfiguration } from '@adapters/ui/app.config';

(async () => {
  const config = await loadAppConfig(environment.configPath);
  
  await bootstrapApplication(AppComponent, buildConfiguration(config))
    .catch((err) => console.error(err));
})();