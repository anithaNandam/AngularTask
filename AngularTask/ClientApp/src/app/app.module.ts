import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ContentModule } from './content/content.module';
import { ContentListComponent } from './content-list/content-list.component';
import { ContentViewdetailsComponent } from './content-viewdetails/content-viewdetails.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ContentModule,
    RouterModule.forRoot([
      { path: "", redirectTo: "/contentlist", pathMatch: "full" },
      { path: "contentlist", component: ContentListComponent },      {
        path: "contentviewdetails/:id",
        component: ContentViewdetailsComponent,
      },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
