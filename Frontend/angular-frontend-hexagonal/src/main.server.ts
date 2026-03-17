import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/adapters/ui/app.component';
import { buildServerConfiguration } from './app/adapters/ui/app.config.server';
import { environment } from '@environments/environment';

export async function loadAppConfig(path: string) {
  console.log('Loading config from path:', path);
  // ✅ Node (SSR)
  const { readFile } = await import('fs/promises');
  const { join } = await import('path');

  const filePath = join(process.cwd(), 'src/', path);
  const file = await readFile(filePath, 'utf-8');

  return JSON.parse(file);
}

export default async function bootstrap() {

  const config = await loadAppConfig(environment.configPath);

  return bootstrapApplication(
    AppComponent,
    buildServerConfiguration(config)
  );
}