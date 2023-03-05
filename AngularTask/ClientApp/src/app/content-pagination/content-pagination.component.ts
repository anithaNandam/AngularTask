import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: "app-content-pagination",
  templateUrl: "./content-pagination.component.html",
  styleUrls: ["./content-pagination.component.css"],
})
export class ContentPaginationComponent implements OnInit {
  @Input() totalPages: number = 10;
  @Input() currentPage: number = 1;
  @Output() pageChanged = new EventEmitter<number>();
  constructor() {}

  ngOnInit() {}

  paginate(pageNumber: number): void {
    if (pageNumber !== this.currentPage) {
      this.pageChanged.emit(pageNumber);
    }
  }

  getPages(): number[] {
    const pageRange = 2;
    const startPage = Math.max(1, this.currentPage - pageRange);
    const endPage = Math.min(this.totalPages, this.currentPage + pageRange);
    const pages = [];
    for (let i = startPage; i <= endPage; i++) {
      pages.push(i);
    }
    return pages;
  }
}
