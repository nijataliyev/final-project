import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import router from '../router/index'

Vue.use(Vuex)

export const store = new Vuex.Store({
    state: {
        token: localStorage.getItem('token') || null,
        role: localStorage.getItem('user_role') || null,
    },
    mutations: {
        destroyToken(state) {
            state.token = null;
            state.role=null;
        },
        getLogin(state, obj) {
            state.token = obj.token
            state.role=obj.role;

            console.log(state.role==="Admin")
        },
       
    },
    getters: {
        loggedIn(state) {
            return state.token !== null
        },
        userRole(state){
            return state.role
        },
        
        getLogin(state, obj) {
            state.token = obj.token;
            state.role=obj.role;

        },
        destroyToken(state) {
            state.token = null;
            state.role=null;

        }
    },
    actions: {
        destroyToken(context) {
            axios.defaults.headers.common['Authorization'] = 'Bearer ' + context.state.token

                    console.log(context.getters.loggedIn)
                    if (context.getters.loggedIn) {
                return new Promise((resolve, reject) => {
                    console.log(2)
                    localStorage.removeItem('token');
                    axios.post('https://localhost:44370/api/login/logout')
                        .then(function (response) {
                            
                          
                            localStorage.removeItem('token')
                        localStorage.removeItem('user_role');
                        context.commit('destroyToken')
                            resolve(response)
                        })
                        .catch(function (error) {
                            localStorage.removeItem('token')
                        localStorage.removeItem('user_role');
                        context.commit('destroyToken')
                            reject(error);
                        });
                })
            }
        },
        getLogin(context, credentials) {
            return new Promise((resolve, reject) => {
                axios.post('https://localhost:44370/api/login/login', credentials)
                    .then(function (response) {
                        console.log(2);
                        console.log(response);
                        console.log(2);
                        const token =response.data.token;
                        const role =response.data.roles[0];
                        console.log(role)
                        localStorage.setItem('token', token);
                        localStorage.setItem('user_role', role);
                        context.commit('getLogin',{token: token,role: role});
                        resolve(response);

                    })
                    .catch(function (error) {
                        console.log(error)
                        reject(error);
                    });
            })
        }
    }
})