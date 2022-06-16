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
  filelist: any[] = [];
  fileKeyValue: any;
  parsedExcel: TargetWarmBuyers[] = [];
  constructor(private http: HttpClient,@Inject('BASE_URL') private baseUrl: string) {
    
  }

  ngOnInit(): void {
  }
  onInputChange(event: any) {
    // console.log(event)
    // return
    this.parsedExcel = [];
    this.file = event.target.files[0];
    let fileReader = new FileReader();
    fileReader.readAsArrayBuffer(this.file);
    fileReader.onload = (e) => {
      this.arrayBuffer = fileReader.result;
      let data = new Uint8Array(<ArrayBuffer>this.arrayBuffer);
      let arr = new Array();
      for (let i = 0; i != data.length; ++i) arr[i] = String.fromCharCode(data[i]);
      let bstr = arr.join("");
      let workbook = XLSX.read(bstr, { type: "binary" });
      let first_sheet_name = workbook.SheetNames[0];
      let worksheet = workbook.Sheets[first_sheet_name];
      // console.log(XLSX.utils.sheet_to_json(worksheet, { raw: true }));
      let arraylist: any[] = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      // this.parsedExcel = arraylist;
      this.filelist = [];
      // this.filelist = arraylist;
      var temp: any[] = arraylist;
      this.fileKeyValue = Object.keys(temp[0]);

      arraylist.forEach((item: any,index) => {
        this.filelist.push(Object.values(item))
        this.parsedExcel.push(new TargetWarmBuyers());
        Object.keys(item).forEach((result: any) => {
          debugger
          let key = result.replace(/[^a-zA-Z]/g, "");
          this.parsedExcel[index][key] = arraylist[index][key];
          if (typeof (this.parsedExcel[index][key]) === 'number')
            this.parsedExcel[index][key] = this.parsedExcel[index][key].toString()
          
        })
      })
      this.saveParsedExcel()
    }
  }
  saveParsedExcel() {
    console.log(this.parsedExcel)
    this.http.post<any>(this.baseUrl + 'weatherforecast/SaveParsedExcel', this.parsedExcel).subscribe(result => {
    }, error => console.error(error));
  }

}
export class TargetWarmBuyers {
  private received_at_date: string | undefined;
  private received_at_time: string | undefined;
  private LeadSource: string | undefined;
  private LeadName: string | undefined;
  private Firstname: string | undefined;
  private Lastname: string | undefined;
  private PhoneNumber: string | undefined;
  private Email: string | undefined;
  private Location: string | undefined;
  private EquipmentofInterest: string | undefined;
  private SKU: string | undefined;
  private Price: string | undefined;
  private RepAssignedto_simplelendrep: string | undefined;
  private id: string | undefined;
  private status: string | undefined;
  private lastactivityat: string | undefined;
  private tags: string | undefined;
  private Howsoonareyoulookingtopurchase: string | undefined;
  private AreyoulookingtoFinanceorPayCash: string | undefined;
  private Whatisyourbudget: string | undefined;
  private Whereareyoulocated: string | undefined;
  private locationpurchaseavailability: string | undefined;
  private Message: string | undefined;
  private Howsoonareyoulookingtosell: string | undefined;
  private EquipmentLocated: string | undefined;
  private Make: string | undefined;
  private Model: string | undefined;
  private Year: string | undefined;
  private Anyaccidents: string | undefined;
  private lease: string | undefined;
  private bankruptcyoraconsumerproposalinthelast2years: string | undefined;
  private Anyactivelawsuits: string | undefined;
  private Howlonghaveyoubeeninbusiness: string | undefined;
  private Doyouownorrentwhereyoucurrentlylive: string | undefined;
  private Howmanymilesorhours: string | undefined;
  private RequiredService: string | undefined;

}
