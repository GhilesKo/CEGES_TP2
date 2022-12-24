import { NgModule } from '@angular/core';


import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatTabsModule} from '@angular/material/tabs';
import {MatIconModule} from '@angular/material/icon';
import {MatDialogModule} from '@angular/material/dialog';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';

import {MatDividerModule} from '@angular/material/divider';
const modules = [
  MatCardModule,
  MatInputModule,
  MatButtonModule,
  MatFormFieldModule,
  MatTabsModule,
  MatIconModule,
  MatDialogModule,
  MatProgressSpinnerModule,
  MatSlideToggleModule,
  MatDividerModule
];

@NgModule({
  imports: modules,
  exports: modules,
})
export class MaterialModule {}
