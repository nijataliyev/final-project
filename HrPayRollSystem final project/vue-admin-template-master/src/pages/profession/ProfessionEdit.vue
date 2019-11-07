<template>
    <v-dialog max-width="600px">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Edit">&#xE254;</i></button>
        <v-card>
            <v-card-title>
                <form >
                    <div class="form-group">
                        <label for="">Profession Name Edit</label>
                        <input type="text" value="" v-model="name" class="form-control">
                    </div>
                    <button class="btn btn-primary" @click="editProfession">Save</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>a
<script>
import axios from 'axios';

export default {
    props:["profeesionId"],
    data(){
         return {
        name: "",
     
        };
    },
    methods:{
        editProfession(){
            axios
            .put(`https://localhost:44370/api/Profession/`+this.professionId,{name:this.name})
            .then(response => {
                console.log(response);
                // JSON responses are automatically parsed.
                this.professions = response.data;
            })
            .catch(e => {
                console.log(e);
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