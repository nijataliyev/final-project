<template>
    <v-dialog max-width="600px">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Edit">&#xE254;</i></button>
        <v-card>
            <v-card-title>
                <form >
                    <div class="form-group">
                        <label for="">Company Name Edit</label>
                        <input type="text" value="" v-model="name" class="form-control">
                    </div>
                    <button class="btn btn-primary" @click="editCompany">Save</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>a
<script>
import axios from 'axios';

export default {
    props:["companyId"],
    data(){
         return {
        name: "",
     
        };
    },
    methods:{
        editCompany(){
            axios
            .put(`https://localhost:44370/api/Company/`+this.companyId,{name:this.name})
            .then(response => {
                console.log(response);
                // JSON responses are automatically parsed.
                this.companies = response.data;
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