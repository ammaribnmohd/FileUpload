import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FileAttachment } from '../models/file-attachment/file-attachment.model'; 
import { environment } from '../environment/environment';
@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
  private apiUrl = `${environment.apiUrl}/api/fileupload` 


  constructor(private http: HttpClient) {}

  uploadFiles(formData: FormData): Observable<FileAttachment[]> {  
    return this.http.post<FileAttachment[]>(`${this.apiUrl}/upload`, formData);  
  }
  

  getFiles(): Observable<FileAttachment[]> {
    return this.http.get<FileAttachment[]>(`${this.apiUrl}/files`);
  }
}

