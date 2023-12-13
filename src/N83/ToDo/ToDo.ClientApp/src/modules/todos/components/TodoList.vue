<template>

    <div class="flex flex-col gap-4 w-full h-[800px] overflow-x-scroll no-scrollbar">
        <todo-card v-for="todo in todos" :key="todo.id.toString" :todo="todo" @editTodo="onEditTodo" @deleteTodo="onDeleteTodo"/>
    </div>

</template>

<script setup lang="ts">

import { defineProps, defineEmits } from "vue";
import TodoCard from "@/modules/todos/components/TodoCard.vue";
import type { ToDoItem } from "@/modules/todos/models/ToDoItem";
import type { PropType } from "vue";
import type { Guid } from "guid-typescript";

const props = defineProps({
    todos: {
        type: Array as PropType<Array<ToDoItem>>,
        required: true
    }
});

const emit = defineEmits<{
    editTodo: [id: Guid],
}>();

const onEditTodo = (id: Guid) => {
    emit("editTodo", id);
}

const onDeleteTodo = (id: Guid) => {
    const index = props.todos.findIndex(x => x.id === id);
    if (index !== -1)
        props.todos.splice(index, 1);
}

</script>