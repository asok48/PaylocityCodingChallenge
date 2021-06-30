<template>
    <div id="emp-filter" class="form-group shadow p-3 mb-5 bg-white rounded">
        <input v-model="filter.firstName" class="form-control filter-input" placeholder="First Name" />
        <input v-model="filter.lastName" class="form-control filter-input" placeholder="Last Name" />
        <input v-model="filter.id" class="form-control filter-input" placeholder="Employee Id" />
        <button type="button" class="btn btn-primary filter-btn" v-on:click="filterEmployees"> Apply Filters </button>
        <button type="button" class="btn btn-primary filter-btn" v-on:click="clearFilters"> Clear Filters </button>
    </div>
    <table id="table_yo" class="table table-striped shadow p-3 mb-5 bg-white rounded">
        <thead>
            <tr>
                <th scope="col">Employee Id</th>
                <th scope="col">First</th>
                <th scope="col">Last</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="e in employees">
                <td scope="row">{{ e.employeeId }}</td>
                <td>{{ e.firstName }}</td>
                <td>{{ e.lastName }}</td>
                <td>
                    <button type="button" id="view-emp" class="btn btn-primary" v-on:click="viewEmployee(e, 'view')">View</button>
                    <button type="button" id="view-emp" class="btn btn-primary" v-on:click="viewEmployee(e, 'edit')">Edit Employee</button>
                    <button type="button" id="view-emp" class="btn btn-danger" v-on:click="deleteEmployee(e)">Delete</button>
                </td>
            </tr>
        </tbody>
    </table>
    <div v-if="viewingEmployee">
        <h1> Viewing {{ currentEmployee.employee.firstName }} {{ currentEmployee.employee.lastName }} ({{currentEmployee.employee.employeeId}})</h1>
        <table id="view-display" class="table table-striped shadow p-3 mb-5 bg-white rounded">
            <thead>
                <tr>
                    <th scope="col">Employee Id</th>
                    <th scope="col">First</th>
                    <th scope="col">Last</th>
                    <th scope="col">Benefits Cost</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td scope="row">{{ currentEmployee.employee.employeeId }}</td>
                    <td>{{ currentEmployee.employee.firstName }}</td>
                    <td>{{ currentEmployee.employee.lastName }}</td>
                    <td>${{ currentEmployee.employee.cost }}</td>
                </tr>
            </tbody>
        </table>
        <p v-if="currentEmployee.dependents.length > 0"> Dependents </p>
        <table id="view-display" class="table table-striped shadow p-3 mb-5 bg-white rounded" v-if="currentEmployee.dependents.length > 0">
            <thead>
                <tr>
                    <th scope="col">First</th>
                    <th scope="col">Last</th>
                    <th scope="col">Benefits Cost</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="d in currentEmployee.dependents">
                    <td scope="row">{{ d.firstName }}</td>
                    <td>{{ d.lastName }}</td>
                    <td>${{ d.cost }}</td>
                </tr>
            </tbody>
        </table>
        <table id="view-display" class="table table-striped shadow p-3 mb-5 bg-white rounded">
            <thead>
                <tr>
                    <th scope="col">Total Yearly Cost</th>
                    <th scope="col">Total Monthly Cost</th>
                    <th scope="col">Yearly Salary After Deductions:</th>
                    <th scope="col">Pay Period Salary After Deductions</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td scope="row">${{ totalCost.toFixed(2) }}</td>
                    <td>${{ (totalCost / 12).toFixed(2) }}</td>
                    <td>${{ (52000 - totalCost).toFixed(2) }}</td>
                    <td>${{ (2000 - (totalCost / 26)).toFixed(2) }}</td>
                </tr>
            </tbody>
        </table>
    </div>
    <div v-if="editing">
        <h1> Editing {{ currentEmployee.employee.firstName }} {{ currentEmployee.employee.lastName }} ({{currentEmployee.employee.employeeId}})</h1>
        <table id="view-display" class="table table-striped shadow p-3 mb-5 bg-white rounded">
            <thead>
                <tr>
                    <th scope="col">Employee Id</th>
                    <th scope="col">First</th>
                    <th scope="col">Last</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td scope="row">
                        <input v-model="currentEmployee.employee.employeeId" class="form-control" placeholder="Employee Id" />
                    </td>
                    <td>
                        <input v-model="currentEmployee.employee.firstName" class="form-control" placeholder="First Name" />
                    </td>
                    <td>
                        <input v-model="currentEmployee.employee.lastName" class="form-control" placeholder="Last Name" />
                    </td>
                    <td>
                        <button type="button" id="view-emp" class="btn btn-primary" v-on:click="viewEmployee(e, 'view')">Save</button>
                        <button type="button" id="view-emp" class="btn btn-danger" v-on:click="viewEmployee(e, 'view')">Delete</button>
                    </td>
                </tr>
            </tbody>
        </table>
        <p> Dependents </p>
        <table id="view-display" class="table table-striped shadow p-3 mb-5 bg-white rounded">
            <thead>
                <tr>
                    <th scope="col">First Name</th>
                    <th scope="col">Last Name</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="d in currentEmployee.dependents">
                    <td scope="row">
                        <input v-model="d.firstName" class="form-control" placeholder="First Name" />
                    </td>
                    <td>
                        <input v-model="d.lastName" class="form-control" placeholder="Last Name" />
                    </td>
                    <td>
                        <button type="button" id="view-emp" class="btn btn-primary" v-on:click="addDependent(d)">Save</button>
                        <button type="button" id="view-emp" class="btn btn-danger" v-on:click="deleteDependent(d)">Delete</button>
                    </td>
                </tr>
                <tr>
                    <td scope="row">
                        <input v-model="newDependent.firstName" class="form-control" placeholder="First Name" />
                    </td>
                    <td>
                        <input v-model="newDependent.lastName" class="form-control" placeholder="Last Name" />
                    </td>
                    <td>
                        <button type="button" id="view-emp" class="btn btn-primary" v-on:click="addDependent(d)">Add</button>
                    </td>
                </tr>
            </tbody>
        </table>
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
                },
                newDependent: {
                    employeeId: null,
                    firstName: null,
                    lastName: null,
                },
                totalCost: null,
                viewingEmployee: false,
                editing: false
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
                    vm.currentEmployee.employee = null
                    vm.currentEmployee.dependents = null
                    vm.viewingEmployee = false
                    vm.totalCost = null
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
            viewEmployee: function (employee, type) {
                this.currentEmployee.employee = employee
                let vm = this
                axios.get('https://localhost:44360/Dependent/getdependents', {
                    params: {
                        employeeId: employee.employeeId
                    }
                })
                .then((response) => {
                    vm.currentEmployee.dependents = response.data
                    if (response.data.length == 0) {
                        this.totalCost = vm.currentEmployee.employee.cost
                    } else {
                        var val = this.currentEmployee.dependents.reduce(function (previousValue, currentValue) {
                            return {
                                cost: previousValue.cost + currentValue.cost,
                            }
                        });
                        this.totalCost = val.cost + this.currentEmployee.employee.cost
                    }
                    if (type == 'view') {
                        this.viewingEmployee = true
                        this.editing = false
                    } else if (type == 'edit') {
                        this.editing = true
                        this.viewingEmployee = false
                    }
                })
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
            },
            addDependent: function () {
                let vm = this
                axios.post('https://localhost:44360/Dependent/adddependent', {
                    firstName: this.newDependent.firstName,
                    lastName: this.newDependent.lastName,
                    employeeId: this.currentEmployee.employee.employeeId
                }).then((response) => {
                    alert("Dependent Added!")
                    vm.newDependent.firstName = ""
                    vm.newDependent.lastName = ""
                    vm.currentEmployee.dependents.push(response.data)
                })
                    .catch((error) => {
                        alert("Error adding dependent.")
                    })
            },
            deleteDependent: function (dependent) {
                let vm = this
                let dep = dependent
                axios.post('https://localhost:44360/Dependent/deletedependent', {
                    employeeId: this.currentEmployee.employee.employeeId,
                    id: dependent.id
                }).then((response) => {
                    alert("Dependent Deleted!")
                    vm.currentEmployee.dependents = vm.currentEmployee.dependents.filter(function (d) { return d.id != dep.id });
                })
                    .catch((error) => {
                        alert("Error deleting dependent.")
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
    #view-display tbody tr td {
        width: 25%;
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
    .viewing {
        display: inline-block;
    }

    .viewing input {
        float: left;
        width: 20%;
        margin-right: 1%;
        margin-left: 1%;
    }

    #view-emp {
        margin-right: 1%;
        margin-left: 1%;
    }
</style>
