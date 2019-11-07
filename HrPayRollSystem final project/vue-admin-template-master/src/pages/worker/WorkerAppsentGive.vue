<template>
  <v-dialog max-width="300px">
    <button flat slot="activator">
      <i class="material-icons myIcon" data-toggle="tooltip" title="Edit">&#xE254;</i>
    </button>
    <v-card>
      <v-card-title class="myModal">
        <div class="form-group myGroup">
          <label for>Tarixi seç</label>
          <v-menu :close-on-content-click="false">
            <v-text-field
              :value="format_Date"
              slot="activator"
              label="Tarixi seç"
              prepend-icon="date_range"
            ></v-text-field>
            <v-date-picker v-model="appsentModel.appsentDate"></v-date-picker>
          </v-menu>
        </div>
        <div class="form-group myGroup">
          <label for>Növ</label>
          <div class="form-check form-check-inline">
            <input class="form-check-input" type="radio" v-model="appsentModel.appsentType" value="1" />
            <span class="form-check-label">Üzürlü</span>
          </div>
          <div class="form-check form-check-inline">
            <input class="form-check-input" type="radio" v-model="appsentModel.appsentType" value="2" />
            <span class="form-check-label">Üzürsüz</span>
          </div>
        </div>
        <div class="form-group myGroup">
            <label for="">Səbəb</label>
            <input type="text" class="form-control" v-model="appsentModel.text">
        </div>
        <div>

        </div>
        <button @click="giveAppsent" class="btn btn-primary">Yadda Saxla</button>
      </v-card-title>
    </v-card>
  </v-dialog>
</template>

<script>
import axios from 'axios';
import moment from "moment";
export default {
  props: ["workerId"],
  data() {
    return {
      appsentModel:{
        appsentDate:"",
        appsentType:0,
        text:"",
        appsentReasonId:""
      }
    };
  },
  computed: {
    format_Date() {
      return this.appsentModel.appsentDate
        ? moment(String(this.appsentModel.appsentDate)).format("DD-MM-YYYY")
        : "";
    }
  },
  methods: {
    giveAppsent(){
      const info = new FormData();
      info.append("WorkerId",this.workerId)
      info.append("WorkerIsAppsentDay",this.appsentModel.appsentDate);
      info.append("AppsentReasonType",this.appsentModel.appsentType);
      info.append("Text",this.appsentModel.text);
      axios.post('https://localhost:44370/api/Worker/giveAppsent',info)
      .then(response =>{

      })
    }
  }
};
</script>
<style scoped>
label {
  display: block;
}
.myGroup{
    margin-right: 15px;
}
.myModal button{
    display: block;
}
</style>