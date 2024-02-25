import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IConfigurationModel, IMaintenanceElementModel, IVehicleTypeModel } from '@models/index';
import { MaterialService, VehicleService } from '@services/index';
import { DialogConfigurationAddComponent } from './dialog-configuration-add/dialog-configuration-add.component';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrl: './vehicle.component.scss'
})
export class VehicleComponent {

  displayedColumnsConfiguration: string[] = ['0', '1', '2', '3', '4', '5', '6'];
  dataSourceConfiguration: IConfigurationModel[] = [];

  displayedColumnsMaintenanceElement: string[] = ['1', '2', '3', '4'];
  dataSourceMaintenanceElement: IMaintenanceElementModel[] = [];

  displayedColumnsVehicleType: string[] = ['1', '2', '3', '4'];
  dataSourceVehicleType: IVehicleTypeModel[] = [];

  constructor(private vehicleService: VehicleService,
              private materialService: MaterialService,
              private dialog: MatDialog) {
    this.loadAllVehicleType();
    this.loadAllMaintenanceElement();
    this.loadAllConfiguration();
  }
              
  loadAllVehicleType() {
    this.vehicleService.getAllVehicleType().then(x => this.dataSourceVehicleType = x);              
  }

  loadAllMaintenanceElement() {
    this.vehicleService.getAllMaintenanceElmenet().then(x => this.dataSourceMaintenanceElement = x);
  }

  loadAllConfiguration() {
    this.vehicleService.getAllConfiguration().then(x => this.dataSourceConfiguration = x);
  }

  openDialog(index: number = -1) {
    let dialogRef = this.dialog.open(DialogConfigurationAddComponent, {
      data: (index > -1 ? this.dataSourceConfiguration[index] : null),
      height: '400px',
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.vehicleService.addConfiguration(result).then(result => {
          if(result) {
            this.materialService.openSnackBar('Configuration saved succesfully!!');
            this.loadAllConfiguration();
          }
        }).catch(err => {
          this.materialService.openSnackBar('Error on server side');
        });
      }
    });
  }
}
