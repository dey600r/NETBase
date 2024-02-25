import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { IConfigurationModel } from '@models/index';
import { MaterialModule } from '@modules/material.module';

@Component({
  selector: 'app-dialog-configuration-add',
  standalone: true,
  imports: [
    FormsModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  templateUrl: './dialog-configuration-add.component.html',
  styleUrl: './dialog-configuration-add.component.scss'
})
export class DialogConfigurationAddComponent {

  name: FormControl = new FormControl('', [Validators.required]);
  description: FormControl = new FormControl('', [Validators.required]);

  form: FormGroup = this.formBuilder.group({
    name: this.name,
    description: this.description,
  });
  
  constructor(private formBuilder: FormBuilder,
              private dialogRef: MatDialogRef<DialogConfigurationAddComponent>,
              @Inject(MAT_DIALOG_DATA) public data: IConfigurationModel
  ) {
    if(data) {
      this.name.setValue(data.name);
      this.description.setValue(data.description);
    }
  }
  
  save(event: Event): any {
    event.preventDefault();
    if (this.form.valid) {
      const result = this.form.value as IConfigurationModel;
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
