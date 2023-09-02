<template>
    <div class="container h-screen">
        <div class="flex flex-col shadow-lg border rounded p-16 gap-4">
            <h1 class="text-3xl text-bold">Register</h1>
            <input placeholder="Email" type="text" class="shadow appearance-none border text-gray-700 p-4 focus:outline-none focus:shadow-outline" v-model="email"/>
            <input placeholder="Username" type="text" class="shadow appearance-none border text-gray-700 p-4 focus:outline-none focus:shadow-outline" v-model="username"/>
            <input placeholder="Password" type="password" class="shadow appearance-none border text-gray-700 p-4 focus:outline-none focus:shadow-outline" v-model="password"/>
            <button class="shadow rounded text-white w-full bg-blue-600 px-4 py-3" @click="register()">Register</button>
        </div>
    </div>
</template>

<script setup lang="ts">
import axios from 'axios';
import {ref} from 'vue'

const email = ref('');
const username = ref('');
const password = ref('');

async function register() {
    
    await axios.post("https://localhost:5001/register", {"email" : email.value, "username":username.value, "password": password.value});
}
</script>