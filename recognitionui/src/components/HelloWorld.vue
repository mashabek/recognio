<template>
  <div class="container mx-auto py-8">
    <header>
      <h3 class="text-black text-4xl">Recognitions</h3>
    </header>
    <div class="flex flex-wrap gap-4">
      <ProductComponent v-for="product in products" class="basis-52 h-68" :product="product"
        @deleted="handleProductDeleted"></ProductComponent>
    </div>
    <Pagination class="mt-4 mx-auto" @page-clicked="pullPaginatedProducts" :has-next-page="true" :total-pages="totalPages"
      :current-page="1" :has-previous-page="false" :page-size="10">
    </Pagination>
  </div>
</template>
<script setup lang="ts">
import { onMounted, ref } from 'vue';
import ProductComponent from '../components/ProductComponent.vue';
import Pagination from './Pagination.vue'
import Product from '../models/product';
import axios from 'axios'
import { useAppStore } from '../stores/AppStore'
const store = useAppStore();

const products = ref<Product[]>([]);
const username = ref('');
const totalPages = ref(0);
onMounted(async () => {
  await pullPaginatedProducts(1);
  username.value = store.getCurrentUser.username;
})
async function pullPaginatedProducts(page: number) {
  try {
    const response = await axios.get(`https://localhost:5001/api/product/GetProductsWithPagination?PageNumber=${page}&api-version=1.2`);
    products.value = response.data.items;
    totalPages.value = response.data.totalPages;
  } catch (error) {
    console.log(error);
  }

}
function handleProductDeleted(productId: number) {
  // Update the productList by filtering out the deleted product
  products.value = products.value.filter(product => product.id !== productId);
}
</script>
<style scoped>
.read-the-docs {
  color: #888;
}

/* .products-container {
  display: flex;
  gap: 10px;
  flex-direction: row;
  flex-wrap: wrap;
}

.product {
  flex: 0 0 160px;
} */
</style>
../models/models