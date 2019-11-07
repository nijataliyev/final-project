import Vue from 'vue';
import Router from 'vue-router';

import Login from '../pages/core/Login.vue';
import Error from '../pages/core/Error.vue';
import WorkerAdd from '../pages/worker/WorkerAdd';
import WorkerList from '../pages/worker/WorkerList';
import CountryAdd from '../pages/country/CountryAdd';
import CountryList from '../pages/country/CountryList';
import CityAdd from '../pages/city/CityAdd';
import CityList from '../pages/city/CityList';
import CompanyAdd from '../pages/company/CompanyAdd';
import CompanyList from '../pages/company/CompanyList';
import DepartmentAdd from '../pages/department/DepartmentAdd';
import DepartmentList from '../pages/department/DepartmentList';
import ProfessionAdd from '../pages/profession/ProfessionAdd';
import ProfessionList from '../pages/profession/ProfessionList';
import ShopAdd from '../pages/shop/ShopAdd';
import ShopList from '../pages/shop/ShopList';
import PayRollSpecialist from '../pages/payrollSpecialist/payrollSpecialist';
import Home from '../pages/home/home';
import DhWorkerList from '../pages/departmentHeader/DhWorkerList';
import OldWorkerInfo from '../pages/worker/OldWorkerInfo';
import WorkerAppsent from '../pages/worker/WorkerAppsent';
import WorkerAppsentHistory from '../pages/worker/WorkerAppsentHistory';
Vue.use(Router);

import {store} from '../store/store' // your vuex store 



export default new Router({
  routes: [
    {
      path:'/',
      name: 'Home',
      component: Home,
      meta: {
        requiresAuth:true,
        breadcrumb:[
          { name: 'Home' }
        ]
      }
    },
    {
      path:'/workerAdd',
      name: 'WorkerAdd',
      component: WorkerAdd,
      meta: {
        requiresAuth:true,

        authorize:["Admin","Hr","Dh"],

        breadcrumb:[
          { name: 'WorkerAdd' }
        ]
      }
    },
    {
      path:'/workerList',
      name: 'WorkerList',
      component: WorkerList,
   
      meta: {
        requiresAuth:true,
        authorize:["Admin","Hr"],

        breadcrumb:[
          { name: 'WorkerList' }
        ]
      }
    },
    {
      path:'/workerAppsent',
      name: 'WorkerAppsent',
      component: WorkerAppsent,
   
      meta: {
        requiresAuth:true,
        authorize:["Admin","Hr"],

        breadcrumb:[
          { name: 'WorkerAppsent' }
        ]
      }
    },
    {
      path:'/workerAppsentHistory',
      name: 'WorkerAppsentHistory',
      component: WorkerAppsentHistory,
   
      meta: {
        requiresAuth:true,
        authorize:["Admin","Hr"],

        breadcrumb:[
          { name: 'WorkerAppsentHistory' }
        ]
      }
    },
    {
      path:"/oldWorkerInfo",
      name: "OldWorkerInfo",
      component: OldWorkerInfo,
      meta:{
        requiresAuth:true,
        authorize:["Admin","Hr"],
        breadcrumb:[
          {name:'OldWorkerInfo'}
        ]
      }
    },
    {
      path:'/dhWorkerList',
      name: 'DhWorkerList',
      component: DhWorkerList,
   
      meta: {
        requiresAuth:true,
        authorize:["Admin","Dh"],
        breadcrumb:[
          { name: 'DhWorkerList' }
        ]
      }
    },
    {
      path:'/countryAdd',
      name: 'CountryAdd',
      component: CountryAdd,
     
        meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'CountryAdd' }
        ]
      }
    },
    {
      path:'/countryList',
      name: 'CountryList',
      component: CountryList,
    
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'CountryList' }
        ]
      }
    },
    {
      path:'/payrollspecialist',
      name: 'PayRollSpecialist',
      component: PayRollSpecialist,
    
        meta: {
        requiresAuth:true,
        authorize:["Admin","Ps"],
        breadcrumb:[
          { name: 'PayRollSpecialist' }
        ]
      }
    },
    {
      path:'/cityAdd',
      name: 'CityAdd',
      component: CityAdd,
    
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'CityAdd' }
        ]
      }
    },
    {
      path:'/cityList',
      name: 'CityList',
      component: CityList,
    
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'CityList' }
        ]
      }
    },
    {
      path:'/companyAdd',
      name: 'CompanyAdd',
      component: CompanyAdd,
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'CompanyAdd' }
        ]
      }
    },
    {
      path:'/companyList',
      name: 'CompanyList',
      component: CompanyList,
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'CompanyList' }
        ]
      }
    },
    {
      path:'/departmentAdd',
      name: 'DepartmentAdd',
      component: DepartmentAdd,
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'DepartmentAdd' }
        ]
      }
    },
    {
      path:'/departmentList',
      name: 'DepartmentList',
      component: DepartmentList,
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'DepartmentList' }
        ]
      }
    },
    {
      path:'/professionAdd',
      name: 'ProfessionAdd',
      component: ProfessionAdd,
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'ProfessionAdd' }
        ]
      }
    },
    {
      path:'/professionList',
      name: 'ProfessionList',
      component: ProfessionList,
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'ProfessionList' }
        ]
      }
    },
    {
      path:'/shopAdd',
      name: 'ShopAdd',
      component: ShopAdd,
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'ShopAdd' }
        ]
      }
    },
    {
      path:'/shopList',
      name: 'ShopList',
      component: ShopList,
      meta: {
        requiresAuth:true,
        authorize:["Admin"],
        breadcrumb:[
          { name: 'ShopList' }
        ]
      }
    },
    {
      path: '/login',
      name: 'Login',
      component: Login,
      meta: {
        allowAnonymous: true
      }
    },
    {
      path: '/error',
      name: 'Error',
      component: Error,
      meta: {
        allowAnonymous: true
      }
    },
  ]
});

