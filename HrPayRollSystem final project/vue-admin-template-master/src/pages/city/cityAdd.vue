<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <form action>
          <div>
            <label for="">Countries Name</label>
           <multiselect
            class="citySearch"
            v-model="value"
            :options="countries"
            :custom-label="nameWithLang"
            placeholder="Select one"
            label="name"
            track-by="name"
          ></multiselect>
          </div>
          <div class="form-group">
            <label for="">City Add</label>
            <input type="text" v-model="name" class="form-control">
          </div>
          <button class="btn btn-primary" @click="addCity">City Add</button>
        </form>
      </div>
    </div>
  </div>
</template>
<script>
import axios from "axios";
import Multiselect from "vue-multiselect";
export default {
  name: "CityAdd",
   components: {
    Multiselect
  },
  data() {
    return {
       value: { name: "Vue.js", id: 1 },
       countries: [],
       name:""
    };
  },
  created() {
     axios
      .get(`https://localhost:44370/api/Country`)
      .then(response => {
        console.log(response);
        // JSON responses are automatically parsed.
        this.countries = response.data;
        this.value = { name: response.data[0].name, id: response.data[0].id };
      })
      .catch(e => {
        this.errors.push(e);
      });
  },
  watch: {
    value() {
      console.log(this.value.id);
      this.getCitiesByIdCountry(this.value.id);
    }
  },
   methods: {
    nameWithLang({ name }) {
      return `${name}`;
    },
    addCity(){
      axios.post('https://localhost:44370/api/City', {countryId: this.value.id,name:this.name})
                .then(response => {
                  
                })
            .catch(e => {
                (e)
            })
    },
    getCitiesByIdCountry(countryId) {
      axios
        .get(`https://localhost:44370/api/city/getCitiesByIdCountry?id=`+countryId)
        .then(response => {
          this.cities=response.data;
          // JSON responses are automatically parsed.
        })
        .catch(e => {
          this.errors.push(e);
        });
    }
    }
};
</script>
<style scoped>
/* .citySearch{
  background-color: white;
  border: 1px solid #CED4DA;
  padding: 7px;
  cursor: pointer;
} */
</style>