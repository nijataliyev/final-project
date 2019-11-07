<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <form action>
          <div class="form-group">
          <label for>Departments Name</label>
          <multiselect
            class="shopSearch"
            v-model="value"
            :options="departments"
            :custom-label="nameWithLang"
            placeholder="Select one"
            label="name"
            track-by="name"
          ></multiselect>
        </div>
          <div class="form-group">
            <input type="text" class="form-control" v-model="name" />
          </div>
          <button @click="shopAdd" class="btn btn-primary">Shop Add</button>
        </form>
      </div>
    </div>
  </div>
</template>
<script>
import axios from "axios";
import Multiselect from "vue-multiselect";
export default {
  name: "ShopAdd",
  components:{
      Multiselect
  },
  data() {
    return {
      name: "",
      value: { name: "Vue.js", id: 1 },
      departments:[]
    };
  },
  created() {
     axios
      .get(`https://localhost:44370/api/Department`)
      .then(response => {
        console.log(response);
        // JSON responses are automatically parsed.
        this.departments = response.data;
        this.value = { name: response.data[2].name, id: response.data[2].id };
      })
      .catch(e => {
        this.errors.push(e);
      });
  },
   watch: {
    value() {
      console.log(this.value.id);
      this.getShopsByIdDepartment(this.value.id);
    }
  },
  methods: {
    shopAdd() {
      axios
        .post("https://localhost:44370/api/Shop", {departmentId: this.value.id, name: this.name })
        .then(response => {
          console.log(response);
        })
        .catch(e => {
          e;
        });
    },
    nameWithLang({ name }) {
      return `${name}`;
    },
    getShopsByIdDepartment(departmentId) {
      axios
        .get(`https://localhost:44370/api/shop/getShopsByIdDepartment?id=`+departmentId)
        .then(response => {
          this.shops=response.data;
          // JSON responses are automatically parsed.
        })
        .catch(e => {
          return e;
        });
    }
  }
};
</script>
<style scoped>
.shopSearch{
  background-color: white;
  border: 1px solid #CED4DA;
  padding: 7px;
  cursor: pointer;
}
</style>