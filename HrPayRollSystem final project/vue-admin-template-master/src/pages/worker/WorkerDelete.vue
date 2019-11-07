<template>
    <v-dialog max-width="600px" id="myModal">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Delete">&#xE872;</i></button>
        <v-card>
            <v-card-title class="cardTitle">
                <form action="">
                    <div class="form-group">
                        <label for="">Are you sure delete?</label>
                    </div>
                    <button @click="cancelWorker()" class="btn btn-danger">No</button>
                    <button @click="deleteWorker()" class="btn btn-primary">Yes</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>a
<script>
import axios from "axios";
export default {
    props:["workerId"],
    data(){
        return{
            name:"",
            modal: false
        }
    },
    methods:{
        deleteWorker(){
            axios
            .delete(`https://localhost:44370/api/Worker/`+this.workerId)
            .then(response => {
                console.log(response)
                if(response.data===1){
                    console.log("deleted")
                    this.$parent.getWorkers();

                }
                else{
                    console.log("not deleted")

                }
            })
            .catch(e => {
                this.errors.push(e);
            });
        },
        cancelWorker(){
            
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