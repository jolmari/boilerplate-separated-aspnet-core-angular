import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedSampleComponent } from './shared-sample/shared-sample.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    SharedSampleComponent
  ],
  exports: [
    SharedSampleComponent,
    CommonModule
  ]
})

// The SharedModule is used to store components, pipes, and directives that are used
// multiple times within the application scope. Do not share services here, introduce
// them in CoreModule.
export class SharedModule { }
