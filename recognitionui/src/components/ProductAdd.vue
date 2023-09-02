<template>
    <div class="container flex h-screen py-10">
        <form @submit.prevent="onSubmit" class="mx-auto w-1/3 shadow-lg border p-16">
            <h1 class="text-xl text-black font-bold mb-4">New Product</h1>
            <div class="flex flex-col">
                <div class="mb-4">
                    <label for="nameInput" class="block text-gray-700 font-bold">Name</label>
                    <input id="nameInput" type="text" class="w-full shadow appearance-none border py-2 px-3"
                        v-model="product.name">
                </div>
                <div class="mb-4">
                    <label for="imageUriInput" class="block text-gray-700 font-bold">Image Uri</label>
                    <input type="text" id="imageUriInput" class="w-full shadow appearance-none border py-2 px-3"
                        v-model="product.imageUri">
                </div>
                <div class="mb-4">
                    <label for="descriptionInput" class="block text-gray-700 font-bold">Description</label>
                    <input type="text" id="descriptionInput" class="w-full shadow appearance-none border py-2 px-3"
                        v-model="product.description">
                </div>
                <div class="mb-4">
                    <label for="priceInput" class="block text-gray-700 font-bold">Price</label>
                    <input type="text" id="priceInput" class="w-full shadow appearance-none border py-2 px-3"
                        v-model="product.price">
                </div>
                <div class="flex justify-between">
                    <button class="bg-blue-600 rounded hover:bg-blue-700 py-2 px-4 text-white" type="submit">Save</button>
                    <button class="bg-gray-600 rounded hover:bg-gray-700 py-2 px-4 text-white" @click="router.back()">Cancel</button>
                </div>
            </div>
        </form>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import axios from 'axios';
import Product from '../models/product';
import router from '../router/router';

const product = ref<Product>({ name: "", price: 0, description: "", imageUri: "" });

async function onSubmit() {
    try {
        const res = await axios.post('https://localhost:5001/api/Product?api-version=1.0', product.value);
        router.back();
    } catch (error) {
        console.log(error);
    }
}

</script>../models/models