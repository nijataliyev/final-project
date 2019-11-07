<template>
  <v-navigation-drawer v-model="toggle" fixed app>
    <v-toolbar flat dark :color="$root.themeColor" class="toolbar">
      <router-link :to="{ name: 'Home' }">
        <img src="static/HR-icon.png" width="36px" />
      </router-link>
      <router-link :to="{ name: 'Home' }" class="text">Hr PayRoll System</router-link>
    </v-toolbar>
    <v-list>
      <v-list-group v-for="item in controleNav" :key="item.activator" v-if="item.authorize.map(a => a.toUpperCase()).includes(role.toUpperCase())" :prepend-icon="item.icon">
        <v-list-tile slot="activator">
          <v-list-tile-title class="item-title">{{item.activator}}</v-list-tile-title>
        </v-list-tile>
        <v-list-tile
          v-for="ite in item.items"
          :key="ite.text"
          v-if="ite.authorize.map(a => a.toUpperCase()).includes(role.toUpperCase())"
          @click="changeRoute(ite.route.name, ite.route.selectedIndex)"
        >
          <v-list-tile-action>
            <v-icon>{{ite.icon}}</v-icon>
          </v-list-tile-action>
          <v-list-tile-title
            :class="[{'active': selectedIndex === ite.route.selectedIndex}, 'item-title' ]"
          >{{ite.text}}</v-list-tile-title>
        </v-list-tile>
      </v-list-group>


      <!-- <v-list-group prepend-icon="location_city">
        <v-list-tile slot="activator">
          <v-list-tile-title class="item-title">Company</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('CompanyAdd', 4)">
          <v-list-tile-action>
            <v-icon>location_city</v-icon>
          </v-list-tile-action>
          <v-list-tile-title :class="[{'active': selectedIndex === 4}, 'item-title' ]">Company Add</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('CompanyList', 5)">
          <v-list-tile-action>
            <v-icon>bar_chart</v-icon>
          </v-list-tile-action>
          <v-list-tile-title :class="[{'active': selectedIndex === 5}, 'item-title' ]">Company List</v-list-tile-title>
        </v-list-tile>
      </v-list-group> -->

      <!-- <v-list-group prepend-icon="public">
        <v-list-tile slot="activator">
          <v-list-tile-title class="item-title">Country</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('CountryAdd', 6)">
          <v-list-tile-action>
            <v-icon>public</v-icon>
          </v-list-tile-action>
          <v-list-tile-title :class="[{'active': selectedIndex === 6}, 'item-title' ]">Country Add</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('CountryList', 7)">
          <v-list-tile-action>
            <v-icon>bar_chart</v-icon>
          </v-list-tile-action>
          <v-list-tile-title :class="[{'active': selectedIndex === 7}, 'item-title' ]">Country LIst</v-list-tile-title>
        </v-list-tile>
      </v-list-group> -->

      <!-- <v-list-group prepend-icon="public">
        <v-list-tile slot="activator">
          <v-list-tile-title class="item-title">City</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('CityAdd', 8)">
          <v-list-tile-action>
            <v-icon>public</v-icon>
          </v-list-tile-action>
          <v-list-tile-title :class="[{'active': selectedIndex === 8}, 'item-title' ]">City Add</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('CityList', 9)">
          <v-list-tile-action>
            <v-icon>bar_chart</v-icon>
          </v-list-tile-action>
          <v-list-tile-title :class="[{'active': selectedIndex === 9}, 'item-title' ]">City List</v-list-tile-title>
        </v-list-tile>
      </v-list-group> -->

      <!-- <v-list-group prepend-icon="location_city">
        <v-list-tile slot="activator">
          <v-list-tile-title class="item-title">Department</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('DepartmentAdd', 10)">
          <v-list-tile-action>
            <v-icon>location_city</v-icon>
          </v-list-tile-action>
          <v-list-tile-title
            :class="[{'active': selectedIndex === 10}, 'item-title' ]"
          >Department Add</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('DepartmentList', 11)">
          <v-list-tile-action>
            <v-icon>bar_chart</v-icon>
          </v-list-tile-action>
          <v-list-tile-title
            :class="[{'active': selectedIndex === 11}, 'item-title' ]"
          >Department List</v-list-tile-title>
        </v-list-tile>
      </v-list-group> -->

      <!-- <v-list-group prepend-icon="layers">
        <v-list-tile slot="activator">
          <v-list-tile-title class="item-title">Profession</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('ProfessionAdd', 12)">
          <v-list-tile-action>
            <v-icon>layers</v-icon>
          </v-list-tile-action>
          <v-list-tile-title
            :class="[{'active': selectedIndex === 12}, 'item-title' ]"
          >Profession Add</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('ProfessionList', 13)">
          <v-list-tile-action>
            <v-icon>bar_chart</v-icon>
          </v-list-tile-action>
          <v-list-tile-title
            :class="[{'active': selectedIndex === 13}, 'item-title' ]"
          >Profession List</v-list-tile-title>
        </v-list-tile>
      </v-list-group> -->

      <!-- <v-list-group prepend-icon="store_mall_directory">
        <v-list-tile slot="activator">
          <v-list-tile-title class="item-title">Shop</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('ShopAdd', 14)">
          <v-list-tile-action>
            <v-icon>store_mall_directory</v-icon>
          </v-list-tile-action>
          <v-list-tile-title :class="[{'active': selectedIndex === 14}, 'item-title' ]">Shop Add</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('ShopList', 15)">
          <v-list-tile-action>
            <v-icon>bar_chart</v-icon>
          </v-list-tile-action>
          <v-list-tile-title :class="[{'active': selectedIndex === 15}, 'item-title' ]">Shop List</v-list-tile-title>
        </v-list-tile>
      </v-list-group> -->

      <!-- <v-list-group prepend-icon="local_atm">
        <v-list-tile slot="activator">
          <v-list-tile-title class="item-title">Payroll Specialist</v-list-tile-title>
        </v-list-tile>
        <v-list-tile @click="changeRoute('Ps', 16)">
          <v-list-tile-action>
            <v-icon>local_atm</v-icon>
          </v-list-tile-action>
          <v-list-tile-title :class="[{'active': selectedIndex === 16}, 'item-title' ]">Salary Add</v-list-tile-title>
        </v-list-tile>
      </v-list-group> -->

    </v-list>
  </v-navigation-drawer>
