<template>

    <div class="flex gap-6 md:gap-12 overflow-x-scroll no-scrollbar">

        <location-category-card v-for="location in locationCategories" :locationCategory="location"/>

    </div>

</template>

<script setup lang="ts">
import LocationCategoryCard from "@/modules/locations/components/LocationCategoryCard.vue";
import { onBeforeMount, ref } from "vue";
import { AirBnbApiClient } from "@/infrastructures/apiClients/airBnbApiClient/brokers/AirBnbApiClient";
import type { LocationCategory } from "@/modules/locations/models/LocationCategory";

const airBnbApiClient = new AirBnbApiClient();

const locationCategories = ref<LocationCategory[]>([]);

onBeforeMount(async() => {
    const locationsResponse = await airBnbApiClient.locationCategories.getAsync();
    locationCategories.value = locationsResponse.response!;

    console.log('test', locationCategories.value);
});

</script>