import { Component, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MaterialModule } from '@app/shared/modules/material.module';

export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'app-dialog-setting-add',
  standalone: true,
  imports: [
    FormsModule,
    MaterialModule
  ],
  templateUrl: './dialog-setting-add.component.html',
  styleUrl: './dialog-setting-add.component.scss'
})
export class DialogSettingAddComponent {
  constructor(public dialogRef: MatDialogRef<DialogSettingAddComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}
  onNoClick(): void {
    this.dialogRef.close();
  }
}
