import { Component, ElementRef } from '@angular/core';

@Component({
  selector: 'app-password-field',
  templateUrl: './password-field.component.html',
  styleUrls: ['./password-field.component.css']
})
export class PasswordFieldComponent {
  
  passwordVisible = false;

  constructor(private el: ElementRef) { }

  togglePasswordVisibility() {
    this.passwordVisible = !this.passwordVisible;
    const passwordField = this.el.nativeElement.querySelector('#password-field');
    passwordField.classList.toggle('hide-password');
  }

}
