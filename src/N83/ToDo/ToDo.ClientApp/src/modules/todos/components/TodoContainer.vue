<template>

    <div class="h-full w-full p-20 flex flex-col gap-y-20 px-[20%] items-center justify-center">

        <!-- Task list -->
        <todo-list :todos="todos as ToDoItem[]" @editTodo="onEditTodo"/>

        <!-- New task form -->
        <new-todo-form @addNewTodo="onAddTodo" :editTodo="editTodo as ToDoItem"/>

    </div>

</template>

<script setup lang="ts">

import TodoList from "@/modules/todos/components/TodoList.vue";
import NewTodoForm from "@/modules/todos/components/TodoForm.vue";
import { ToDoItem } from "@/modules/todos/models/ToDoItem";
import { TodoApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/TodoApiClient";
import { onBeforeMount, ref } from "vue";
import type { Guid } from "guid-typescript";

const todoApiClient = new TodoApiClient();
const todos = ref<Array<ToDoItem>>([]);
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
    const index = todos.value.findIndex(element => element.dueTime > todo.dueTime && !element.isDone);
    if (index !== -1) todos.value.splice(index, 0, todo);
    else todos.value.unshift(todo);
}

const onEditTodo = (id: Guid) => {
    const todo = todos.value.find(x => x.id === id);
    if (todo) {
        editTodo.value = todo;
    }
}

</script>