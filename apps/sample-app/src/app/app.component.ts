import { environment } from '../environments/environment';
import { Component, OnInit } from '@angular/core';

import { EnvironmentService } from './core/services/environment.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  title = '';

  constructor(private environmentService: EnvironmentService) { }

  public ngOnInit() {
    this.title = this.environmentService.isProduction() ? 'App works in Production mode' : 'App works in Development mode';
  }

}
