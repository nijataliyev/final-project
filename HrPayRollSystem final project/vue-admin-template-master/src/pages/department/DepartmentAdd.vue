<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <form action>
          <div class="form-group">
            <label for>Company Add</label>
            <multiselect
              class="departmentSearch"
              v-model="value"
              :options="companies"
              :custom-label="nameWithLang"
              placeholder="Select one"
              label="name"
              track-by="name"
            ></multiselect>
          </div>
          <div class="form-group">
            <label for="">Department Add</label>
            <input type="text" v-model="name" class="form-control">
          </div>
          <button @click="departmentAdd" class="btn btn-primary">Department Add</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import Multiselect from "vue-multiselect";
export default {
  name: "DepartmentAdd",
  components:{
      Multiselect
  },
  data() {
    return {
      name: "",
      companies:[],
      value:{name:'',id:1}

    };
  },
  created(){
    axios.get('https://localhost:44370/api/Company')
    .then(response =>{
      console.log(response);
      this.companies = response.data;
      this.value = {name: response.data[0].name, id:response.data[0].id};
    })
    .catch(e =>{
      return e;
    })
  },
  watch:{
    value(){
      console.log(this.value.id);
      this.getDepartmentByIdCompany(this.value.id);
    }
  },
  methods: {
    nameWithLang({name}){
      return `${name}`;
    },
    departmentAdd() {
      axios
        .post("https://localhost:44370/api/Department", {companyId: this.value.id, name: this.name })
        .then(response => {
          console.log(response);
        })
        .catch(e => {
          return e;
        });
    },
    getDepartmentByIdCompany(companyId){
      axios
      .get(`https://localhost:44370/api/department/getDepartmentByIdCompany?id=`+companyId)
      .then(response =>{
        console.log(response);
        this.departments = response.data;
      })
      .catch(e => {
          return (e);
      });
    }
  }
};
</script>

<style scoped>
.departmentSearch{
  background-color: white;
  border: 1px solid #CED4DA;
  padding: 7px;
  cursor: pointer;
}
</style>