// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import Vuex from 'vuex'
import {store} from './store/store'
import 'vuetify/dist/vuetify.min.css'
import 'font-awesome/css/font-awesome.css'
import Vuetify from 'vuetify'

import 'material-design-icons-iconfont/dist/material-design-icons.css'
import './styles/global.css'

import axios from 'axios'
import VueAxios from 'vue-axios'

Vue.use(VueAxios, axios)

import VueChartkick from 'vue-chartkick'
import Chart from 'chart.js'
import fullCalendar from 'vue-fullcalendar'
import { setupComponents } from './config/setup-components'

import swatches from 'vue-swatches'
import "vue-swatches/dist/vue-swatches.min.css"
import vSelect from 'vue-select'

Vue.use(Vuex)
Vue.component('v-select', vSelect)
Vue.use(VueChartkick, { adapter: Chart })
Vue.component('full-calendar', fullCalendar)
Vue.component('swatches', swatches)

setupComponents(Vue)

Vue.use(Vuetify)

Vue.config.productionTip = false

router.beforeEach((to, from, next) => {

  const { authorize } = to.meta;
  const role = store.getters.userRole==null?'':store.getters.userRole.toUpperCase();
  console.log(authorize);
  console.log(role);

  if(authorize){
  console.log(3)

    if(!authorize.map(x=>x.toUpperCase()).includes(role)){
  console.log(4)

      return next({ path: '', query: { returnUrl: from.path } });
    }
  }
  console.log(2)
  return next()
  // if (to.matched.some(record => record.meta.requiresAuth) ) {
  //   if (!store.getters.loggedIn) {
  //     next({
  //       name: 'Login',
  //     })
  //   } else {
  //       if (to.matched.some(record => record.meta.qwerty) ){
  //         next({
  //           name: 'Login',
  //         })
  //     }
  //     next()
  //   }
  // } else {
  //   next()
  // }
})

/* eslint-disable no-new */
new Vue({
  el: '#app',
  store,
  router,
  components: { App },
  template: '<App/>',
  data: {
    themeColor: '#1D2939',
    userEmail: 'Admin',
    userPassword: 'qwerty123Q@'
  }
})
