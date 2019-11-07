<template>
    <v-dialog max-width="600px" id="myModal">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Delete">&#xE872;</i></button>
        <v-card>
            <v-card-title class="cardTitle">
                <form action="">
                    <div class="form-group">
                        <label for="">Are you sure delete?</label>
                    </div>
                    <button @click="deleteProfession" class="btn btn-primary">Yes</button>
                    <button @click="cancelProfession()" class="btn btn-danger">No</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>a
<script>
import axios from "axios";
export default {
    props:["professionId"],
    data(){
        return{
            name:"",
            modal: false
        }
    },
    methods:{
        deleteProfession(){
            axios.delete('https://localhost:44370/api/Profession/'+this.professionId,{name:this.name})
            .then(response =>{
                console.log(response);
            })
            .catch(e=>{
                console.log(e);
            })
        },
        cancelProfession(){
            if(this.modal == false)
            {
                this.modal == true;
            }else{
                this.modal == false;
            }
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