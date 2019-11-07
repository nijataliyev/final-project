<template>
    <v-dialog max-width="600px" id="myModal">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Delete">&#xE872;</i></button>
        <v-card>
            <v-card-title class="cardTitle">
                <form action="">
                    <div class="form-group">
                        <label for="">Are you sure delete?</label>
                    </div>
                    <button @click="deleteCity" class="btn btn-primary">Yes</button>
                    <button @click="cancelCity" class="btn btn-danger">No</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>a
<script>
import axios from "axios";
export default {
    props:["cityId"],
    data(){
        return{
            name:""
        }
    },
    methods:{
        deleteCity(){
            axios.delete('https://localhost:44370/api/City/'+this.cityId)
            .then(response =>{

            })
            .catch(e=>{

            })
        },
        cancelCompany(){
            this.$refs['myModal'].hide();
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