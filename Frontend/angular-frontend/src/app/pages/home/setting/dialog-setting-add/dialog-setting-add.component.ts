import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ISettingModel } from '@models/index';
import { MaterialModule } from '@modules/material.module';

@Component({
  selector: 'app-dialog-setting-add',
  standalone: true,
  imports: [
    MaterialModule,
    ReactiveFormsModule
  ],
  templateUrl: './dialog-setting-add.component.html',
  styleUrl: './dialog-setting-add.component.scss'
})
export class DialogSettingAddComponent {
  
  key: FormControl = new FormControl('', [Validators.required]);
  value: FormControl = new FormControl('', [Validators.required]);

  form: FormGroup = this.formBuilder.group({ 
    key: this.key, 
    value: this.value 
  });
  
  constructor(private formBuilder: FormBuilder,
              private dialogRef: MatDialogRef<DialogSettingAddComponent>,
              @Inject(MAT_DIALOG_DATA) public data: ISettingModel
  ) {
    if(data) {
      this.key.setValue(data.key);
      this.value.setValue(data.value);
    }
  }
  
  save(event: Event): any {
    event.preventDefault();
    if (this.form.valid) {
      const result = this.form.value as ISettingModel;
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
