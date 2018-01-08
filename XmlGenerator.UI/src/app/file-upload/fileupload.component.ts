import { Component } from '@angular/core';
import { RequestOptions, Headers, Response, Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { environment } from '../../environments/environment';
import { ChildXmlField } from "../../models/childXmlField.model";
import { XmlField } from "../../models/xmlField.model";

@Component({
  selector: 'file-upload',
  templateUrl: './fileupload.component.html',
  styleUrls: ['./fileupload.component.css']
})
export class FileUploadComponent {
  private url: any = environment.apiUrl;
  private xmlKeyValues:XmlField;
  constructor(private http: HttpClient) {

  }
  private xmlText: any;
  private file: File;
  ReadFile($event: any): void {
    var inputValue = $event.target;
    this.file = inputValue.files[0];
  }

  UploadFile() {
    let formData: FormData = new FormData();
    formData.append('uploadFile', this.file, this.file.name);
    let headers = new HttpHeaders()
    headers.append('Content-Type', 'json');
    headers.append('Accept', 'application/json');
    let options = { headers: headers };
    let apiUrl = "file/upload";
    const response = this.http.post(this.url + apiUrl, formData, options).subscribe(
      (success) => {
        debugger;
        let response = <XmlField>success.valueOf();
        this.xmlKeyValues = response;
      },
      (err) => {

      });
  }

  GetDetails() {
    const response = this.http.get(this.url + "file", { observe: 'response' }).subscribe(
      (success) => {
        var val = success.body;
      },
      (err) => {
      }
    );
  }
}
