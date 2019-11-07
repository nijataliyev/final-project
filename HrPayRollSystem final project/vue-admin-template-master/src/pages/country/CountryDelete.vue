<template>
    <v-dialog max-width="600px">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Delete">&#xE872;</i></button>
        <v-card>
            <v-card-title class="cardTitle">
                <form action="">
                    <div class="form-group">
                        <label for="">Are you sure delete?</label>
                    </div>
                    <button @click="deleteCountry" class="btn btn-primary">Yes</button>
                    <button class="btn btn-danger">No</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>a
<script>
import axios from 'axios';
export default {
    props:["countryId"],
    data(){
        return{
            name:""
        }
    },
    methods:{
        deleteCountry(){
    axios.delete('https://localhost:44370/api/Country/'+this.countryId,{name:this.name})
    .then(response =>{
        console.log("1");
        console.log(response);
    })
    .catch(e=>{
        console.log(e);
    })
}
    }
}
</script>
<style scoped>
    label{
        display: block;
        font-size: 25px;
    }
    .myIcon{
        color: red;
    }
</style>