</template>

<script>
import {store} from '../../store/store'


export default {
  props: {
    toggle: {
      type: Boolean,
      required: false,
      default: true
    }
  },

  data() {
    return {
      selectedIndex: 1,
      admins: [["Management", "people_outline"], ["Settings", "settings"]],
      role:"",
    
      controleNav: [
        {
          activator: "Worker",
          icon: "group",
          authorize: ["Admin","Hr"],
          items: [
            {
              authorize: ["Admin","Hr"],
              text: "Worker Add",
              icon: "group_add",
              route: {
                name: "WorkerAdd",
                selectedIndex: 2
              }
            },
            {
              authorize: ["Admin","Hr"],
              text: "Worker List",
              icon: "bar_chart",
              route: {
                name: "WorkerList",
                selectedIndex: 3
              }
            },
            {
              authorize:["Admin","Hr"],
              text: "OldWorkerInfo",
              icon: "bar_chart",
              route:{
                name:"OldWorkerInfo",
                selectedIndex: 4
              }
            },
            {
              authorize:["Admin","Hr"],
              text: "WorkerAppsent",
              icon: "bar_chart",
              route:{
                name:"WorkerAppsent",
                selectedIndex: 5
              }
            },
            {
              authorize:["Admin","Hr"],
              text: "WorkerAppsentHistory",
              icon: "bar_chart",
              route:{
                name:"WorkerAppsentHistory",
                selectedIndex: 6
              }
            }
          ]
        },
        {
          activator: "Company",
          icon: "location_city",
          authorize: ["Admin"],
          items: [
            {
              authorize: ["Admin"],
              text: "Company Add",
              icon: "location_city",
              route: {
                name: "CompanyAdd",
                selectedIndex: 7
              }
            },
            {
              authorize: ["Admin"],
              text: "Company List",
              icon: "bar_chart",
              route: {
                name: "CompanyList",
                selectedIndex: 8
              }
            }
          ]
        },
        {
          activator: "Country",
          icon: "public",
          authorize: ["Admin"],
          items: [
            {
              authorize: ["Admin"],
              text: "Country Add",
              icon: "public",
              route: {
                name: "CountryAdd",
                selectedIndex: 9
              }
            },
            {
              authorize: ["Admin"],
              text: "Country List",
              icon: "bar_chart",
              route: {
                name: "CountryList",
                selectedIndex: 10
              }
            }
          ]
        },
        {
          activator: "City",
          icon: "public",
          authorize: ["Admin"],
          items: [
            {
              authorize: ["Admin"],
              text: "City Add",
              icon: "public",
              route: {
                name: "CityAdd",
                selectedIndex: 11
              }
            },
            {
              authorize: ["Admin"],
              text: "City List",
              icon: "bar_chart",
              route: {
                name: "CityList",
                selectedIndex: 12
              }
            }
          ]
        },
        {
          activator: "Department",
          icon: "location_city",
          authorize: ["Admin"],
          items: [
            {
              authorize: ["Admin"],
              text: "Department Add",
              icon: "location_city",
              route: {
                name: "DepartmentAdd",
                selectedIndex: 13
              }
            },
            {
              authorize: ["Admin"],
              text: "Department List",
              icon: "location_city",
              route: {
                name: "DepartmentList",
                selectedIndex: 14
              }
            }
          ]
        },
        {
          activator: "Profession",
          icon: "layers",
          authorize: ["Admin"],
          items: [
            {
              authorize: ["Admin"],
              text: "Profession Add",
              icon: "layers",
              route: {
                name: "ProfessionAdd",
                selectedIndex: 15
              }
            },
            {
              authorize: ["Admin"],
              text: "Profession List",
              icon: "layers",
              route: {
                name: "ProfessionList",
                selectedIndex: 16
              }
            }
          ]
        },
        {
          activator: "Shop",
          authorize: ["Admin"],
          icon: "store_mall_directory",
          items: [
            {
          authorize:["Admin"],
              text: "Shop Add",
              icon: "store_mall_directory",
              route: {
                name: "ShopAdd",
                selectedIndex: 17
              }
            },
            {
          authorize:["Admin"],
              text: "Shop List",
              icon: "store_mall_directory",
              route: {
                name: "ShopList",
                selectedIndex: 18
              }
            }
          ]
        },
        {
          activator:"PayRollSpecialist",
          authorize:["Admin","Ps"],
          icon: "local_atm",
          items:[{
          authorize:["Admin","Ps"],
            text:"Ps Salary add",
            icon: "local_atm",
            route:{
            name:"PayRollSpecialist",
            selectedIndex:19
          }
          }]
        },
        {
          activator:"DhWorkerList",
          authorize:["Admin","Dh"],
          icon:"local_atm",
          items:[{
            authorize:["Admin","Dh"],
            text:"Department Header Worker",
            icon:"local_atm",
            route:{
              name:"DhWorkerList",
              selectedIndex:20
            }
          }]
        }
      ]
    };
  },
  created(){
    this.role = store.getters.userRole;
    console.log(7);
    console.log(this.role);
    console.log(7);
    console.log(this.controleNav);
  
  },
  methods: {
    changeRoute(routeName, selectedIndex) {
      const vm = this;
      console.log(1231313);
      console.log(routeName);
      console.log(selectedIndex);

      vm.selectedIndex = selectedIndex;

      return vm.$router.push({ name: routeName });
    }
  }
};
</script>

<style scoped>
img{
  width: 50px;
  height: 50px;
}
.toolbar {
  font-weight: bold;
  font-size: 18px;
}

.toolbar .text {
  padding-left: 15px;
  color: white;
  text-decoration: none;
}

.item-title {
  font-size: 17px;
  font-weight: 500;
}
.item-sub-title {
  font-size: 15px;
  font-weight: 500;
}

.active {
  font-weight: bold;
}
</style>
