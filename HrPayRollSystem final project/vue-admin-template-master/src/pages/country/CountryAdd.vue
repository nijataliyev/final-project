<template>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <form action="" @submit.prevent="">
                    <div class="form-group">
                        <label for="">Country</label>
                        <input type="text" class="form-control" v-model="name">
                    </div>
                    <button class="btn btn-primary" @click="countryAdd">Country Add</button>
                </form>
            </div>
        </div>
    </div>
</template>
<script>
import axios from 'axios'
export default {
    name: 'CountryAdd',
    data(){
        return{
            name:''
        }
    },
    methods:{
        countryAdd(){
                axios.post('https://localhost:44370/api/Country', {name: this.name})
                .then(response => {
                    console.log(response);
                    this.name=""
                })
            .catch(e => {
                (e)
            })
        }
    }
    
}
</script>
<style scoped>

</style>