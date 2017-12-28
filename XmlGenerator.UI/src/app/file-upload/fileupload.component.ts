import { Component } from '@angular/core';

@Component({
  selector: 'file-upload',
  templateUrl: './fileupload.component.html',
  styleUrls: ['./fileupload.component.css']
})
export class FileUploadComponent {
    private xmlText:any;
    ReadFile($event:any) : void {
        var inputValue = $event.target;
        var file:File = inputValue.files[0]; 
        var myReader:FileReader = new FileReader();
    
        myReader.onloadend = (e) => {
          this.xmlText= myReader.result;
        }
        this.xmlText
        myReader.readAsText(file);
      }
}
