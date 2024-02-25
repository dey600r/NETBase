import { Component } from '@angular/core';
import { MaintenanceService, MaterialService } from '@services/index';
import { IConfigurationModel, IMaintenanceElementModel } from '@models/index';
import { DialogMaintenanceAddComponent } from './dialog-maintenance-add/dialog-maintenance-add.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-maintenance',
  templateUrl: './maintenance.component.html',
  styleUrl: './maintenance.component.scss'
})
export class MaintenanceComponent {

  displayedColumnsMaintenanceElement: string[] = ['0', '1', '2', '3', '4', '5', '6'];
  dataSourceMaintenanceElement: IMaintenanceElementModel[] = [];

  displayedColumnsConfiguration: string[] = ['1', '2', '3', '4', '5'];
  dataSourceConfiguration: IConfigurationModel[] = [];

  constructor(private maintenanceService: MaintenanceService,
              private materialService: MaterialService,
              private dialog: MatDialog) {
    this.loadAllMaintenanceElement();
    this.loadAllConfiguration();
  }

  loadAllMaintenanceElement() {
    this.maintenanceService.getAllMaintenanceElement().then(x => this.dataSourceMaintenanceElement = x);
  }

  loadAllConfiguration() {
    this.maintenanceService.getAllConfiguration().then(x => this.dataSourceConfiguration = x);
  }

  openDialog(index: number = -1) {
    let dialogRef = this.dialog.open(DialogMaintenanceAddComponent, {
      data: (index > -1 ? this.dataSourceConfiguration[index] : null),
      height: '400px',
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.maintenanceService.addMaintenanceElement(result).then(result => {
          if(result) {
            this.materialService.openSnackBar('Maintenance Element saved succesfully!!');
            this.loadAllMaintenanceElement();
          }
        }).catch(err => {
          this.materialService.openSnackBar('Error on server side');
        });
      }
    });
  }
}
