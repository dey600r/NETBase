import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/adapters/ui/app.component';
import { buildServerConfiguration } from './app/adapters/ui/app.config.server';
import { loadAppConfig } from '@providers/index';
import { environment } from '@environments/environment';

export default async function bootstrap() {

  const config = await loadAppConfig(environment.configPath);

  return bootstrapApplication(
    AppComponent,
    buildServerConfiguration(config)
  );
}