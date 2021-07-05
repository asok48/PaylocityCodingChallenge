<template>
    <div id="emp-filter" class="form-group shadow p-3 mb-5 bg-white rounded">
        <input v-model="filter.firstName" class="filter-input" placeholder="First Name" />
        <input v-model="filter.lastName" class="filter-input" placeholder="Last Name" />
        <input v-model="filter.id" class="filter-input" placeholder="Employee ID" />
        <button type="button" class="btn btn-primary filter-btn" v-on:click="filterEmployees"> Apply Filters </button>
        <button type="button" class="btn btn-primary filter-btn" v-on:click="clearFilters"> Clear Filters </button>
    </div>
    <table id="table_yo" class="table table-striped shadow p-3 mb-5 bg-white rounded">
        <thead>
            <tr>
                <th scope="col">Employee ID</th>
                <th scope="col">First</th>
                <th scope="col">Last</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="e in employees" v-bind:key="e.employeeId">
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
                    <th scope="col">Employee ID</th>
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
                <tr v-for="d in currentEmployee.dependents" v-bind:key="d.id">
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
                    <th scope="col">Employee ID</th>
                    <th scope="col">First</th>
                    <th scope="col">Last</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td scope="row">
                        <input v-model="currentEmployee.employee.employeeId" class="form-control" placeholder="Employee ID" disabled/>
                    </td>
                    <td>
                        <input v-model="employeeEdit.firstName" class="form-control" placeholder="First Name" />
                    </td>
                    <td>
                        <input v-model="employeeEdit.lastName" class="form-control" placeholder="Last Name" />
                    </td>
                    <td>
                        <button type="button" id="view-emp" class="btn btn-primary" v-on:click="editEmployee()">Save</button>
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
                <tr v-for="d in currentEmployee.dependents" v-bind:key="d.id">
                    <td scope="row">
                        <input v-model="d.firstName" class="form-control" placeholder="First Name" />
                    </td>
                    <td>
                        <input v-model="d.lastName" class="form-control" placeholder="Last Name" />
                    </td>
                    <td>
                        <button type="button" id="view-emp" class="btn btn-primary" v-on:click="editDependent(d)">Save</button>
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
    import * as functions from '../js/functions.js'
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
                employeeEdit: {
                    firstName: null,
                    lastName: null
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
                functions.filterEmployees(this.filter.firstName, this.filter.lastName, this.filter.id)
                    .then((res) => {
                        vm.employees = res.data
                        vm.currentEmployee.employee = null
                        vm.currentEmployee.dependents = null
                        vm.employeeEdit.firstName = null
                        vm.employeeEdit.lastName = null
                        vm.viewingEmployee = false
                        vm.editing = false
                        vm.totalCost = null
                    })
            },
            clearFilters: function () {
                this.filter.id = ''
                this.filter.firstName = ''
                this.filter.lastName = ''
                this.filterEmployees()
            },
            viewEmployee: function (employee, type) {
                this.currentEmployee.employee = employee
                this.employeeEdit.firstName = this.currentEmployee.employee.firstName
                this.employeeEdit.lastName = this.currentEmployee.employee.lastName

                let vm = this
                functions.getDependents(employee)
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
                //Add confirmation
                if (confirm("Are you sure you would like to delete this employee?")) {
                    let vm = this
                    functions.deleteEmployee(employee)
                        .then(() => {
                            alert("Employee Deleted!")
                            vm.filterEmployees()
                        })
                        .catch(() => {
                            alert("Error deleting employee")
                        })
                }
            },
            addDependent: function () {
                let vm = this
                functions.addDependent(this.newDependent.firstName, this.newDependent.lastName, this.currentEmployee.employee.employeeId)
                .then((response) => {
                    alert("Dependent Added!")
                    vm.newDependent.firstName = ""
                    vm.newDependent.lastName = ""
                    vm.currentEmployee.dependents.push(response.data)
                })
                .catch(() => {
                    alert("Error adding dependent.")
                })
            },
            deleteDependent: function (dependent) {
                if (confirm('Are you sure you would like to delete this dependent?')) {
                    let vm = this
                    functions.deleteDependent(this.currentEmployee.employee.employeeId, dependent.id)
                        .then(() => {
                            alert("Dependent Deleted!")
                            vm.currentEmployee.dependents = vm.currentEmployee.dependents.filter(function (d) { return d.id != dependent.id });
                        })
                        .catch((error) => {
                            alert("Error deleting dependent.")
                        })
                }
            },
            editDependent: function (dependent) {
                let vm = this
                functions.editDependent(dependent.firstName, dependent.lastName, dependent.id)
                    .then(() => {
                        functions.getDependents(this.currentEmployee.employee)
                            .then((response) => {
                                vm.currentEmployee.dependents = response.data
                                alert("Dependent Updated!")
                            })
                        
                    })
                    .catch(() => {
                        alert("Error updating dependent.")
                    })
            },
            editEmployee: function () {
                let vm = this
                functions.editEmployee(this.employeeEdit.firstName, this.employeeEdit.lastName, this.currentEmployee.employee.employeeId)
                    .then(() => {
                        functions.getEmployee(vm.currentEmployee.employee.employeeId)
                            .then((response) => {
                                vm.currentEmployee.employee = response.data
                                vm.employees = vm.employees.filter(function (e) { return e.employeeId != vm.currentEmployee.employee.employeeId });
                                vm.employees.push(vm.currentEmployee.employee)
                                alert("Employee Updated!")
                            })

                    })
                    .catch(() => {
                        alert("Error updating employee.")
                    })
            }
        }
    }
</script>
