<template>

    <div class="h-20 flex gap-x-4 w-full border border-gray-500 rounded-xl p-4">

        <!-- Primary Actions -->
        <div class="flex items-center">

            <button class="h-8 w-8 group border theme-border flex justify-center items-center rounded-full"
                    @click="toggleIsDone">
                <i class="simple-hover fa-solid fa-check theme-icon"
                   :class="{ 'text-successColor opacity-100': todo.isDone, 'text-failedColor': !todo.isDone && (todo.dueDateTime < Date.now()), }"></i>
            </button>

        </div>

        <!-- Details -->
        <div class="flex-grow">

            <!-- TODO : truncate -->
            <h5 class="font-bold line-clamp-1">Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title Title</h5>
            <div class="flex gap-2 text-sm">

                <p class="opacity-80">Sun, Dec 10</p>
                <span class="opacity-50">•</span>
                <p class="opacity-40">Sun, Dec 10</p>

            </div>

        </div>

        <!-- Secondary Actions -->
        <div class="flex items-center">

            <!-- TODO: change star stroke -->
            <button class="text-2xl font-light flex justify-center items-center rounded-full"
                    @click="toggleIsFavorite">
                <i class="fa-star theme-icon"
                   :class="{ 'fa-solid': todo.isFavorite, 'fa-regular': !todo.isFavorite }"></i>
            </button>

        </div>

    </div>

</template>

<script setup lang="ts">

import { ref } from "vue";
import { ToDo } from "@/modules/todos/models/ToDo";

const props = defineProps({
    todo: {
        type: Object as () => ToDo,
        required: true
    }
});

// const todo = ref<ToDo>({
//     id: 1,
//     title: 'Title',
//     description: 'Description',
//     isDone: false,
//     isFavorite: false,
//     dueDateTime: new Date('2024-10-10'),
//     reminderTime: Date.now()
// });

// const isDone = ref<boolean>(false);

const toggleIsDone = () => {
    todo.value.isDone = !todo.value.isDone;
}

const toggleIsFavorite = () => {
    todo.value.isFavorite = !todo.value.isFavorite;
}

</script>