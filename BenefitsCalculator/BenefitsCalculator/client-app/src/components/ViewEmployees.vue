<template>
    <table class="table table-striped">
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
                    <button type="button" id="view-emp" class="btn btn-primary" v-on:click="viewEmployee(e.employeeId)">View</button>
                    <button type="button" class="btn btn-primary" v-on:click="showModal = true">Edit Dependents</button>
                </td>
            </tr>
        </tbody>
    </table>
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
        showModal: false
    }
  },
  beforeMount: function(){
      let vm = this
      axios.get('https://localhost:44360/Employee/getemployees')
          .then((response) => {
              vm.employees = response.data
          })
  },
  methods: {
      viewEmployee: function (employee) {
          if (employee != undefined) {

          }
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
.table{
    width: 75%;
    margin-left: auto;
    margin-right: auto;
}
#view-emp {
    margin-right: 1%;
}
</style>
