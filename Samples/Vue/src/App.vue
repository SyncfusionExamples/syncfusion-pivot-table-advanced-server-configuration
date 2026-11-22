<template>
    <div id="app">
        <ejs-pivotview :dataSourceSettings="dataSourceSettings" :height="height" :showGroupingBar="showGroupingBar" :showFieldList="showFieldList"> </ejs-pivotview>
    </div>
</template>

<script>
import { PivotViewComponent, GroupingBar, FieldList } from "@syncfusion/ej2-vue-pivotview";

export default {
  components: {
    'ejs-pivotview': PivotViewComponent
  },
  data () {
    return {
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
      height: 350,
      showGroupingBar: true,
      showFieldList: true
    }
  },
  provide: {
    pivotview: [GroupingBar, FieldList]
  }
}
</script>
<style>
@import '../node_modules/@syncfusion/ej2-tailwind3-theme/styles/pivotview/index.css';
</style>