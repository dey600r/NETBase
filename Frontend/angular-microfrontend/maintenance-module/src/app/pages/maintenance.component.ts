import { Component, inject } from '@angular/core';


import { DialogMaintenanceAddComponent } from './dialog-maintenance-add/dialog-maintenance-add.component';
import { MaintenanceModule } from './maintenance.module';

// MODELS
import { IConfigurationModel, IMaintenanceElementModel } from '@models/index';

// HELPERS
import { MaterialService } from 'security-lib';

// PORTS
import { MaintenanceService } from '@services/index';

@Component({
  selector: 'app-maintenance',
  imports: [ MaintenanceModule ],
  standalone: true,
  templateUrl: './maintenance.component.html',
  styleUrl: './maintenance.component.scss'
})
export class MaintenanceComponent {

  // INJECTABLES
  private readonly _materialService: MaterialService = inject(MaterialService);
  private readonly _maintenanceService: MaintenanceService = inject(MaintenanceService);

  displayedColumnsMaintenanceElement: string[] = ['0', '1', '2', '3', '4', '5', '6'];
  dataSourceMaintenanceElement: IMaintenanceElementModel[] = [];

  displayedColumnsConfiguration: string[] = ['1', '2', '3', '4', '5'];
  dataSourceConfiguration: IConfigurationModel[] = [];

  constructor() {
    this.loadAllMaintenanceElement();
    this.loadAllConfiguration();
  }

  loadAllMaintenanceElement() {
    this._maintenanceService.getAllMaintenanceElement().then(x => this.dataSourceMaintenanceElement = x);
  }

  loadAllConfiguration() {
    this._maintenanceService.getAllConfiguration().then(x => this.dataSourceConfiguration = x);
  }

  openDialog(index: number = -1) {
    let dialogRef = this._materialService.openDialog(DialogMaintenanceAddComponent, {
      data: (index > -1 ? this.dataSourceConfiguration[index] : null),
      height: '400px',
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this._maintenanceService.addMaintenanceElement(result).then(result => {
          if(result) {
            this._materialService.openSnackBar('Maintenance Element saved succesfully!!');
            this.loadAllMaintenanceElement();
          }
        }).catch(err => {
          this._materialService.openSnackBar('Error on server side');
        });
      }
    });
  }
}
