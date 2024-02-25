import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ISettingModel } from '@app/core/models';
import { MaterialService, SettingService } from '@services/index';
import { DialogSettingAddComponent } from './dialog-setting-add/dialog-setting-add.component';


@Component({
  selector: 'app-setting',
  templateUrl: './setting.component.html',
  styleUrl: './setting.component.scss'
})
export class SettingComponent {
  
  displayedColumns: string[] = ['0', '1', '2', '3', '4', '6'];
  dataSource: ISettingModel[] = [];

  constructor(private settingService: SettingService,
              private materialService: MaterialService,
              public dialog: MatDialog) {
    this.loadSettings();
  }

  loadSettings() {
    this.settingService.getAllSettings().then(x => {
      if(x.ok) {
        this.dataSource = x.data;
      } else {
        this.materialService.openSnackBar('Error on server side');
      }
    });
  }

  openDialog(index: number = -1) {
    let dialogRef = this.dialog.open(DialogSettingAddComponent, {
      data: (index > -1 ? this.dataSource[index] : null),
      height: '400px',
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        this.settingService.addSetting(result).then(result => {
          if(result.ok) {
            this.materialService.openSnackBar('Setting saved succesfully!!');
            this.loadSettings();
          } else {
            this.materialService.openSnackBar('Error on server side');
          }
        })
      }
    });
  }
}
