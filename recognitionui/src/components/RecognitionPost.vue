<template>
    <img :src="recognition?.imageUri"/>
    <h1>{{ recognition?.header }}</h1>
    <p>{{ recognition?.recognizedName}} is recognized by {{ recognition?.recognizedByName }}</p>
</template>

<script setup lang="ts">
import {ref} from 'vue'
import {Recognition} from '../models/models'
export const recognition = ref<Recognition>();
</script>