import { inject, Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {

  private readonly _snackBar: MatSnackBar = inject(MatSnackBar);

  openSnackBar(message: string) {
    this._snackBar.open(message, 'ok', { duration: 3000 });
  }
}
