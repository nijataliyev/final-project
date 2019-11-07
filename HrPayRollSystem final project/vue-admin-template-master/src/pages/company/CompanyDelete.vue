<template>
    <v-dialog max-width="600px" id="myModal">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Delete">&#xE872;</i></button>
        <v-card>
            <v-card-title class="cardTitle">
                <form action="">
                    <div class="form-group">
                        <label for="">Are you sure delete?</label>
                    </div>
                    <button @click="deleteCompany" class="btn btn-primary">Yes</button>
                    <button @click="cancelCompany" class="btn btn-danger">No</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>a
<script>
import axios from "axios";
export default {
    props:["companyId"],
    data(){
        return{
            name:"",
        }
    },
    methods:{
        deleteCompany(){
            axios.delete('https://localhost:44370/api/Company/'+this.companyId,{name:this.name})
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