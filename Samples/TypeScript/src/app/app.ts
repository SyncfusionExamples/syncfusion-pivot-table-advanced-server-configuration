import { PivotView, FieldList, GroupingBar } from '@syncfusion/ej2-pivotview';
import { enableRipple } from '@syncfusion/ej2-base';
enableRipple(false);

/* tslint:disable */

/**  
 * PivotView Default Sample.
 */
PivotView.Inject(FieldList, GroupingBar);

let pivotObj: PivotView = new PivotView({
    dataSourceSettings: {
        url: 'http://localhost:7800/api/pivot/post',
        mode: 'Server',
        type: 'JSON',
        rows: [{ name: 'Sector' }],
        columns: [{ name: 'EnerType', caption: 'Energy Source' }],
        values: [
            { name: 'PowUnits', caption: 'Power Units' },
        ]
    },
    allowCalculatedField: true,
    showGroupingBar: true,
    showFieldList: true,
    height: 500,
    width: 1000
});
pivotObj.appendTo('#PivotGrid');