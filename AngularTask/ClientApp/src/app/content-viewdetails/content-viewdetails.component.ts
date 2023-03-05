import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContentItem } from '../models/ContentItem';
import { ContentService } from '../services/ContentService';

@Component({
  selector: "app-content-viewdetails",
  templateUrl: "./content-viewdetails.component.html",
  styleUrls: ["./content-viewdetails.component.css"],
})
export class ContentViewdetailsComponent implements OnInit {
  contentItem: ContentItem | undefined;
  headerHtml: string = "";
  footerHtml: string = "";
  @ViewChild("content",null) content: ElementRef;
  scale: number = 1;
  constructor(
    private route: ActivatedRoute,
    private contentService: ContentService
  ) {}

  ngOnInit(): void {
    this.getContentItem();
  }

  getContentItem(): void {
    const id = Number(this.route.snapshot.paramMap.get("id"));
    this.contentService.getContentItem(id).subscribe((response) => {
      this.contentItem = response.data;
      this.headerHtml = response.headers.get("HeaderHtml");
      this.footerHtml = response.headers.get("footerHtml");
      // console.log(this.headers.get("content-type")); // print the Content-Type header
      //this.contentItem = data;
    });
  }

  goBack(): void {
    // this.location.back();
  }

  downloadAsPdf(): void {
     const content = this.content.nativeElement.innerHTML;
    const id = Number(this.route.snapshot.paramMap.get("id"));
    const data = { content, scale: this.scale };
    this.contentService
      .downloadContentAsPdf(id)
      .subscribe((blob) => this.saveAs(blob, "content.pdf"));
  }

  downloadAsMobilePdf(): void {
    const id = Number(this.route.snapshot.paramMap.get("id"));
    this.contentService
      .downloadContentAsMobilePdf(id)
      .subscribe((blob) => this.saveAs(blob, "content.pdf"));
  }

  downloadAsMobileImage(): void {
    const id = Number(this.route.snapshot.paramMap.get("id"));
    this.contentService
      .downloadContentAsMobileImage(id)
      .subscribe((blob) => this.saveAs(blob, "content.jpg"));
  }

  saveAs(blob: Blob, filename: string): void {
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement("a");
    link.href = url;
    link.download = filename;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    window.URL.revokeObjectURL(url);
  }

  zoomIn(): void {
    this.scale += 0.1;
  }

  zoomOut(): void {
    this.scale = Math.max(this.scale - 0.1, 0.1);
  }
}
