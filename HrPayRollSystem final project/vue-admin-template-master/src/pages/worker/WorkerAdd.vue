<template>
  <div class="worker-add container">
    <div class="row">
      <div class="col-md-4">
        <form action>
          <div class="form-group">
            <label for>Ad</label>
            <input type="text" class="form-control" v-model="name" />
          </div>
          <div class="form-group">
            <label for>Ata adı</label>
            <input type="text" class="form-control" v-model="fatherName" />
          </div>
          <div class="form-group">
            <label for>Doğum tarixi</label>
            <v-menu :close-on-content-click="false">
              <v-text-field
                :value="format_birthDate"
                slot="activator"
                label="Tarixi seç"
                prepend-icon="date_range"
              ></v-text-field>
              <v-date-picker v-model="birthdate"></v-date-picker>
            </v-menu>
          </div>
        </form>
      </div>
      <div class="col-md-4">
        <form action>
          <div class="form-group">
            <label for>Soyad</label>
            <input type="text" class="form-control" v-model="surname" />
          </div>
          <div class="form-group">
            <label for>Şəxsiyyət nömrəsi</label>
            <input type="text" class="form-control" v-model="passportNumber" />
          </div>
          <div class="form-group">
            <label for>Şəxsiyyət bitmə tarixi</label>
            <v-menu :close-on-content-click="false">
              <v-text-field
                :value="format_expireDate"
                slot="activator"
                label="Tarixi seç"
                prepend-icon="date_range"
              ></v-text-field>
              <v-date-picker v-model="passportExpireDate"></v-date-picker>
            </v-menu>
          </div>
        </form>
      </div>
      <div class="col-md-4">
        <form action>
          <div class="card offset-1 col-md-10">
            <div class="card-body tex-center d-flex align-items-center flex-column">
              <img
                height="128"
                class="img-responsive text-center mb-3"
                :src="selectedImage == null ? 'https://image.shutterstock.com/image-photo/beautiful-water-drop-on-dandelion-260nw-789676552.jpg' : selectedImage"
              />
              <label for="upload" class="myImage">Picture</label>
              <input
                ref="file"
                type="file"
                id="upload"
                @change="onChange"
                accept="image/*"
                class="form-control upload-file"
              />
            </div>
          </div>
        </form>
      </div>
    </div>
    <div class="row">
      <div class="col-md-6">
        <form action>
          <div class="form-group">
            <label for>Ölkə</label>
            <multiselect
              class="MySearch"
              v-model="countryValue"
              :options="countries"
              :custom-label="nameWithLang"
              placeholder="Select one"
              label="name"
              track-by="name"
            ></multiselect>
          </div>
          <div class="form-group">
            <label for>Yaşayış Ünvanı</label>
            <input type="text" class="form-control" v-model="livingAddress" />
          </div>
        </form>
      </div>
      <div class="col-md-6">
        <form action>
          <div class="form-group">
            <label for>Şəhər</label>
            <multiselect
              :disabled="cityIsEmpty"
              class="MySearch"
              v-model="cityValue"
              :options="cities"
              :custom-label="nameWithLang"
              placeholder="Select one"
              label="name"
              track-by="name"
            ></multiselect>
          </div>
          <div class="form-group">
            <label for>Kompaniya</label>
            <multiselect
              class="MySearch"
              v-model="companyValue"
              :options="companies"
              :custom-label="nameWithLang"
              placeholder="Select one"
              label="name"
              track-by="name"
            ></multiselect>
          </div>
          <div class="form-group">
            <label for>Şöbə</label>
            <multiselect
              class="MySearch"
              :disabled="departmentIsEmpty"
              v-model="departmentValue"
              :options="departments"
              :custom-label="nameWithLang"
              placeholder="Select one"
              label="name"
              track-by="name"
            ></multiselect>
          </div>
        </form>
      </div>
    </div>
    <div class="row">
      <div class="col-md-3">
        <form action>
          <div class="form-group">
            <label for>Cins</label>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="radio" v-model="gender" value="1" />
              <span class="form-check-label">Kişi</span>
            </div>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="radio" v-model="gender" value="2" />
              <span class="form-check-label">Qadın</span>
            </div>
          </div>
          <div class="form-group">
            <label for>Ailə vəziyyəti</label>
            <div class="form-check form-check-inline">
              <input class="form-check-input" v-model="family" type="radio" value="1" />
              <span class="form-check-label">Subay</span>
            </div>
            <div class="form-check form-check-inline">
              <input class="form-check-input" v-model="family" type="radio" value="2" />
              <span class="form-check-label">Evli</span>
            </div>
          </div>
          <div class="form-group">
            <label for>Təhsil</label>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="radio" v-model="education" value="1" />
              <span class="form-check-label">Orta</span>
            </div>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="radio" v-model="education" value="2" />
              <span class="form-check-label">Bakalavr</span>
            </div>
          </div>
          <div class="form-group">
            <label for>Role</label>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="radio" v-model="roleType" value="1" />
              <span class="form-check-label">Admin</span>
            </div>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="radio" v-model="roleType" value="2" />
              <span class="form-check-label">Hr</span>
            </div>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="radio" v-model="roleType" value="3" />
              <span class="form-check-label">Ps</span>
            </div>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="radio" v-model="roleType" value="4" />
              <span class="form-check-label">Dh</span>
            </div>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="radio" v-model="roleType" value="5" />
              <span class="form-check-label">Other</span>
            </div>
          </div>
        </form>
      </div>
      <div class="col-md-9">
        <form action>
          <div class="form-group">
            <label for>Vəzifə</label>
            <multiselect
              class="MySearch"
              v-model="professionValue"
              :options="professions"
              :custom-label="nameWithLang"
              placeholder="Select one"
              label="name"
              track-by="name"
            ></multiselect>
          </div>
          <div class="form-group">
            <label for>Mağaza</label>
            <multiselect
              class="MySearch"
              v-model="shopValue"
              :options="shops"
              :custom-label="nameWithLang"
              placeholder="Select one"
              label="name"
              track-by="name"
            ></multiselect>
          </div>
          <div class="form-group">
            <label for>İşə başlama tarixi</label>
            <v-menu :close-on-content-click="false">
              <v-text-field
                :value="format_date"
                slot="activator"
                label="Tarixi seç"
                prepend-icon="date_range"
              ></v-text-field>
              <v-date-picker v-model="startDateWork"></v-date-picker>
            </v-menu>
          </div>
        </form>
      </div>
    </div>
    <div class="row">
      <div class="col-md-2">
        <form action>
          <div class="form-group">
            <button class="btn btn-primary" @click="save">İşçi əlavə et</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>
