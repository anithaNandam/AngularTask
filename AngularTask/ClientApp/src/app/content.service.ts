import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Content } from "./models/content.ts";


@Injectable({
  providedIn: "root",
})
export class ContentService {
  private apiUrl = "https://localhost:44333/api/contents";

  constructor(private http: HttpClient) {}

  getContents(): Observable<Content[]> {
    return this.http.get<Content[]>(this.apiUrl);
  }

  getContent(id: number): Observable<Content> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Content>(url);
  }

  addContent(content: Content): Observable<Content> {
    return this.http.post<Content>(this.apiUrl, content);
  }

  downloadPdf(id: number, format: string): Observable<any> {
    const url = `${this.apiUrl}/${id}/download/${format}`;
    return this.http.get(url, { responseType: "arraybuffer" });
  }
}
