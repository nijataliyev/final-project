<template>
    <v-dialog max-width="600px">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Edit">&#xE254;</i></button>
        <v-card>
            <v-card-title>
                <form >
                    <div class="form-group">
                        <label for="">City Name Edit</label>
                        <input type="text" value="" v-model="name" class="form-control">
                    </div>
                    <button class="btn btn-primary" @click="editCity">Save</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>
<script>
import axios from 'axios';

export default {
    props:["cityId"],
    data(){
         return {
        name: "",
        countries:[]
        };
    },
    methods:{
        editCity(){
            console.log(this.cityId)
            axios
            .put(`https://localhost:44370/api/City/editCityByCountryId?id=`+this.cityId,{name:this.name})
            .then(response => {
     
                // JSON responses are automatically parsed.
                this.countries = response.data;
            })
            .catch(e => {
    
            });
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
        color: orange;
    }
</style>