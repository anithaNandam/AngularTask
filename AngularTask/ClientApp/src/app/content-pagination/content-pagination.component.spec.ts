import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentPaginationComponent } from './content-pagination.component';

describe('ContentPaginationComponent', () => {
  let component: ContentPaginationComponent;
  let fixture: ComponentFixture<ContentPaginationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContentPaginationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContentPaginationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
