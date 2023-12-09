<template>

    <div class="h-full w-full p-20 flex flex-col gap-y-20 px-[20%] items-center justify-center">

        <todo-list/>

        <new-todo-form/>

    </div>

</template>
<script setup lang="ts">
import TodoList from "@/modules/todos/components/TodoList.vue";
import NewTodoForm from "@/modules/todos/components/NewTodoForm.vue";
</script>