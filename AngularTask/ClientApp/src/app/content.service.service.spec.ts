import { TestBed } from '@angular/core/testing';

import { Content.ServiceService } from './content.service.service';

describe('Content.ServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: Content.ServiceService = TestBed.get(Content.ServiceService);
    expect(service).toBeTruthy();
  });
});
