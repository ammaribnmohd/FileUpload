import { Component } from '@angular/core';
import { FileUploadService } from '../../services/file-upload.service';
import { FileAttachment } from '../../models/file-attachment/file-attachment.model';
import { FileType } from '../../infrastructures/file-type';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent {
  selectedFiles: File[] = [];
  firstName: string = '';
  lastName: string = '';

  constructor(private fileUploadService: FileUploadService) {}

  onFilesSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files) {
      this.selectedFiles = Array.from(input.files);
    }
  }

  uploadFiles(): void {
    if (this.selectedFiles.length > 0 && this.firstName && this.lastName) {
      const formData = new FormData();
   
      this.selectedFiles.forEach(file => {
        
        const fileType = FileType.getValue(file.type);
        formData.append('files', file);  
        formData.append('fileType', fileType?.toString() || '0');
      });
  
      formData.append('firstName', this.firstName);
      formData.append('lastName', this.lastName);
  
      this.fileUploadService.uploadFiles(formData).subscribe(
        (response: FileAttachment[]) => {
          console.log('Files uploaded successfully:', response);
        },
        (error) => {
          console.error('Error uploading files:', error);
        }
      );
    } else {
      console.error('No files selected or first name and last name missing.');
    }
  }
}
