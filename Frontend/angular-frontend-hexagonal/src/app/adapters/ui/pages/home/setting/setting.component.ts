import { Component, inject } from '@angular/core';

import { SettingModule } from './setting.module';
import { DialogSettingAddComponent } from './dialog-setting-add/dialog-setting-add.component';

// MODELS
import { ISettingModel } from '@app/domain/models';

// HELPERS
import { MaterialService } from '@helpers/index';

// PORTS
import { IReadSettingUIPort, IWriteSettingUIPort, ReadSettingUIPort, WriteSettingUIPort } from '@ports/index';

@Component({
  selector: 'app-setting',
  imports: [ SettingModule ],
  standalone: true,
  templateUrl: './setting.component.html',
  styleUrl: './setting.component.scss'
})
export class SettingComponent {

  // INJECTABLES
  private readonly _materialService: MaterialService = inject(MaterialService);
  private readonly _readSettingPort: IReadSettingUIPort = inject(ReadSettingUIPort);
  private readonly _writeSettingPort: IWriteSettingUIPort = inject(WriteSettingUIPort);
  
  displayedColumns: string[] = ['0', '1', '2', '3', '4', '6'];
  dataSource: ISettingModel[] = [];

  constructor() {
    this.loadSettings();
  }

  loadSettings() {
    this._readSettingPort.getAllSettings().then(x => {
      if(x.ok) {
        this.dataSource = x.data;
      } else {
        this._materialService.openSnackBar('Error on server side');
      }
    });
  }

  openDialog(index: number = -1) {
    let dialogRef = this._materialService.openDialog(DialogSettingAddComponent, {
      data: (index > -1 ? this.dataSource[index] : null),
      height: '400px',
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this._writeSettingPort.addSetting(result).then(result => {
          if(result.ok) {
            this._materialService.openSnackBar('Setting saved succesfully!!');
            this.loadSettings();
          } else {
            this._materialService.openSnackBar('Error on server side');
          }
        })
      }
    });
  }
}
