<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
import axios from 'axios';
import Product from '../models/product'

const route = useRoute();
const productId = route.params.id;
const product = ref<Product>({ imageUri: "", name: "", description: "", price: 22 });
onMounted(async () => {
    try {
        const response = await axios.get(`https://localhost:5001/api/product/${productId}?api-version=1.0`);
        product.value = response.data;
    } catch (error) {

    }
});
async function deleteProduct() {
    try {
        const response = await axios.delete(`https://localhost:5001/api/product/${props.product.id}?api-version=1.0`);
        console.log(response);
    } catch (error) {
        console.error('Error deleting product:', error);
    }
}
</script>
<template>
    <div class="container p-4">
        <div class="flex flex-wrap justify-items-start gap-2 w-screen h-screen">
            <img :src="product.imageUri" class="h-1/2 object-scale-down" />
            <div class="flex flex-col px-4">
                <h1 class="text-4xl">{{ product.name }}</h1>
                <p class="h-[200px]">{{ product.description }}</p>
                <h6 class="text-2xl font-semibold">${{ product.price }}</h6>
                <div class="flex justify-between py-12">

                    <router-link :to="{ name: 'editProduct', params: { id: product.id } }" class="bg-blue-600 py-2 px-4 rounded flex items-center gap-2 text-lg text-white">
                        <font-awesome-icon icon="fa-solid fa-pen" />
                        <p>Edit</p>
                    </router-link>
                    <button @click="deleteProduct" class="bg-red-500 px-4 py-2 rounded text-white flex items-center gap-2 text-lg">
                        <font-awesome-icon icon="fa-solid fa-trash" />
                        <p>Delete</p>
                    </button>
                </div>
            </div>
        </div>


    </div>
</template>../models/models