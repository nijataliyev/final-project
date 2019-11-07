<template>
  <v-dialog max-width="600px">
    <button flat slot="activator">
      <i class="material-icons myIcon" data-toggle="tooltip" title="Edit">&#xE254;</i>
    </button>
    <v-card>
      <v-card-title class="myModal">
        <div class="form-group">
          <img :src="'data:image/gif;base64,'+ worker.picture" alt />
        </div>
        <div class="form-group">
          <label for>Ad</label>
          <input type="text" v-model="worker.name" class="form-control">
          <label for="">Soyad</label>
          <input type="text" v-model="worker.surname" class="form-control">
          <label for="">Ata adı</label>
          <input type="text" v-model="worker.fathername" class="form-control">
          <label for="">Doğum Tarixi</label>
          <v-menu :close-on-content-click="false">
            <v-text-field
              :value="format_birthDate"
              slot="activator"
              label="Tarixi seç"
              prepend-icon="date_range"
            ></v-text-field>
            <v-date-picker v-model="worker.birthdate"></v-date-picker>
          </v-menu>
        </div>
        <button @click="editWorker" class="btn btn-primary">Yadda Saxla</button>
      </v-card-title>
    </v-card>
  </v-dialog>
</template>
<script>
import axios from "axios";
import moment from "moment";
export default {
  props: ["workerId"],
  data() {
    return {
      worker: {
        id:"",
        picture: "",
        name: "",
        surname: "",
        fathername: "",
        birthdate:""
      },
      editName:"",
      editSurname:"",
      editFahername:""
    };
  },
  created() {
    axios
      .get(`https://localhost:44370/api/Worker/` + this.workerId)
      .then(response => {
        // JSON responses are automatically parsed.
        this.worker.id = response.data.id;
        this.worker.picture = response.data.picture;
      });
  },
  computed:{
      format_birthDate() {
      return this.worker.birthdate
        ? moment(String(this.worker.birthdate)).format("DD-MM-YYYY")
        : "";
    }
  },
  methods:{
    editWorker(){
      console.log(this.worker.name)
      axios.put(`https://localhost:44370/api/Worker/editWorker?id=`+this.workerId,this.worker)
      .then(response =>{
          this.$parent.getWorkers();
      })
    }
  }
};
</script>
<style scoped>
.myIcon {
  color: orange;
}
div img {
  width: 190px;
  height: 240px;
  padding-right: 10px;
}
</style>