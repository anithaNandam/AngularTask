import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ContentListComponent } from "../content-list/content-list.component";
import { ContentViewdetailsComponent } from "../content-viewdetails/content-viewdetails.component";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { ContentPaginationComponent } from "../content-pagination/content-pagination.component";

@NgModule({
  declarations: [
    ContentListComponent,
    ContentViewdetailsComponent,
    ContentPaginationComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
  ],
})
export class ContentModule {}
