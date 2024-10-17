import { FileType } from "../../infrastructures/file-type";

export class FileAttachment {
  id: number | null;
  fileName: string;
  fileType: number;
  fileData: string;
  firstName: string; 
  lastName: string;  

  constructor() {
    this.id = null;
    this.fileName = '';
    this.fileType = 0;
    this.fileData = '';
    this.firstName = ''; 
    this.lastName = '';  
  }
}