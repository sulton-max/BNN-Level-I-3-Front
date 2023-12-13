<template>

    <div class="h-20 gap-x-4 w-full border border-gray-500 rounded-xl p-4 flex items-center">
        <form @submit.prevent="submitAsync" class="w-full flex relative items-center justify-center">

            <!-- Title input -->
            <div class="flex-grow">
                <input type="text" placeholder="Add task" v-model="todo.title"
                       class="input text-lg">
            </div>

            <div class="flex gap-x-4">

                <!-- Due time picker -->
                <date-time-picker class="z-20 absolute bottom-0 right-0"
                                  v-if="showDueTimePicker"
                                  @onClose="toggleDueTimePicker"
                                  :min-date="minDate"
                                  v-model="todo.dueTime"/>
                <button ref="dueTimeButton" type="button" class="text-2xl flex items-center justify-center relative"
                        @click="toggleDueTimePicker">
                    <i class="fa-regular btn-hover fa-calendar theme-icon mr-1"/>
                </button>

                <!-- Reminder time picker -->
                <date-time-picker class="z-20 absolute bottom-0 right-0"
                                  v-if="showReminderTimePicker"
                                  @onClose="toggleReminderTimePicker"
                                  :min-date="minDate"
                                  :max-date="todo.dueTime"
                                  v-model="todo.reminderTime"/>
                <button type="button" class="text-2xl flex items-center justify-center relative"
                        @click="toggleReminderTimePicker">
                    <i class="fa-regular btn-hover fa-bell theme-icon mr-1"></i>
                </button>

                <!-- Submit button -->
                <button type="submit"
                        class="w-7 h-7 btn-hover rounded-full bg-textSecondaryColor flex items-center justify-center">
                    <i class="fa-solid fa-check"></i>
                </button>

            </div>

        </form>
    </div>

</template>

<script lang="ts" setup>

import { ref, watch } from "vue";
import { Utils } from "@/infrastructure/extensions/ObjectExtensions";
import { ToDoItem } from "@/modules/todos/models/ToDoItem";
import { TodoApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/TodoApiClient";
import DateTimePicker from "@/common/components/DateTimePicker.vue";

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

const minDate = new Date();
const todo = ref<ToDoItem>(new ToDoItem());
const isEditing = ref<boolean>(false);
const showDueTimePicker = ref<boolean>(false);
const showReminderTimePicker = ref<boolean>(false);

watch(() => props.editTodo, () => {
    if (props.editTodo) {
        isEditing.value = true;
        todo.value = Utils.deepClone(props.editTodo);
        todo.value.dueTime = new Date(props.editTodo.dueTime);
        todo.value.reminderTime = new Date(props.editTodo.reminderTime);
    }
});

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

const resetForm = () => todo.value = new ToDoItem();

const createTodoAsync = async () => {
    const response = await todoApiClient.todos.createAsync(todo.value);

    if (response.isSuccess) emit("addNewTodo", response.response!)

    return response.isSuccess;
}

const updateTodoAsync = async () => {
    const response = await todoApiClient.todos.updateAsync(todo.value);
    if (response.isSuccess) Object.assign(props.editTodo!, todo.value!);

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

</script>