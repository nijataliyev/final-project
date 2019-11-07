<template>
  <v-dialog max-width="600px">
    <button flat slot="activator">
      <i class="material-icons myIcon" data-toggle="tooltip" title="Edit">add</i>
    </button>
    <v-card>
      <v-card-title class="myModal">
        <div class="container">
          <div class="row">
            <div class="col-md-12">
              <div class="form-group">
                <input type="text" class="form-control" v-model="BonusPrice" />
              </div>
              <button @click="addBonus" class="btn btn-primary">Bonus Add</button>
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
        fatherName: "",
        bonusPrice:""
      },
      BonusPrice: 0
    };
  },
  methods: {
    addBonus() {
        console.log(this.workerId)
        console.log(this.BonusPrice)
        axios.post('https://localhost:44370/api/Worker/addBonusPrice',{
          id: this.workerId,
          BonusPrice: this.BonusPrice
        })
        .then(response => {
          console.log(response);
          this.$parent.getWorkers();
          this.BonusPrice = "";
          this.worker.bonus = response.data;
        })
        .catch(e => {
          e;
        });
    }
  }
  //   created() {
  //     axios
  //       .get(`https://localhost:44370/api/Worker/`+this.workerId)
  //       .then(response => {
  //         // JSON responses are automatically parsed.
  //         this.worker = response.data;
  //       })
  //   }
};
</script>
<style scoped>
.myIcon {
  color: orange;
}
</style>