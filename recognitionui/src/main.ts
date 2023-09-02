import { createApp } from 'vue'
import './index.css'
import {createPinia} from 'pinia'
import App from './App.vue'
import router from './router/router'
import vSelect from "vue-select"
/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core'
/* import font awesome icon component */
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

/* import specific icons */
import { faEye, faTrash, faPen, faEnvelope, faUser } from '@fortawesome/free-solid-svg-icons'

/* add icons to the library */
library.add(faEye, faTrash, faPen, faEnvelope, faUser);


createApp(App).component('font-awesome-icon', FontAwesomeIcon).component("v-select", vSelect).use(router).use(createPinia()).mount('#app');
