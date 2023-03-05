import { Component, OnInit } from '@angular/core';
import { ContentItem } from '../models/ContentItem';

import { ContentService } from '../services/ContentService';

@Component({
  selector: "app-content-list",
  templateUrl: "./content-list.component.html",
  styleUrls: ["./content-list.component.css"],
})
export class ContentListComponent implements OnInit {
  contentItems: ContentItem[] = [];
  pageNumber = 1;
  pageSize = 10;

  // pageSize = 6;
  currentPage = 1;
  totalPages = 1;

  constructor(private contentService: ContentService) {}

  ngOnInit(): void {
    this.getContent();
  }

  getContent(): void {
    this.contentService
      .getContent(this.pageNumber, this.pageSize)
      .subscribe((contentItems) => {
        this.contentItems = contentItems.items;
        this.totalPages = contentItems.totalCount;
           this.currentPage = this.pageNumber;
      });
  }

  nextPage(): void {
    this.pageNumber++;
    this.getContent();
  }

  previousPage(): void {
    this.pageNumber--;
    this.getContent();
  }

  paginate(pageNumber: number): void {
    if (pageNumber >= 1 && pageNumber <= this.totalPages) {
      this.getContent();
    }
  }
}
