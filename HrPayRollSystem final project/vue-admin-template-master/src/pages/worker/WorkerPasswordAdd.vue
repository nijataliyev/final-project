<template>
    <v-dialog max-width="600px">
        <button flat slot="activator"><i class="material-icons myIcon" data-toggle="tooltip" title="Edit">vpn_key</i></button>
        <v-card>
            <v-card-title class="myModal" v-if="!hasPassword">
                <form action="">
                    <div class="form-group">
                        <label for="">Password</label>
                        <input type="text" v-model="password" class="form-control">
                    </div>
                    <div class="form-group">
                        <label for="">Confirm Password</label>
                        <input type="text" v-model="confirmPassword" class="form-control">
                    </div>
                    <button class="btn btn-primary" @click="givePassword">Click</button>
                </form>
            </v-card-title>
            <v-card-title class="myModal" v-if="hasPassword">
                <form action="">
                    <div class="form-group">
                        <label for="">Old Password</label>
                        <input type="text" v-model="oldPassword" class="form-control">
                    </div>
                    <div class="form-group">
                        <label for="">Password</label>
                        <input type="text" v-model="password" class="form-control">
                    </div>
                    <div class="form-group">
                        <label for="">Confirm Password</label>
                        <input type="text" v-model="confirmPassword" class="form-control">
                    </div>
                    <button class="btn btn-primary" @click="givePassword">Click</button>
                </form>
            </v-card-title>
        </v-card>
    </v-dialog>
</template>
<script>
import axios from 'axios';
export default {
    props:["workerId"],
    data(){
         return {
        worker:{
            picture:"",
            name:"",
            surname:"",
            fatherName:""
        },
        password:"",
        confirmPassword:"",
        oldPassword:"",
        hasPassword:false
        }
    },
     created(){
      axios
      .get(`https://localhost:44370/api/Worker/`+this.workerId)
      .then(response => {
        // JSON responses are automatically parsed.
        this.worker = response.data;
        this.hasPassword=response.data.hasPassword;
      })
      .catch(e => {
        this.errors.push(e);
	  });
  },
    methods:{
        givePassword(){
            console.log(this.password);
            console.log(this.confirmPassword);
axios
            .post(`https://localhost:44370/api/Worker/givePassword`,{id:this.workerId,oldpassword:this.oldPassword,password:this.password,confirmPassword:this.confirmPassword})
            .then(response => {
                console.log(response);
                  axios
      .get(`https://localhost:44370/api/Worker/`+this.workerId)
      .then(response => {
        // JSON responses are automatically parsed.
        this.worker = response.data;
        this.hasPassword=response.data.hasPassword;
      })
      .catch(e => {
        this.errors.push(e);
	  });
                // JSON responses are automatically parsed.
            })
            .catch(e => {
                console.log(e);
            });

        }
        // editProfession(){
        //     axios
        //     .put(`https://localhost:44370/api/Profession/`+this.professionId,{name:this.name})
        //     .then(response => {
        //         console.log(response);
        //         // JSON responses are automatically parsed.
        //         this.professions = response.data;
        //     })
        //     .catch(e => {
        //         console.log(e);
        //     });
        // }
    }
}
</script>
<style scoped>

    .myIcon{
        color: orange;
    }
</style>