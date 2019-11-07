<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <form action>
          <div class="form-group">
            <label for="">Profession Add</label>
            <input type="text" v-model="name" class="form-control">
          </div>
          <button class="btn btn-primary">Profession Add</button>
        </form>
      </div>
    </div>
  </div>
</template>
<script>
import axios from "axios";
export default {
    name:'ProfessionAdd',
    data(){
        return{
            workers: [],
            name:""
        }
    },
  methods: {

  }
};
</script>
<style scoped>
</style>