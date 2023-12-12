<template>

    <div class="h-20 gap-x-4 w-full border border-gray-500 rounded-xl p-4 flex items-center">


        <form @submit.prevent="submitAsync" class="w-full flex relative">
            <div class="flex-grow">
                <input type="text" placeholder="Add task" v-model="todo.title"
                       class="input text-lg focus:outline-none focus:border-sky-500 contrast-less:border-slate-300 text-slate-300">
            </div>
            <div class="flex gap-x-4">

                <!-- Due time picker -->
                <date-time-picker autofocus @onClose="showDueTimePicker = !showDueTimePicker" :min-date="minDate" class="z-20 absolute bottom-0 right-0"
                                  :show="showDueTimePicker"
                                  v-model="todo.dueTime"/>
                <button type="button" class="text-2xl flex items-center justify-center relative" @click="toggleDueTimePicker">
                    <i class="fa-regular btn-hover fa-calendar theme-icon mr-1"/>
                </button>

                <!-- Reminder time picker -->
                <date-time-picker type="button" :min-date="minDate" class="z-20 absolute bottom-0 right-0"
                                  :show="showReminderTimePicker"
                                  v-model="todo.reminderTime"/>
                <button type="button" class="text-2xl flex items-center justify-center relative" @click="toggleReminderTimePicker">
                    <i class="fa-regular btn-hover fa-bell theme-icon mr-1"></i>
                </button>

                <button type="submit">Submit</button>

            </div>

        </form>
    </div>

</template>

<script lang="ts" setup>

import { ref, watch } from "vue";
import { Utils } from "@/infrastructure/extensions/ObjectExtensions";
import { ToDoItem } from "@/modules/todos/models/ToDoItem";
import { TodoApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/TodoApiClient";
import { useDate } from "vuetify";
import DateTimePicker from "@/common/components/DateTimePicker.vue";


const minDate = new Date();

const adapter = useDate();
const todoApiClient = new TodoApiClient();

const emit = defineEmits<{
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
const showDueTimePicker = ref<boolean>(false);
const showReminderTimePicker = ref<boolean>(false);

const submitAsync = async () => {
    let result: boolean;

    if (isEditing.value) {
        result = await updateTodoAsync();
        isEditing.value = false;
    } else {
        result = await createTodoAsync();
    }

    if (result)
        resetForm();
}

const resetForm = () => {
    todo.value = new ToDoItem();
    todo.value.dueTime = new Date();
    todo.value.reminderTime = new Date();
}

const createTodoAsync = async () => {
    console.log(todo.value);

    const response = await todoApiClient.todos.createAsync(todo.value);

    if (response.isSuccess)
        emit("addNewTodo", response.response!)

    return response.isSuccess;
}

const updateTodoAsync = async () => {
    const response = await todoApiClient.todos.updateAsync(todo.value);

    if (response.isSuccess) {
        Object.assign(props.editTodo!, todo.value!);
    }

    return response.isSuccess;
}

const toggleDueTimePicker = () => {
    showDueTimePicker.value = !showDueTimePicker.value;
    showReminderTimePicker.value = false;
}

const toggleReminderTimePicker = () => {
    showReminderTimePicker.value = !showReminderTimePicker.value;
    showDueTimePicker.value = false;
}

watch(() => props.editTodo, () => {
    if (props.editTodo) {
        isEditing.value = true;
        todo.value = Utils.deepClone(props.editTodo);
        todo.value.dueTime = new Date(props.editTodo.dueTime);
        todo.value.reminderTime = new Date(props.editTodo.reminderTime);
    }
});

</script>