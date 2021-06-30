<template>
    <div id="emp-info" class="form-group" v-if="showDependents == false">
        <label for="firstName">First Name</label>
        <input v-model="firstName" class="form-control" id="firstName" placeholder="First Name">
        <label for="lastName">Last Name</label>
        <input v-model="lastName" class="form-control" id="lastName" placeholder="Last Name">
        <label for="empId">Employee Id</label>
        <input v-model="employeeId" class="form-control" id="empId" placeholder="Employee Id">
        <br />
        <button type="button" class="btn btn-primary" v-on:click="addEmployee"> Add Employee </button>
    </div>

    <div v-if="showDependents == true">
        <h3> Add {{ firstName }} {{ lastName }}'s Dependents: </h3>
        <table id="view-display" class="table table-striped shadow p-3 mb-5 bg-white rounded">
            <thead>
                <tr>
                    <th scope="col">First Name</th>
                    <th scope="col">Last Name</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="d in dependents">
                    <td scope="row">
                        <input v-model="d.firstName" class="form-control" placeholder="First Name" />
                    </td>
                    <td>
                        <input v-model="d.lastName" class="form-control" placeholder="Last Name" />
                    </td>
                    <td>
                        <button type="button" id="view-emp" class="btn btn-danger" v-on:click="deleteDependent(d)">Delete</button>
                    </td>
                </tr>
                <tr>
                    <td scope="row">
                        <input v-model="firstNameD" class="form-control" placeholder="First Name" />
                    </td>
                    <td>
                        <input v-model="lastNameD" class="form-control" placeholder="Last Name" />
                    </td>
                    <td>
                        <button type="button" id="view-emp" class="btn btn-primary" v-on:click="addDependent">Add</button>
                    </td>
                </tr>
            </tbody>
        </table>
        <button type="button" id="view-emp" class="btn btn-primary" v-on:click="complete">Complete</button>
    </div>
</template>

<script>
import axios from 'axios';
import VModal from 'vue-js-modal'

export default {
  name: 'AddEmployee',
  props: {
    msg: String
  },
  data: function () {
    return {
        firstName: "",
        lastName: "",
        employeeId: "",

        showDependents: false,
        dependents: [],
        firstNameD: "",
        lastNameD: ""
    }
  },
  methods: {
      addEmployee: function () {
          let vm = this
          axios.post('https://localhost:44360/Employee/createemployee', {
            firstName: this.firstName,
            lastName: this.lastName,
            employeeId: this.employeeId
          }).then((response) => {
              alert("Employee Added!")
              vm.showDependents = true
          })
          .catch((error) => {
              alert("Error adding employee. Ensure that the employee Id is not already in use.")
          })
    },
    addDependent: function() {
        let vm = this
        axios.post('https://localhost:44360/Dependent/adddependent', {
            firstName: this.firstNameD,
            lastName: this.lastNameD,
            employeeId: this.employeeId
          }).then((response) => {
              alert("Dependent Added!")
              vm.firstNameD = ""
              vm.lastNameD = ""
              vm.dependents.push(response.data)
          })
          .catch((error) => {
              alert("Error adding dependent.")
          })
    },
    deleteDependent: function(dependent) {
        let vm = this
        let dep = dependent
        axios.post('https://localhost:44360/Dependent/deletedependent', {
            employeeId: this.employeeId,
            id: dependent.id
        }).then((response) => {
            alert("Dependent Deleted!")
            vm.dependents = vm.dependents.filter(function (d) { return d.id != dep.id });
        })
        .catch((error) => {
            alert("Error deleting dependent.")
        })
    },
    complete: function() {
        this.firstName = ""
        this.lastName = ""
        this.employeeId = ""
        this.showDependents = false
        this.dependents = []
        this.firstNameD = ""
        this.lastNameD = ""
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    h3 {
        margin: 40px 0 0;
        margin-right: auto;
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

    #emp-info {
        width: 25%;
        margin-left: auto;
        margin-right: auto;
    }
</style>
