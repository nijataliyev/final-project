<template>
  <div class="container">
        <div class="table-wrapper">
			<div class="row">
				<div class="col-sm-8"><h2>İşçilər Haqqında<b> Məlumat</b></h2></div>
				<div class="col-sm-4">
					<div class="search-box">
						<i class="material-icons">&#xE8B6;</i>
						<input type="text" class="form-control" v-model="search" placeholder="Search">
					</div>
				</div>
            </div>
        </div>
		<div style="overflow-x:auto;">
			<table class="table table-striped table-hover" style="width:90%;">
			<thead>
				<tr class="myThead">
					<th>
						<span class="custom-checkbox">
							<input type="checkbox" id="selectAll">
							<label for="selectAll"></label>
						</span>
					</th>
                    <th>Sekil</th>
					<th>Ad</th>
					<th>Soyad</th>
					<th>Ata adı</th>
					<th>Kompaniya</th>
					<th>Şöbə</th>
					<th>Vəzifə</th>
					<th>Mağaza</th>
                    <th>Tarix</th>
                    <th>Növ</th>
                    <th>Səbəb</th>
				</tr>
			</thead>
			<tbody class="myTbody">				
				<tr v-for="worker in filteredWorker" :key="worker.id">
					<td>
						<span class="custom-checkbox">
							<input type="checkbox" id="checkbox5" name="options[]" value="1">
							<label for="checkbox5"></label>
						</span>
					</td>
                    <td class="myImg"><img :src="'data:image/gif;base64,'+ worker.picture" alt=""></td>
					<td>{{worker.name}}</td>
                    <td>{{worker.surname}}</td>
                    <td>{{worker.fathername}}</td>
					<td>{{worker.company}}</td>
					<td>{{worker.department}}</td>
					<td>{{worker.profession}}</td>
					<td>{{worker.shop}}</td>
					<td>{{worker.appsentDate}}</td>
				</tr> 
			</tbody>
		</table>
		</div>
		<div class="clearfix">
			<div class="hint-text">Showing <b>5</b> out of <b>25</b> entries</div>
			<ul class="pagination">
				<li class="page-item disabled" ><a href="#">Previous</a></li>
				<li class="page-item" v-for="item of paginationPage" :key="item.id"><a href="#" class="page-link">{{item}}</a></li>
				<li class="page-item"><a href="#" class="page-link">Next</a></li>
			</ul>
		</div>
    </div>
</template>
<script>
import axios from 'axios';
import moment from 'moment';


