import { Component, inject } from '@angular/core';

import { DialogConfigurationAddComponent } from './dialog-configuration-add/dialog-configuration-add.component';
import { VehicleModule } from './vehicle.module';

// MODELS
import { IConfigurationModel, IMaintenanceElementModel, IVehicleTypeModel } from '@models/index';

// HELPERS
import { MaterialService } from '@helpers/index';

// PORTS
import { IQueryVehicleUIPort, ICommandVehicleUIPort, QueryVehicleUIPort, CommandVehicleUIPort } from '@ports/index';

@Component({
  selector: 'app-vehicle',
  imports: [ VehicleModule ],
  standalone: true,
  templateUrl: './vehicle.component.html',
  styleUrl: './vehicle.component.scss'
})
export class VehicleComponent {

  // INJECTABLES
  private readonly _materialService: MaterialService = inject(MaterialService);
  private readonly _readVehiclePort: IQueryVehicleUIPort = inject(QueryVehicleUIPort);
  private readonly _writeVehiclePort: ICommandVehicleUIPort = inject(CommandVehicleUIPort);

  displayedColumnsConfiguration: string[] = ['0', '1', '2', '3', '4', '5', '6'];
  dataSourceConfiguration: IConfigurationModel[] = [];

  displayedColumnsMaintenanceElement: string[] = ['1', '2', '3', '4'];
  dataSourceMaintenanceElement: IMaintenanceElementModel[] = [];

  displayedColumnsVehicleType: string[] = ['1', '2', '3', '4'];
  dataSourceVehicleType: IVehicleTypeModel[] = [];

  constructor() {
    this.loadAllVehicleType();
    this.loadAllMaintenanceElement();
    this.loadAllConfiguration();
  }
              
  loadAllVehicleType() {
    this._readVehiclePort.getAllVehicleType().then(x => this.dataSourceVehicleType = x);              
  }

  loadAllMaintenanceElement() {
    this._readVehiclePort.getAllMaintenanceElmenet().then(x => this.dataSourceMaintenanceElement = x);
  }

  loadAllConfiguration() {
    this._readVehiclePort.getAllConfiguration().then(x => this.dataSourceConfiguration = x);
  }

  openDialog(index: number = -1) {
    let dialogRef = this._materialService.openDialog(DialogConfigurationAddComponent, {
      data: (index > -1 ? this.dataSourceConfiguration[index] : null),
      height: '400px',
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this._writeVehiclePort.addConfiguration(result).then(result => {
          if(result) {
            this._materialService.openSnackBar('Configuration saved succesfully!!');
            this.loadAllConfiguration();
          }
        }).catch(err => {
          this._materialService.openSnackBar('Error on server side');
        });
      }
    });
  }
}
