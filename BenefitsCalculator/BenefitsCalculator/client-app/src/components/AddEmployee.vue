<template>
    <div id="emp-info" class="form-group">
        <label for="firstName">First Name</label>
        <input v-model="firstName" class="form-control" id="firstName" placeholder="First Name">
        <label for="lastName">Last Name</label>
        <input v-model="lastName" class="form-control" id="lastName" placeholder="Last Name">
        <label for="empId">Employee Id</label>
        <input v-model="employeeId" class="form-control" id="empId" placeholder="Employee Id">
        <br />
        <button type="button" class="btn btn-primary" v-on:click="addEmployee"> Add Employee </button>
    </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'AddEmployee',
  props: {
    msg: String
  },
  data: function () {
    return {
        firstName: "",
        lastName: "",
        employeeId: ""
    }
  },
  methods: {
      addEmployee: function () {
        axios.post('https://localhost:5001/Employee/createemployee', {
            firstName: this.firstName,
            lastName: this.lastName,
            employeeId: this.employeeId
        })
             
      
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
