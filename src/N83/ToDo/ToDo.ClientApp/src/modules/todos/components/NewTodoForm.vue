<template>

    <div class="h-20 gap-x-4 w-full border border-gray-500 rounded-xl p-4 flex items-center">
        <form @submit.prevent="submitAsync" class="w-full">
            <input type="text" placeholder="Add task" v-model="todo.title"
                   class="input text-lg  focus:outline-none focus:border-sky-500 contrast-less:border-slate-300 text-slate-300">
        </form>
    </div>

</template>

<script lang="ts" setup>

import { ref, watch, watchEffect } from "vue";
import { ToDoItem } from "@/modules/todos/models/ToDoItem";
import { TodoApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/TodoApiClient";

const todoApiClient = new TodoApiClient();

const emits = defineEmits<{
    addNewTodo: [todo: ToDoItem]
}>();

const props = defineProps({
    editTodo: {
        type: Object as () => ToDoItem | null,
        required: false,
        default: null
    }
});

const isEditing = ref<boolean>(false);
const todo = ref<ToDoItem>(new ToDoItem());

const submitAsync = async () => {
    let result: boolean;

    if (isEditing.value) {
        result = await updateTodoAsync();
    } else {
        result = await createTodoAsync();
    }

    if (result) {
        resetForm();
        isEditing.value = false;
    }
}

const resetForm = () => {
    todo.value = new ToDoItem();
}

const createTodoAsync = async () => {
    const response = await todoApiClient.todos.createAsync(todo.value);

    if (response.isSuccess)
        emits("addNewTodo", response.response!)

    return response.isSuccess;
}

const updateTodoAsync = async () => {
    const response = await todoApiClient.todos.updateAsync(todo.value);

    if (response.isSuccess)
        updateTodoValues(response.response!);

    return response.isSuccess;
}

const updateTodoValues = (todo: ToDoItem) => {
    props.editTodo!.title = todo.title;
    props.editTodo!.notes = todo.title;
    props.editTodo!.dueDateTime = todo.dueDateTime;
    props.editTodo!.reminderTime = todo.reminderTime;
}

watch(() => props.editTodo, () => {
    if (props.editTodo) {
        isEditing.value = true;
        todo.value = props.editTodo;
    }
});

</script>