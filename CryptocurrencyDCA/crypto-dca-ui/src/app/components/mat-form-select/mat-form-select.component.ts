import {Component, Input} from '@angular/core';
import {FormGroup} from "@angular/forms";

@Component({
  selector: 'app-mat-form-select',
  templateUrl: './mat-form-select.component.html',
  styleUrls: []
})
export class MatFormSelectComponent {
  @Input('form') form: FormGroup = new FormGroup({});
  @Input('display') display: boolean = true;
  @Input('propertyFormName') propertyFormName: string = '';
  @Input('labelName') labelName: string = '';
}
