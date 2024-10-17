export class FileUploadRequest {
  files: File[];
  firstName: string;
  lastName: string;
  
  constructor() {
    this.files = [];
    this.firstName = '';
    this.lastName = '';
  }
}
