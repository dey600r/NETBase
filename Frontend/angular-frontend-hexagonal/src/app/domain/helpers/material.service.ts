import { inject, Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {

  private readonly _snackBar = inject(MatSnackBar);
  private readonly _dialog: MatDialog = inject(MatDialog);

  constructor() { }

  openSnackBar(message: string): void {
    this._snackBar.open(message, '', {
      duration: 2000
    });
  }

  openDialog(component: any, setting: { data: any, height: string, width: string}): MatDialogRef<any> {
    return this._dialog.open(component, setting);
  }
}
