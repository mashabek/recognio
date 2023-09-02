
<template>
  <div class="container py-10">
    <form @submit.prevent="onSubmit" class="bg-white w-1/3 mx-auto shadow-md rounded px-8 pt-6 pb-8 mb-4">
      <h1 class="block text-black text-2xl py-2">Products</h1>
      <div class="mb-4">
        <label for="imageUriInput" class="block text-gray-700 text-sm font-bold mb-2">
          Image Uri
        </label>
        <input id="imageUriInput" v-model="product.imageUri" type="text"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
      </div>
      <div class="mb-4">
        <label for="nameInput" class="block text-gray-700 text-sm font-bold mb-2">
          Name
        </label>
        <input id="nameInputnameInput" v-model="product.name" type="text"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
      </div>
      <div class="mb-4">
        <label for="descriptionInput" class="block text-gray-700 text-sm font-bold mb-2">
          Description
        </label>
        <input id="descriptionInput" v-model="product.description" type="text"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
      </div>
      <div class="flex items-center justify-between">
        <button
          class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
          type="submit">
          Save
        </button>
        <button
          class="bg-gray-500 hover:bg-gray-600 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
          type="button" @click="router.back()">
          Cancel
        </button>
      </div>

    </form>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import { useRoute } from 'vue-router'
import Product from "../models/product";
import axios from "axios";
import router from "../router/router";

const product = ref<Product>({ imageUri: "", name: "", description: "", price: 22 });
const route = useRoute();
const productId = route.params.id;

onMounted(async () => {
  try {
    const response = await axios.get(`https://localhost:5001/api/product/${productId}?api-version=1.0`);
    product.value = response.data;
  } catch (error) {
    console.error('Error fetching product:', error);
  }
});

async function onSubmit() {
  try {
    const response = await axios.put(
      `https://localhost:5001/api/product/${productId}?api-version=1.0`,
      product.value
    );
    console.log('Product updated:', response.data);
    router.back();
  } catch (error) {
    console.error('Error updating product:', error);
  }
};
</script>
<style>
.container {
  display: flex;
  flex-direction: column;
}

.label {
  class:
}
</style>../router/router../models/models