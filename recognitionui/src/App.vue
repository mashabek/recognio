<script setup lang="ts">
import { useAppStore } from './stores/AppStore'
const store = useAppStore();
</script>
<template>
  <div class="flex flex-col">
    <nav class="bg-white border-gray-200 dark:bg-gray-900">
      <div class="w-full h-full mx-auto">
        <ul class="flex p-4 gap-4 justify-end">
          <li class="block text-white text-medium grow">
            <router-link :to="{ path: '/' }">Home</router-link>
          </li>
          <li class="block flex items-center gap-2 text-white text-medium" v-if="store.getCurrentUser">
           <font-awesome-icon icon="fa-solid fa-user" />
            <router-link :to="{ name: 'userProfile' }"> {{ store.getCurrentUser.username }}</router-link>
          </li>
          <!-- <li class="block text-white text-medium">
            <router-link :to="{ path: '/add-product' }">New Product</router-link>
          </li> -->
          <li class="block text-white text-medium">
            <router-link :to="{ path: '/about' }">About</router-link>
          </li>
        </ul>
      </div>
    </nav>
    <router-view>


    </router-view>
  </div>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}

.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}

.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>