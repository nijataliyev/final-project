<template>
    <v-dialog max-width="600px" id="myModal">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Delete">&#xE872;</i></button>
        <v-card>
            <v-card-title class="cardTitle">
                <form action="">
                    <div class="form-group">
                        <label for="">Are you sure delete?</label>
                    </div>
                    <button @click="deleteDepartment" class="btn btn-primary">Yes</button>
                    <button @click="cancelDepartment" class="btn btn-danger">No</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>a
<script>
import axios from "axios";
export default {
    props:["departmentId"],
    data(){
        return{
            name:""
        }
    },
    methods:{
        deleteDepartment(){
            axios.delete('https://localhost:44370/api/Department/'+this.departmentId,{name:this.name})
            .then(response =>{
                console.log(response);
            })
            .catch(e=>{
                console.log(e);
            })
        },
        cancelDepartment(){
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