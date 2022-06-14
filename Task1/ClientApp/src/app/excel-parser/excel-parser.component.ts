import { Component, Inject, OnInit } from '@angular/core';
import * as XLSX from 'xlsx';
import * as FileSaver from 'file-saver';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-excel-parser',
  templateUrl: './excel-parser.component.html',
  styleUrls: ['./excel-parser.component.css']
})
export class ExcelParserComponent implements OnInit {
  file: any;
  arrayBuffer: string | ArrayBuffer | null | undefined;
  filelist: any[]=[];
  fileKeyValue: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    // http.get<WeatherForecast[]>(baseUrl + 'ExcelParser').subscribe(result => {
    //   // this.forecasts = result;
    // }, error => console.error(error));
  }

  ngOnInit(): void {
  }
  onInputChange(event: any) {
    console.log(event)
    // return

    this.file = event.target.files[0];
    let fileReader = new FileReader();
    fileReader.readAsArrayBuffer(this.file);
    fileReader.onload = (e) => {
      this.arrayBuffer = fileReader.result;
      var data = new Uint8Array(<ArrayBuffer>this.arrayBuffer);
      var arr = new Array();
      for (var i = 0; i != data.length; ++i) arr[i] = String.fromCharCode(data[i]);
      var bstr = arr.join("");
      var workbook = XLSX.read(bstr, { type: "binary" });
      var first_sheet_name = workbook.SheetNames[0];
      var worksheet = workbook.Sheets[first_sheet_name];
      console.log(XLSX.utils.sheet_to_json(worksheet, { raw: true }));
      var arraylist = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      this.filelist = [];
      // this.filelist = arraylist;
      var temp: any[] = arraylist;
      this.fileKeyValue = Object.keys(temp[0]);

      arraylist.forEach((item:any) => {
        this.filelist.push(Object.values(item))
      })
    }
  }

}
