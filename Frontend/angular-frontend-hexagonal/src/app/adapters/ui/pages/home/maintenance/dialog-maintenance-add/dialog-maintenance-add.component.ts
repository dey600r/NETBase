import { Component, inject, Inject, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { IMaintenanceElementModel } from '@models/index';
import { MaterialModule } from '@modules/material.module';

@Component({
  selector: 'app-dialog-maintenance-add',
  standalone: true,
  imports: [
    FormsModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  templateUrl: './dialog-maintenance-add.component.html',
  styleUrl: './dialog-maintenance-add.component.scss',
  encapsulation: ViewEncapsulation.Emulated
})
export class DialogMaintenanceAddComponent {
  name: FormControl = new FormControl('', [Validators.required]);
  description: FormControl = new FormControl('', [Validators.required]);

  form: FormGroup = inject(FormBuilder).group({
    name: this.name,
    description: this.description,
  });
  
  constructor(private dialogRef: MatDialogRef<DialogMaintenanceAddComponent>,
              @Inject(MAT_DIALOG_DATA) public data: IMaintenanceElementModel
  ) {
    if(data) {
      this.name.setValue(data.name);
      this.description.setValue(data.description);
    }
  }
  
  save(event: Event): any {
    event.preventDefault();
    if (this.form.valid) {
      const result = this.form.value as IMaintenanceElementModel;
      this.close(result);
    }
  }

  cancel(): void {
    this.close(null);
  }

  close(result: any): void {
    this.dialogRef.close(result);
  }
}
