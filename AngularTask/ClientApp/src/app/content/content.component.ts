import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContentService } from '../content.service';
import { Content } from '../models/content.ts';

@Component({
  selector: "app-content",
  templateUrl: "./content.component.html",
  styleUrls: ["./content.component.css"],
})
export class ContentComponent implements OnInit {
  contents: Content[];

  constructor(
    private contentService: ContentService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getContents();
  }

  getContents(): void {
    this.contentService
      .getContents()
      .subscribe((contents) => (this.contents = contents));
  }
  goToContentDetails(id) {
     //this.router.navigate(["/contents", content.id]);
    this.router.navigate(["/contentdetails", id]);
  }
}
