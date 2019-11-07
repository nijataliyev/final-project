<template>
  <v-dialog max-width="300px">
    <button flat slot="activator">
      <i class="material-icons myIcon" data-toggle="tooltip" title="Edit">&#xE254;</i>
    </button>
    <v-card>
      <v-card-title class="myModal">
        <div class="form-group">
          <div>
            <img :src="'data:image/gif;base64,'+ worker.picture" alt />
          </div>
        </div>
        <div class="form-group">
          <label for="">Ad</label>
          <p>{{worker.name}}</p>
          <hr>
          <label for="">Soyad</label>
          <p>{{worker.surname}}</p>
          <hr>
          <label for="">Maaş</label>
          <p>{{worker.salary}}</p>
        </div>
        <div class="form-group">
          <input type="text" class="form-control" v-model="salaryNew" />
        </div>
        <button class="btn btn-primary" @click="salaryAdd">Salary Add</button>
      </v-card-title>
    </v-card>
  </v-dialog>
</template>
<script>
import axios from "axios";
export default {
  props: ["pseditid"],
  data() {
    return {
      worker: {
        picture: "",
        name: "",
        surname: "",
        fatherName: "",
        company: "",
        department: "",
        profession: "",
        salary: ""
      },
      salaryNew: 0
    };
  },
  created() {
    axios
      .get(`https://localhost:44370/api/Worker/` + this.pseditid)
      .then(response => {
        // JSON responses are automatically parsed.
        this.worker = response.data;
      });
  },
  methods: {
    salaryAdd() {
      console.log(this.pseditid);
      console.log(this.salaryNew);
      axios
        .post("https://localhost:44370/api/Worker/addSalary", {
          id: this.pseditid,
          salary: this.salaryNew
        })
        .then(response => {
          console.log(response);
          this.$parent.getWorkers();
          this.salaryNew = "";
          this.worker.salary = response.data;
        })
        .catch(e => {
          e;
        });
    }
  }
};
</script>
<style scoped>
.myIcon {
  color: orange;
}
div img {
  width: 170px;
  height: 170px;
}
img{
  margin-right: 15px;
}
label{
  color: green;
}
p{
  margin-bottom: 0px;
}
hr{
  margin: 0px;
}
</style>