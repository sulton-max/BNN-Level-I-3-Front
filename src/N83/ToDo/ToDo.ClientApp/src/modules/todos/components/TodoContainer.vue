<template>

    <div class="h-full w-full p-20 flex flex-col gap-y-20 px-[20%] items-center justify-center">

        <!-- Todo list -->
        <todo-list :todos="todos" @editTodo="onEditTodo"/>

        <!-- New todo form -->
        <new-todo-form @addNewTodo="onAddTodo" :editTodo="editTodo" />

    </div>

</template>

<script setup lang="ts">

import TodoList from "@/modules/todos/components/TodoList.vue";
import NewTodoForm from "@/modules/todos/components/NewTodoForm.vue";
import type { ToDoItem } from "@/modules/todos/models/ToDoItem";
import { TodoApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/TodoApiClient";
import { onBeforeMount, ref } from "vue";
import type { Guid } from "guid-typescript";

const todoApiClient = new TodoApiClient();
const todos = ref<ToDoItem[]>([]);
const editTodo = ref<ToDoItem | null>(null);

onBeforeMount(async () => {
    await loadTodosAsync();
});

const loadTodosAsync = async () => {
    const todosResponse = await todoApiClient.todos.getAsync();
    if (todosResponse.isSuccess && todosResponse.response) {
        todos.value = todosResponse.response;
    }
}

const onAddTodo = (todo: ToDoItem) => {
    todos.value.push(todo);
}

const onEditTodo = (id: Guid) => {
    const todo = todos.value.find(x => x.id === id);
    if (todo) {
        editTodo.value = todo;
    }
}

</script>