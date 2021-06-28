<template>
    <div id="emp-filter" class="form-group">
        <input v-model="filter.firstName" class="form-control filter-input" placeholder="First Name" />
        <input v-model="filter.lastName" class="form-control filter-input" placeholder="Last Name" />
        <input v-model="filter.id" class="form-control filter-input" placeholder="Employee Id" />
        <button type="button" class="btn btn-primary filter-btn" v-on:click="filterEmployees"> Apply Filters </button>
        <button type="button" class="btn btn-primary filter-btn" v-on:click="clearFilters"> Clear Filters </button>
    </div>
    <table id="table_yo" class="table table-striped">
        <thead>
            <tr>
                <th scope="col">Employee Id</th>
                <th scope="col">First</th>
                <th scope="col">Last</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="e in employees">
                <td scope="row">{{ e.employeeId }}</td>
                <td>{{ e.firstName }}</td>
                <td>{{ e.lastName }}</td>
                <td>
                    <button type="button" id="view-emp" class="btn btn-primary" v-on:click="viewEmployee(e)">View</button>
                    <button type="button" id="view-emp" class="btn btn-primary" v-on:click="viewEmployee(e)">Edit Dependents</button>
                    <button type="button" id="view-emp" class="btn btn-danger" v-on:click="deleteEmployee(e)">Delete</button>
                </td>
            </tr>
        </tbody>
    </table>
    <div id="emp-view" class="form-group" v-if="currentEmployee.employee != null">
        <input v-model="filter.firstName" class="form-control filter-input" placeholder="First Name" disabled/>
        <input v-model="filter.lastName" class="form-control filter-input" placeholder="Last Name" disabled/>
        <input v-model="filter.id" v-data="currentEmployee.id" class="form-control filter-input" placeholder="Employee Id" disabled/>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {

        name: 'ViewEmployees',
        props: {
            msg: String,
        },
        data: function () {
            return {
                employees: [],
                showModal: true,
                filter: {
                    id: '',
                    firstName: '',
                    lastName: ''
                },
                currentEmployee: {
                    employee: null,
                    dependents: null
                }
            }
        },
        beforeMount: function () {
            //this.getEmployees()
        },
        methods: {
            filterEmployees: function () {
            let vm = this
                axios.get('https://localhost:44360/Employee/filteremployees', {
                    params: {
                        firstName: this.filter.firstName,
                        lastName: this.filter.lastName,
                        id: this.filter.id
                    }
                })
                .then((response) => {
                    vm.employees = response.data
                })
            },
            getEmployees: function () {
                let vm = this
                axios.get('https://localhost:44360/Employee/getemployees')
                    .then((response) => {
                        vm.employees = response.data
                    })
            },
            clearFilters: function () {
                this.filter.id = ''
                this.filter.firstName = ''
                this.filter.lastName = ''
                this.getEmployees();
            },
            viewEmployee: function (employee) {
                this.currentEmployee.employee = employee
            },
            deleteEmployee: function (employee) {
                let vm = this
                //Add confirmation
                axios.post('https://localhost:44360/Employee/deleteemployee', {
                    firstName: employee.firstName,
                    lastName: employee.lastName,
                    employeeId: employee.employeeId
                }).then((response) => {
                    alert("Employee Deleted!")
                    vm.filterEmployees()
                })
                .catch((error) => {
                    alert("Error deleting employee")
                })
            }
        }


    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }

    .filter-input {
        float: left;
        width: 20%;
        margin-right: 1%;
        margin-left: 1%;
    }

    .filter-btn {
        margin-right: 1%;
        margin-left: 1%;
    }

    .table {
        width: 90%;
        margin-left: auto;
        margin-right: auto;
    }

    #view-emp {
        margin-right: 1%;
        margin-left: 1%;
    }
</style>
