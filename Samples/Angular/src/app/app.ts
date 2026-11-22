import { PivotViewModule, GroupingBarService, FieldListService } from '@syncfusion/ej2-angular-pivotview';
import { Component, OnInit } from '@angular/core';
import { IDataSet } from '@syncfusion/ej2-angular-pivotview';
import { DataSourceSettingsModel } from '@syncfusion/ej2-pivotview/src/model/datasourcesettings-model';

@Component({
  imports: [
    PivotViewModule
  ],
  providers: [FieldListService, GroupingBarService],
  standalone: true,
  selector: 'app-root',
  template: `<div style="height: 480px;"><ejs-pivotview #pivotview id='PivotView' height='350' [dataSourceSettings]=dataSourceSettings [width]=width showGroupingBar="true" showFieldList="true" allowCalculatedField="true"></ejs-pivotview></div>`
})

export class App implements OnInit {
  public dataSourceSettings?: DataSourceSettingsModel;
  public width?: string;
  ngOnInit(): void {
    this.dataSourceSettings = {
      url: 'http://localhost:7800/api/pivot/post',
      mode: 'Server',
      type: 'JSON',
      rows: [{ name: 'Sector' }],
      columns: [{ name: 'EnerType', caption: 'Energy Source' }],
      values: [
        { name: 'PowUnits', caption: 'Power Units' },
      ]
    };
    this.width = "100%";
  }
}