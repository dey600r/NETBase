import { Component } from '@angular/core';
import { IConfigurationModel, IVehicleTypeModel } from '@models/index';
import { VehicleService } from '@services/index';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrl: './vehicle.component.scss'
})
export class VehicleComponent {

  displayedColumnsConfiguration: string[] = ['0', '1', '2', '3', '4', '5', '6'];
  dataSourceConfiguration: IConfigurationModel[] = [];

  displayedColumnsVehicleType: string[] = ['1', '2', '3', '4'];
  dataSourceVehicleType: IVehicleTypeModel[] = [];

  constructor(private vehicleService: VehicleService) {
    this.vehicleService.getAllVehicleType().then(x => this.dataSourceVehicleType = x);
    this.vehicleService.getAllConfiguration().then(x => this.dataSourceConfiguration = x);
  }
}
