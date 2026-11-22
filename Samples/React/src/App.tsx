import { type IDataSet, PivotViewComponent, Inject, GroupingBar, FieldList} from '@syncfusion/ej2-react-pivotview';
import type { DataSourceSettingsModel } from '@syncfusion/ej2-pivotview/src/model/datasourcesettings-model';

function App() {
  const dataSourceSettings: DataSourceSettingsModel = {
      url: 'http://localhost:7800/api/pivot/post',
      mode: 'Server',
      type: 'JSON',
      rows: [{ name: 'Sector' }],
      columns: [{ name: 'EnerType', caption: 'Energy Source' }],
      values: [
        { name: 'PowUnits', caption: 'Power Units' },
      ]
  };
  return (
    <PivotViewComponent id='PivotView' height={350} dataSourceSettings={dataSourceSettings} showFieldList={true} showGroupingBar={true}><Inject services={[FieldList, GroupingBar]}/></PivotViewComponent>
  );
};

export default App;