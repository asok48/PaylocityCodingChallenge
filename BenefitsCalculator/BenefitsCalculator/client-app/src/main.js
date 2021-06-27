import { createApp } from 'vue'
import App from './App.vue'
import $ from 'jquery'
import dt from 'datatables.net';

import 'bootstrap/dist/css/bootstrap.css'

import 'datatables.net-dt'

// Make BootstrapVue available throughout your project
//Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
//Vue.use(IconsPlugin)

const app = createApp(App)
app.mount('#app')
