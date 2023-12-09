<template>

    <div class="flex flex-col gap-4 w-full ">

        <todo-card v-for="todoDetails in todos" :todo="todos"/>

    </div>

</template>
<script setup lang="ts">
import TodoCard from "@/modules/todos/components/TodoCard.vue";
import { TodoApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/TodoApiClient";
import { ref } from "vue";
import type { ToDo } from "@/modules/todos/models/ToDo";

// const todoApiClient = new TodoApiClient();
//
// const todos = ref<ToDo[]>([]);
//
// beforeOnMounted(async () => {
//     await loadTodosAsync();
// });
//
// const loadTodosAsync = async () => {
//     const todosResponse = await todoApiClient.todos.getAsync();
//     if (todosResponse.response) {
//         todos.value = todosResponse.response;
//     }
// }

</script>