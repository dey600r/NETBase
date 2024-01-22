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
  
  displayedColumns: string[] = ['1', '2', '3', '4'];
  dataSource: ISettingModel[] = [];

  constructor(private settingService: SettingService,
    private materialService: MaterialService,
    public dialog: MatDialog) {
    this.settingService.getAllSettings().then(x => {
      if(x.ok) {
        this.dataSource = x.data;
      } else {
        this.materialService.openSnackBar('Error on server side');
      }
    });
  }

  openDialog() {
    let dialogRef = this.dialog.open(DialogSettingAddComponent, {
      height: '400px',
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed', result);
    });
  }
}
