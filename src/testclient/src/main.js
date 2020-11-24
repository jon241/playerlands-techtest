import Vue from 'vue';
// import axios from 'axios';
import App from './App.vue';
import router from './router';
// import store from './store';

// axios.defaults.baseUrl = 'http://localhost:5000/api';

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App),
}).$mount('#app');
