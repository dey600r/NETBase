import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-error-page',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div style="text-align: center; margin-top: 50px;">
      <h1>Page unavailable</h1>
      <p>Please contact with the app administrator</p>
    </div>
  `,
})
export class ErrorPageComponent { }