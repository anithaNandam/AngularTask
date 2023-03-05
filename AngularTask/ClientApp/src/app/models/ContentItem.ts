export interface ContentItem {
  id: number;
  title: string;
  description: string;
  imageUrl: string;
  thumbnailUrl: string;
  downloadCount: number;
  createdAt: Date;
  updatedAt: Date;
  totalsDownloadsA4: number;
  totalsDownloadsmobile: number;
  totalsDownloadsimage: number;
}