export default {
  name: "WorkerAppsentHistory",
  data() {
    return {
		workers: [],
		countires:[],
		value: "",
		search:"",
		paginationPage:0
    };
  },
  created(){
      this.getWorkers();
  },
  computed:{
	  filteredWorker(){
			  return this.workers.filter((worker)=>{
				  return worker.name.toLowerCase().includes(this.search.toLowerCase());
			  })
	  }
  },
  methods:{
	  getWorkers(){
		  axios
			.get(`https://localhost:44370/api/Worker`)
			.then(response => {
				// JSON responses are automatically parsed.
				this.workers = response.data;
				this.paginationPage=Math.ceil(response.data.length/5)
			})
	  },
	  format_date(value){
         if (value) {
           return moment(String(value)).format('DD-MM-YYYY')
          }
	  },
	  showWorker(id){
              this.editedSid=id;
    }
  }
};
</script>
<style scoped>
    body {
        color: #566787;
		background: #f5f5f5;
		font-family: 'Varela Round', sans-serif;
		font-size: 13px;
	}
	.myImg img{
		width: 100%;
		border-radius: 20%;
	}
	.myTbody{
		overflow-x: scroll;
		width: 50px;
	}
	   .search-box {
        position: relative;        
        float: right;
    }
    .search-box input {
        height: 34px;
        border-radius: 20px;
        padding-left: 35px;
        border-color: #ddd;
        box-shadow: none;
    }
	.search-box input:focus {
		border-color: #3FBAE4;
	}
    .search-box i {
        color: #a0a5b1;
        position: absolute;
        font-size: 19px;
        top: 8px;
        left: 10px;
    }
	.table-wrapper {
        background: #fff;
        padding: 20px 25px;
        margin: 30px 0;
		border-radius: 3px;
        box-shadow: 0 1px 1px rgba(0,0,0,.05);
    }
	.table-title {        
		padding-bottom: 15px;
		background: #435d7d;
		color: #fff;
		padding: 16px 30px;
		margin: -20px -25px 10px;
		border-radius: 3px 3px 0 0;
    }
    .table-title h2 {
		margin: 5px 0 0;
		font-size: 24px;
	}
	.table-title .btn-group {
		float: right;
	}
	.table-title .btn {
		color: #fff;
		float: right;
		font-size: 13px;
		border: none;
		min-width: 50px;
		border-radius: 2px;
		border: none;
		outline: none !important;
		margin-left: 10px;
	}
	.table-title .btn i {
		float: left;
		font-size: 21px;
		margin-right: 5px;
	}
	.table-title .btn span {
		float: left;
		margin-top: 2px;
	}
    table.table tr th, table.table tr td {
        border-color: #e9e9e9;
		padding: 12px 15px;
		vertical-align: middle;
    }
	table.table tr th:first-child {
		width: 60px;
	}
	table.table tr th:last-child {
		width: 100px;
	}
    table.table-striped tbody tr:nth-of-type(odd) {
    	background-color: #fcfcfc;
	}
	table.table-striped.table-hover tbody tr:hover {
		background: #f5f5f5;
	}
    table.table th i {
        font-size: 13px;
        margin: 0 5px;
        cursor: pointer;
    }	
    table.table td:last-child i {
		opacity: 0.9;
		font-size: 22px;
        margin: 0 5px;
    }
	table.table td a {
		font-weight: bold;
		color: #566787;
		display: inline-block;
		text-decoration: none;
		outline: none !important;
	}
	table.table td a:hover {
		color: #2196F3;
	}
	table.table td a.edit {
        color: #FFC107;
    }
    table.table td a.delete {
        color: #F44336;
    }
    table.table td i {
        font-size: 19px;
    }
	table.table .avatar {
		border-radius: 50%;
		vertical-align: middle;
		margin-right: 10px;
	}
    .pagination {
        float: right;
        margin: 0 0 5px;
    }
    .pagination li a {
        border: none;
        font-size: 13px;
        min-width: 30px;
        min-height: 30px;
        color: #999;
        margin: 0 2px;
        line-height: 30px;
        border-radius: 2px !important;
        text-align: center;
        padding: 0 6px;
    }
    .pagination li a:hover {
        color: #666;
    }	
    .pagination li.active a, .pagination li.active a.page-link {
        background: #03A9F4;
    }
    .pagination li.active a:hover {        
        background: #0397d6;
    }
	.pagination li.disabled i {
        color: #ccc;
    }
    .pagination li i {
        font-size: 16px;
        padding-top: 6px
    }
    .hint-text {
        float: left;
        margin-top: 10px;
        font-size: 13px;
    }    
	/* Custom checkbox */
	.custom-checkbox {
		position: relative;
	}
	.custom-checkbox input[type="checkbox"] {    
		opacity: 0;
		position: absolute;
		margin: 5px 0 0 3px;
		z-index: 9;
	}
	.custom-checkbox label:before{
		width: 18px;
		height: 18px;
	}
	.custom-checkbox label:before {
		content: '';
		margin-right: 10px;
		display: inline-block;
		vertical-align: text-top;
		background: white;
		border: 1px solid #bbb;
		border-radius: 2px;
		box-sizing: border-box;
		z-index: 2;
	}
	.custom-checkbox input[type="checkbox"]:checked + label:after {
		content: '';
		position: absolute;
		left: 6px;
		top: 3px;
		width: 6px;
		height: 11px;
		border: solid #000;
		border-width: 0 3px 3px 0;
		transform: inherit;
		z-index: 3;
		transform: rotateZ(45deg);
	}
	.custom-checkbox input[type="checkbox"]:checked + label:before {
		border-color: #03A9F4;
		background: #03A9F4;
	}
	.custom-checkbox input[type="checkbox"]:checked + label:after {
		border-color: #fff;
	}
	.custom-checkbox input[type="checkbox"]:disabled + label:before {
		color: #b8b8b8;
		cursor: auto;
		box-shadow: none;
		background: #ddd;
	}
	/* Modal styles */
	.modal .modal-dialog {
		max-width: 400px;
	}
	.modal .modal-header, .modal .modal-body, .modal .modal-footer {
		padding: 20px 30px;
	}
	.modal .modal-content {
		border-radius: 3px;
	}
	.modal .modal-footer {
		background: #ecf0f1;
		border-radius: 0 0 3px 3px;
	}
    .modal .modal-title {
        display: inline-block;
    }
	.modal .form-control {
		border-radius: 2px;
		box-shadow: none;
		border-color: #dddddd;
	}
	.modal textarea.form-control {
		resize: vertical;
	}
	.modal .btn {
		border-radius: 2px;
		min-width: 100px;
	}	
	.modal form label {
		font-weight: normal;
	}	
    .companyModel{
        display: inline-block;
    }
	.myThead{
		background-color:#1D2939 ;
	}
	.myThead th{
		color: white;
	}
</style>