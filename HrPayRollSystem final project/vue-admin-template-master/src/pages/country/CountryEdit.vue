<template>
    <v-dialog max-width="600px">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Edit">&#xE254;</i></button>
        <v-card>
            <v-card-title>
                <form action="">
                    <div class="form-group">
                        <label for="">Country Name Edit</label>
                        <input type="text" value="" class="form-control" v-model="name">
                    </div>
                    <button class="btn btn-primary" @click="editCountry">Save</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>a
<script>
import axios from 'axios';
export default {
    props:['countryId'],
    data(){
        return{
            name:''
        }
    },
    methods:{
        editCountry(){
            axios
            .put(`https://localhost:44370/api/Country/`+this.countryId,{name:this.name})
            .then(response => {
                console.log(response);
                // JSON responses are automatically parsed.
                this.countries = response.data;
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