<script>
// import format from 'date-fns/format';
import moment from "moment";
import Multiselect from "vue-multiselect";
import axios from "axios";
export default {
  name: "WorkerAdd",
  components: {
    Multiselect
  },
  data() {
    return {
      imageList: [],
      selectedImage: null,
      // imageData: "",
      cityIsEmpty: true,
      departmentIsEmpty: true,
      countryValue: { name: "Not item", id: 0 },
      departmentValue: { name: "Not item", id: 0 },
      cityValue: { name: "Not item", id: 0 },
      shopValue: { name: "Not item", id: 0 },
      professionValue: { name: "Not item", id: 0 },
      companyValue: { name: "Not item", id: 0 },
      selected: "Choose ",
      name: "",
      gender: 0,
      family: 0,
      education: 0,
      roleType: 0,
      surname: "",
      fatherName: "",
      passportNumber: "",
      passportExpireDate: "",
      birthdate: "",
      startDateWork: null,
      livingAddress: "",
      countries: [],
      companies: [],
      cities: [],
      departments: [],
      professions: [],
      shops: []
    };
  },
  created() {
    axios.get("https://localhost:44370/api/Country").then(response => {
      this.countries = response.data;
      if (response.data.length !== 0) {
        this.countryValue = {
          name: response.data[0].name,
          id: response.data[0].id
        };
      }
    }),
      axios.get("https://localhost:44370/api/Company").then(response => {
        this.companies = response.data;
        if (response.data.length !== 0) {
          this.companyValue = {
            name: response.data[0].name,
            id: response.data[0].id
          };
        }
      }),
      axios.get("https://localhost:44370/api/Profession").then(response => {
        this.professions = response.data;
        if (response.data.length !== 0) {
          this.professionValue = {
            name: response.data[0].name,
            id: response.data[0].id
          };
        }
      });
  },
  computed: {
    format_date() {
      return this.startDateWork
        ? moment(String(this.startDateWork)).format("DD-MM-YYYY")
        : "";
    },
    format_birthDate() {
      return this.birthdate
        ? moment(String(this.birthdate)).format("DD-MM-YYYY")
        : "";
    },
    format_expireDate() {
      return this.passportExpireDate
        ? moment(String(this.passportExpireDate)).format("DD-MM-YYYY")
        : "";
    }
  },
  watch: {
    countryValue() {
      this.getCitiesByIdCountry(this.countryValue.id);
    },
    companyValue() {
      this.getDepartmentByIdCompany(this.companyValue.id);
    },
    departmentValue() {
      this.getShopsByIdDepartment(this.departmentValue.id);
    }
  },
  methods: {
    onChange(event) {
      this.selectedImage = event.target.files[0];
    },
    save() {
      const pic = new FormData();
      pic.append("photo", this.selectedImage, this.selectedImage.name);
      pic.append("name", this.name);
      pic.append("fatherName", this.fatherName);
      pic.append("surname", this.surname);
      pic.append("birthDate", this.birthdate);
      pic.append("gender", this.gender);
      pic.append("roleType", this.roleType);
      pic.append("passportNumber", this.passportNumber);
      pic.append("passportExpireDate", this.passportExpireDate);
      pic.append("countryValue", this.countryValue);
      pic.append("livingAddress", this.livingAddress);
      pic.append("cityId", this.cityValue.id);
      pic.append("companyValue", this.companyValue);
      pic.append("departmentId", this.departmentValue.id);
      pic.append("family", this.family);
      pic.append("education", this.education);
      pic.append("professionId", this.professionValue.id);
      pic.append("shopId", this.shopValue.id);
      pic.append("startDateWork", this.startDateWork);
      axios
        .post("https://localhost:44370/api/Worker", pic)
        .then(response => {});
    },
    nameWithLang({ name }) {
      return `${name}`;
    },
    getCitiesByIdCountry(countryId) {
      axios
        .get(
          `https://localhost:44370/api/city/getCitiesByIdCountry?id=` +
            countryId
        )
        .then(response => {
          this.cities = response.data;
          if (response.data.length === 0) {
            this.cityValue = { name: "Not item", id: 0 };
            this.cityIsEmpty = true;
            return;
          }
          this.cityIsEmpty = false;
          this.cityValue = { name: this.cities[0].name, id: this.cities[0].id };
          // JSON responses are automatically parsed.
        })
        .catch(e => {
          // this.errors.push(e);
        });
    },
    getDepartmentByIdCompany(companyId) {
      axios
        .get(
          `https://localhost:44370/api/department/getDepartmentByIdCompany?id=` +
            companyId
        )
        .then(response => {
          this.departments = response.data;
          if (response.data.length === 0) {
            this.departmentValue = { name: "Not item", id: 0 };
            this.departmentIsEmpty = true;
            return;
          }
          this.departmentIsEmpty = false;
          this.departamentValue = {
            name: this.departments[0].name,
            id: this.departments[0].id
          };
        })
        .catch(e => {
          // return (e);
        });
    },
    getShopsByIdDepartment(departmentId) {
      axios
        .get(
          `https://localhost:44370/api/shop/getShopsByIdDepartment?id=` +
            departmentId
        )
        .then(response => {
          this.shops = response.data;
          if (response.data.length === 0) {
            this.shopValue = { name: "Not item", id: 0 };
            this.shopIsEmpty = true;
            return;
          }
          this.shopValue = false;
          this.shopValue = { name: this.shops[0].name, id: this.shops[0].id };
        });
    }
  }
};
</script>
<style scoped>
.myImage {
  background-color: #76cba5;
  color: white;
  padding: 10px;
  border: 1px solid #76cba5;
  cursor: pointer;
  width: 100px;
  text-align: center;
  border-radius: 50%;
}
.upload-file {
  display: none;
}
.card {
  margin-right: 5px;
  margin-bottom: 5px;
}

.card:last-child {
  margin-right: 0px;
}

.col-md-2 {
  max-width: 15.666667% !important;
}

label {
  display: block;
  color: #42b983;
}
.worker-add {
  margin-top: 10px;
}
input[type="checkbox"] {
  display: inline-block;
  width: 15px;
}
span {
  line-height: 15px;
}
</style>