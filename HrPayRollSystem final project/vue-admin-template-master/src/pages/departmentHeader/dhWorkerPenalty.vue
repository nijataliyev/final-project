<template>
  <v-dialog max-width="600px">
    <button flat slot="activator">
      <i class="material-icons myIcon" data-toggle="tooltip" title="Edit">cancel</i>
    </button>
    <v-card>
      <v-card-title class="myModal">
        <div class="container">
          <div class="row">
            <div class="col-md-12">
              <div class="form-group">
                <input type="text" class="form-control" v-model="penaltyPrice" />
              </div>
              <button @click="addPenalty" class="btn btn-primary">Penalty Add</button>
            </div>
          </div>
        </div>
      </v-card-title>
    </v-card>
  </v-dialog>
</template>
<script>
import axios from "axios";
export default {
  props: ["workerId"],
  data() {
    return {
      worker: {
        picture: "",
        name: "",
        surname: "",
        fatherName: ""
      },
      penaltyPrice:""
    };
  },
  created() {
    axios
      .get(`https://localhost:44370/api/Worker/`+this.workerId)
      .then(response => {
        // JSON responses are automatically parsed.
        this.worker = response.data;
      })
  },
  methods: {
    addPenalty() {
      axios
        .post("https://localhost:44370/api/Worker/givePenalty", {
          id: this.workerId,
          PenaltyPrice: this.penaltyPrice
        })
        .then(response => {
          console.log(response);
          this.$parent.getWorkers();
          this.penaltyPrice = "";
          this.worker.PenaltyPrice = response.data;
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
</style>