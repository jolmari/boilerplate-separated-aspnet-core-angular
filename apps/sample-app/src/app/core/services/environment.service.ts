import { Injectable } from '@angular/core';

import { environment } from '../../../environments/environment';

@Injectable()
export class EnvironmentService {

  public isProduction(): boolean {
    return environment.production;
  }
}
