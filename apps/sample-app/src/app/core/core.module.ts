import { NgModule, ModuleWithProviders, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EnvironmentService } from './services/environment.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: []
})

// The Core Module is used to collect: 
// 1. Single-use singleton classes such as application wide services (spinners, configuration). 
// 2. Single-use components that are used only by the app-module itself.
// --------------------------------------------------------------------------------------------
// Common services should not be re-introduced in feature modules as they are application wide 
// and will result in multiple instances of the same service. 
export class CoreModule {
  
  // Configure module services and return module bundled with configured services.
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: CoreModule,
      providers: [
        EnvironmentService
      ]
    };
  }

  // Core Module should be loaded only once for the application, see:
  // https://angular.io/docs/ts/latest/cookbook/ngmodule-faq.html#!#q-why-it-is-bad
  constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error(
        'CoreModule is already loaded. Import it in the AppModule only');
    }
  }
}

