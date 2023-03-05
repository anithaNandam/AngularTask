import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { ContentItem } from "../models/ContentItem";
import { map } from "rxjs/operators";


@Injectable({
  providedIn: "root",
})
export class ContentService {
  private apiUrl = "https://localhost:44333/api/content";

  constructor(private http: HttpClient) {}

  getContent(pageNumber: number, pageSize: number): Observable<any> {
    const url = `${this.apiUrl}?pageNumber=${pageNumber}&pageSize=${pageSize}`;
    return this.http.get<any>(url);
  }

  getContentItem1(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<ContentItem>(url);
  }

  getContentItem(id: number): Observable<{ data: any; headers: HttpHeaders }> {
    const url = `${this.apiUrl}/${id}`;
    return this.http
      .get(url, { observe: "response" }).pipe(
      map((response: HttpResponse<any>) => {
        return { data: response.body, headers: response.headers };
      }));
  }

  addContent(contentItem: ContentItem): Observable<ContentItem> {
    const headers = new HttpHeaders({ "Content-Type": "application/json" });
    return this.http.post<ContentItem>(this.apiUrl, contentItem, { headers });
  }

  downloadContentAsPdf(id: number): Observable<Blob> {
    const url = `${this.apiUrl}/${id}/download/pdf-a4`;
    return this.http.get(url, { responseType: "blob" });
  }

  downloadContentAsMobilePdf(id: number): Observable<Blob> {
    const url = `${this.apiUrl}/${id}/download/pdf-mobile`;
    return this.http.get(url, { responseType: "blob" });
  }

  downloadContentAsMobileImage(id: number): Observable<Blob> {
    const url = `${this.apiUrl}/${id}/download/image-mobile`;
    return this.http.get(url, { responseType: "blob" });
  }
}
