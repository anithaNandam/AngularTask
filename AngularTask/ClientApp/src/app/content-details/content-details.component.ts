import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Location } from "@angular/common";

import { ContentService } from "../content.service";
import { Content } from "../models/content.ts";

@Component({
  selector: "app-content-details",
  templateUrl: "./content-details.component.html",
  styleUrls: ["./content-details.component.css"],
})
export class ContentDetailsComponent implements OnInit {
  content: Content;

  constructor(
    private route: ActivatedRoute,
    private contentService: ContentService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getContent();
  }

  getContent(): void {
    const id = +this.route.snapshot.paramMap.get("id");
    this.contentService
      .getContent(id)
      .subscribe((content) => (this.content = content));
  }

  goBack(): void {
    this.location.back();
  }

  downloadA4Pdf() {
     const id = +this.route.snapshot.paramMap.get("id");
    this.contentService.downloadPdf(id, "a4").subscribe((data) => {
      const blob = new Blob([data], { type: "application/pdf" });
      const url = window.URL.createObjectURL(blob);
      window.open(url);
    });
  }

  downloadMobilePdf() {
     const id = +this.route.snapshot.paramMap.get("id");
    this.contentService.downloadPdf(id, "mobile").subscribe((data) => {
      const blob = new Blob([data], { type: "application/pdf" });
      const url = window.URL.createObjectURL(blob);
      window.open(url);
    });
  }

  downloadMobileImage() {
    //  const id = +this.route.snapshot.paramMap.get("id");
    // this.contentService.downloadImage(id).subscribe((data) => {
    //   const blob = new Blob([data], { type: "image/jpeg" });
    //   const url = window.URL.createObjectURL(blob);
    //   window.open(url);
    // });
  }
}
