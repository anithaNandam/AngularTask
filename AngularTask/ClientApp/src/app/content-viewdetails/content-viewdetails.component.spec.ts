import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentViewdetailsComponent } from './content-viewdetails.component';

describe('ContentViewdetailsComponent', () => {
  let component: ContentViewdetailsComponent;
  let fixture: ComponentFixture<ContentViewdetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContentViewdetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContentViewdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
