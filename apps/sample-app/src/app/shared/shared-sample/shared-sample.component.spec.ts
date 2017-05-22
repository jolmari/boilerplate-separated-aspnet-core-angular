import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SharedSampleComponent } from './shared-sample.component';

describe('SharedSampleComponent', () => {
  let component: SharedSampleComponent;
  let fixture: ComponentFixture<SharedSampleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SharedSampleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SharedSampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
