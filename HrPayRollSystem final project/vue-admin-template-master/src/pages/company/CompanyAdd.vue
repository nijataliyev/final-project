<template>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <form action="">
                    <div class="form-group">
                        <input type="text" class="form-control" v-model="name">
                    </div>
                    <button @click="companyAdd" class="btn btn-primary">Company Add</button>
                </form>
            </div>
        </div>
    </div>
</template>
<script>
import axios from 'axios';
export default {
    name:'CompanyAdd',
    data(){
        return{
            name:''
        }
    },
    methods:{
        companyAdd(){
            axios.post('https://localhost:44370/api/Company', {name: this.name})
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