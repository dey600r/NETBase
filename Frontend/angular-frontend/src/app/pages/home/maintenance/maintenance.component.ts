import { Component } from '@angular/core';
import { MaintenanceService } from '@app/core/services';
import { IConfigurationModel } from '@models/index';

@Component({
  selector: 'app-maintenance',
  templateUrl: './maintenance.component.html',
  styleUrl: './maintenance.component.scss'
})
export class MaintenanceComponent {

  displayedColumnsConfiguration: string[] = ['1', '2', '3', '4', '5'];
  dataSourceConfiguration: IConfigurationModel[] = [];

  constructor(private maintenanceService: MaintenanceService) {
    this.loadAllConfiguration();
  }

  loadAllConfiguration() {
    this.maintenanceService.getAllConfiguration().then(x => this.dataSourceConfiguration = x);
  }
}
