<template>
    <div class="container h-screen py-10 flex items-center">
        <div class="shadow-lg w-1/3 border rounded p-16">
            <h1 class="text-black font-bold text-3xl mb-4">Login</h1>
            <div class="mb-4">
                <input id="usernameInput" type="text" placeholder="Username" v-model="username"
                    class="shadow appearance-none border rounded w-full py-3 px-3 text-gray-700 focus:outline-none focus:shadow-outline leading-tight" />
            </div>
            <div class="mb-4">
                <input placeholder="Password"
                    class="shadow appearance-none border rounded w-full py-3 px-3 text-gray-700 focus:outline-none focus:shadow-outline leading-tight"
                    type="password" v-model="password" />
            </div>
            <button @click="login()" class="bg-blue-600 w-full rounded hover:bg-blue-700 py-3 px-4 text-white mb-4">Login</button>
            <div class="mx-auto w-auto text-center">
                <p  class="inline-block mr-2">Not a member?</p>
                <router-link :to="{ name: 'register'}" class="text-blue-600">Register</router-link>
            </div>
        </div>

    </div>
</template>
<script setup lang="ts">
import {ref} from 'vue';
import axios from 'axios';
import { useAppStore } from '../stores/AppStore'
import router from '../router/router';
const store = useAppStore();
const username = ref('');
const password = ref('');

async function login() {
    let response = await axios.post("https://localhost:5001/login", {'username': username.value, 'password':password.value});
    store.setCurrentUser({'access_token' :  response.data.access_token, 'username' : username.value});
    router.push({ path: '/' });
}

</script>