<template>
    <div>
        <h1>Recognize user</h1>
        <div class="flex gap-2">
            <v-select class="w-1/3" :options="userSearchResult" label="name" @input="searchUsers"></v-select>

            <!-- <ul class="flex">
                <li v-for="user in userSearchResult">
                    {{ user.name }}
                </li>
            </ul> -->
        </div>

    </div>
</template>

<script setup lang="ts">
import axios from 'axios';
import { ref } from 'vue'
const nameSearchQuery = ref('');
const userSearchResult = ref([]);
async function searchUsers() {
    console.log("BLBLAABLABL");
    let response = await axios.get(`https://localhost:5001/users/searchUser?name=${nameSearchQuery.value}`);
    userSearchResult.value = response.data.items;
}
</script>
<style>
@import "vue-select/dist/vue-select.css";

datalist{
    background-color: red;
}

</style>