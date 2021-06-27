<template>
    <p> View Employees </p>
</template>

<script>
import axios from 'axios';

export default {
  name: 'ViewEmployees',
  props: {
    msg: String
  },
  mounted: function(){
      axios.get('https://localhost:44360/Employee/getemployees')
          .then((response) => {
              alert(JSON.stringify(response.data))
          })
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
</style>
