<template>

    <div class="h-20 gap-x-4 w-full border border-gray-500 rounded-xl p-4 flex items-center">

        <form @submit.prevent="loadSubmitAsync" class="w-full">
            <input id="ssn" type="text" placeholder="Add task" v-model="todo.title"
                   class="input text-lg  focus:outline-none focus:border-sky-500 contrast-less:border-slate-300 text-slate-300">
        </form>

    </div>

</template>

<script lang="ts" setup>

import { TodoApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/TodoApiClient";
import { ref } from "vue";
import type { ToDo } from "@/modules/todos/models/ToDo";

const todoApiClient = new TodoApiClient();

const todo = ref<ToDo>({});

const loadSubmitAsync = async () => {
    debugger;
    console.log('submit presseed');

    await createTodoAsync();
}

const createTodoAsync = async () => {
    await todoApiClient.todos.createAsync(todo);
}

</script>