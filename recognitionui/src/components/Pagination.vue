<template>
    <ul class="">
        <li class="inline-block mr-1 text-blue-700">
            <button>First</button>
        </li>
        <li v-for="page in totalPages" class="inline-block mr-1">
            <button class="border bg-gray-300 rounded px-2 py-1" @click="onPageClick(page)"> {{ page }}</button>
        </li>
        <li class="inline-block text-blue-700 mr-1">
            <button @click="onPreviousClick">Previous</button>
        </li>
        <li :disabled="hasNextPage" class="inline-block mr-1 text-blue-700">
            <button @click="onNextClick">Next</button>
        </li>
        <li class="inline-block text-blue-700">
            <button>Last</button>
        </li>

    </ul>
</template>
<script setup lang="ts">
const props = defineProps<{
    totalPages: number,
    currentPage: number,
    pageSize: number
    hasPreviousPage: boolean,
    hasNextPage: boolean
}>();

const emits = defineEmits<{
    (e : 'pageClicked', page : number) : void
    (e : 'previousClicked') : void,
    (e : 'nextClicked') : void,
    
}>();
function onPageClick(page : number){
    emits('pageClicked', page);
};
function onPreviousClick() {
    emits('previousClicked');
}
function onNextClick() {
    emits('nextClicked');
}
</script>