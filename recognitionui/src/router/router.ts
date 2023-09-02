import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import Home from '../components/HelloWorld.vue';
import ProductEdit from '../components/ProductEdit.vue';
import ProductView from '../components/ProductView.vue';
import ProductAdd from '../components/ProductAdd.vue';
import Login from '../components/Login.vue';
import Register from '../components/Register.vue';
import About from '../components/About.vue';
import UserProfile from '../components/UserProfile.vue'
import NewRecognition from '../components/NewRecognition.vue';

const routes: RouteRecordRaw[] = [
  { path: '/', component: Home },
  { path: '/products/:id/edit', component: ProductEdit, name: "editProduct" },
  { path: '/products/:id', component: ProductView, name: "viewProduct" },
  { path: '/add-product', component: ProductAdd, name: "addProduct" },
  { path: '/login', component: Login, name: "login" },
  { path: '/register', component: Register, name: "register" },
  { path: '/about', component: About },
  { path: '/user-profile', component: UserProfile, name:'userProfile' },
  { path: '/recognize', component: NewRecognition, name:'recognize' },

  // Add more routes as needed...
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
