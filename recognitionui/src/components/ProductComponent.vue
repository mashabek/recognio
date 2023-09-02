<template>
  <div class="p-3 flex flex-col gap-2 justify-between shadow-xl border rounded-xl">
    <div class="cursor-pointer flex flex-col gap-4" @click="viewProduct">
      <img :src="product.imageUri" class="aspect-square w-full h-full mx-auto object-scale-down" />
      <router-link class="line-clamp-2 basis-16 text-center font-medium text-blue-600 dark:text-blue-500 hover:underline" :to="{ name: 'viewProduct', params: { id: product.id } }"> {{product.name}}</router-link>
    </div>
    <p class="text-2xl text-red-700 text-center">${{ product.price }}</p>
    <div class="flex gap-4 justify-between">
      <router-link :to="{ name: 'editProduct', params: { id: product.id } }"> <font-awesome-icon
          icon="fa-solid fa-pen" /></router-link>
      <button @click="deleteProduct"> <font-awesome-icon icon="fa-solid fa-trash" class="text-red-500" /></button>
    </div>
  </div>
</template>
    
<script setup lang="ts">
import axios from "axios";
import Product from "../models/product";
import router from "../router/router";

const emits = defineEmits<{
  deleted: [id: number] // named tuple syntax
}>()
const props = defineProps({
  product: { type: Object as () => Product, required: true },
});
async function deleteProduct() {
  try {
    const response = await axios.delete(`https://localhost:5001/api/product/${props.product.id}?api-version=1.0`);
    emits('deleted', props.product.id);
    console.log(response);
  } catch (error) {
    console.error('Error deleting product:', error);
  }
}
function viewProduct() {
  router.push({ name: 'viewProduct', params: { id: props.product.id } })
}

</script>

<style>
.img {
  object-fit: scale-down;
}
</style>../router/router../models/models