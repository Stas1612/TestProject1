import { Component, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public dataSets: UserDataSet[] = [];
  public fileToUpload: File;
  public httpClient: HttpClient;
  public progress: number;
  public message: string;
  public fileName: string;
  public pipe: DatePipe;

  @Output() public onUploadFinished = new EventEmitter();

  constructor(http: HttpClient) {
    this.httpClient = http;
    this.pipe = new DatePipe('ru-RU');
  }

  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
    this.fileName = this.fileToUpload.name;
  }

  uploadFileToActivity() {
    if (this.fileToUpload == null || this.fileToUpload.name.trim() == "") {
      alert("Файл не выбран!")
      return;
    }

    const formData = new FormData();
    formData.append('file', this.fileToUpload, this.fileToUpload.name);
    let url = 'http://localhost:61321' + '/UserDataSet';
    
    this.httpClient.post(url, formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
          this.addItemInDataSets();
        }
      });
  }

  addItemInDataSets() {
    let now = new Date().toISOString();
    this.dataSets.push({ date: now, name: this.fileName });
  }
}

class UserDataSet {
  public name: string
  public date: string;
}
