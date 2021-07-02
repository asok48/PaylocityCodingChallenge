<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="#">Paylocity Benefits Calculator</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="#" @click="component = 'ViewEmployees'">View Employees</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#" @click="component = 'AddEmployee'">Add Employee</a>
                </li>
            </ul>
        </div>
    </nav>
    <component v-bind:is="component" />

</template>

<style>
    @import './assets/styling.css';
</style>

<script>
import ViewEmployees from './components/ViewEmployees.vue'
import AddEmployee from './components/AddEmployee'

export default {
  name: 'App',
  components: {
      ViewEmployees,
      AddEmployee
  },
    data (){
    return {
      component:"ViewEmployees"
    }
  },
}
</script>
