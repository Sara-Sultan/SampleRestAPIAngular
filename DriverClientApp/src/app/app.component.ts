import { Component, OnInit, ViewChild } from '@angular/core';

import { GridComponent, SelectionSettingsModel, PageSettingsModel, Edit, Column, IEditCell } from '@syncfusion/ej2-angular-grids';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs';
import { DriverService } from './driver.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'DriverClientApp';

  public data: any[] = [];

  //#region Probability
  public probData: any;
  public success: boolean = true;

  @ViewChild('grid', { static: true })
  public grid!: GridComponent;

  public selectionOptions: SelectionSettingsModel;

  public pageSettings: PageSettingsModel;

  public filterSettings: Object;

  //#region Tool bar Add , delete , update ,search
  public toolbar: string[];

  public editSettings: Object;

  //Fields validation
  public nameRules: Object;
  public emailRules: Object;
  public phoneRules: Object;


  //#endregion

  msg_error: string="";

  dpParams: any;


  constructor(private DriverService: DriverService,
    private spinner: NgxSpinnerService) {


    this.nameRules = { required: true, minLength: [this.customStringFn, 'Need atleast 5 letters'] };

    this.emailRules = { required: true };

    this.phoneRules = { required: true };
    this.pageSettings = { pageSize: 6 };
    this.selectionOptions = { type: 'Multiple', mode: 'Row' };
    this.filterSettings = { type: 'CheckBox' };


    //#region Tool bar
    //this.toolbar = ['Search'];
    this.editSettings = {
      allowEditing: true, allowAdding: true,
      allowDeleting: true, newRowPosition: 'Top'//, mode: 'Dialog'//, mode: 'Batch'
    };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel', 'Search'];

    //Fields validation
    //#endregion
  }



  ngOnInit() {
    this.spinner.show();



    //#region Get New Requests 
    this.DriverService.getAllDrivers()
      .pipe(finalize(() => {
        //this.spinner.hide();
        // this.busy = false;
      }))
      .subscribe(result => {
        this.data = result as any[];
        this.success = true;
        // this.data.forEach(e => e['imageUrl'] = this.Apiurl + e['imageUrl']);
      },
        (e) => {
          this.msg_error = e;
          console.log('error');

        }
      );
    //#endregion

  }

  customStringFn: (args: { [key: string]: string }) => boolean = (args: { [key: string]: string }) => {
    return args['value'].length >= 5;
  };


  //This function to handle every event like when Add ,Edit ,Delete
  customActionbegin(e: any) {

    //#region Add
    if (e.requestType == "save" && e.action == "add") {
      //action: "add"
      //cancel: false
      //data: { id: undefined, headline: "sw", headlineAr: "ww", body: "ww", bodyAr: "ww", … }
      //foreignKeyData: { }
      //form: form#grid_711702987_0EditForm.e - gridform.e - lib.e - formvalidator
      //index: 0
      //name: "actionBegin"
      //previousData: { id: undefined, bodyAr: undefined, … }
      //requestType: "save"
      //row: tr.e - row.e - addedrow
      //rowData: { id: undefined, bodyAr: undefined, … }
      //selectedRow: 0
      //target: undefined
      //type: "actionBegin"
      //__proto__: Object
      e.data['isVisible'] = true;
      this.DriverService.addDriver(e.data)
        .pipe(finalize(() => {
          this.spinner.hide();
          // this.busy = false;
        }))
        .subscribe(() => {
          window.location.reload();
           this.success = true;
        },
          (e) => {
            this.msg_error = e;
            console.log('error');

          }
        );
    }


    //#endregion


    //#region Edit
    else if (e.requestType == "save" && e.action == "edit") {


      this.DriverService.editDriver(e.data)
        .pipe(finalize(() => {
          this.spinner.hide();
          // this.busy = false;
        }))
        .subscribe(result => {
          // this.success = true;
          window.location.reload();
        },
          (e) => {
            this.msg_error = e;
            console.log('error');

          }
        );
    }

    //#endregion


    //#region Delete
    else if (e.requestType == "delete") {
      //cancel: false
      //data: [{ … }]
      //foreignKeyData: { }
      //name: "actionBegin"
      //requestType: "delete"
      //tr: [tr.e - row]
      //type: "actionBegin"
      //__proto__: Object

      this.DriverService.deleteDriver(e.data[0]["id"])
        .pipe(finalize(() => {
          this.spinner.hide();
          // this.busy = false;
        }))
        .subscribe(result => {
          window.location.reload();
          // this.success = true;
        },
          (e) => {
            this.msg_error = e;
            console.log('error');

          }
        );
    }
    //#endregion

    else if (e.requestType == "beginEdit") {

    }
  }
}
