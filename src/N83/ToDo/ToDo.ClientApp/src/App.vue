<template>

    <home-view/>

    <!-- Tasks Container -->
    <!--        <div class=" ">-->

    <!--            &lt;!&ndash; Tasks Container &ndash;&gt;-->
    <!--            <div>-->

    <!--                <div class="border border-gray-600 rounded-3xl overflow-hidden">-->

    <!--                    <div class="flex items-center p-4 shadow-md">-->

    <!--                        &lt;!&ndash; Mark as done button &ndash;&gt;-->
    <!--                        <button-->
    <!--                            class="mr-4 bg-green-500 text-white rounded-full p-2 hover:bg-green-600 focus:outline-none">-->
    <!--                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"-->
    <!--                                 stroke="currentColor"-->
    <!--                                 class="h-6 w-6">-->
    <!--                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"-->
    <!--                                      d="M5 13l4 4L19 7"></path>-->
    <!--                            </svg>-->
    <!--                        </button>-->
    <!--                        &lt;!&ndash; Task details &ndash;&gt;-->
    <!--                        <div class="flex-grow text-gray-900">-->
    <!--                            <h2 class="text-lg title-font font-medium mb-1">The Catalyzer</h2>-->
    <!--                            <div class="flex">-->
    <!--                                <p class="text-sm truncate">Tasks</p>-->
    <!--                                <p>*</p>-->
    <!--                                <p class="text-sm">Sun, Sep 3</p>-->
    <!--                            </div>-->
    <!--                        </div>-->
    <!--                        &lt;!&ndash; Favorite button &ndash;&gt;-->
    <!--                        <button-->
    <!--                            class="ml-4 bg-yellow-500 text-white rounded-full p-2 hover:bg-yellow-600 focus:outline-none">-->
    <!--                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"-->
    <!--                                 stroke="currentColor"-->
    <!--                                 class="h-6 w-6">-->
    <!--                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"-->
    <!--                                      d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"></path>-->
    <!--                            </svg>-->
    <!--                        </button>-->
    <!--                    </div>-->

    <!--                    <div class="border-b border-gray-600"></div>-->

    <!--                    <div class="flex items-center p-4  shadow-md ">-->
    <!--                        &lt;!&ndash; Mark as done button &ndash;&gt;-->
    <!--                        <button-->
    <!--                            class="mr-4 bg-green-500 text-white rounded-full p-2 hover:bg-green-600 focus:outline-none">-->
    <!--                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"-->
    <!--                                 stroke="currentColor"-->
    <!--                                 class="h-6 w-6">-->
    <!--                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"-->
    <!--                                      d="M5 13l4 4L19 7"></path>-->
    <!--                            </svg>-->
    <!--                        </button>-->
    <!--                        &lt;!&ndash; Task details &ndash;&gt;-->
    <!--                        <div class="flex-grow text-gray-900">-->
    <!--                            <h2 class="text-lg title-font font-medium mb-1">The Catalyzer</h2>-->
    <!--                            <p class="leading-relaxed truncate">Photo booth fam kinfolk cold-pressed sriracha leggings-->
    <!--                                jianbing microdosing tousled waistcoat.</p>-->
    <!--                        </div>-->
    <!--                        &lt;!&ndash; Favorite button &ndash;&gt;-->
    <!--                        <button-->
    <!--                            class="ml-4 bg-yellow-500 text-white rounded-full p-2 hover:bg-yellow-600 focus:outline-none">-->
    <!--                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"-->
    <!--                                 stroke="currentColor"-->
    <!--                                 class="h-6 w-6">-->
    <!--                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"-->
    <!--                                      d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"></path>-->
    <!--                            </svg>-->
    <!--                        </button>-->
    <!--                    </div>-->

    <!--                    <div class="border-b border-gray-600"></div>-->

    <!--                    <div class="flex items-center p-4  shadow-md ">-->
    <!--                        &lt;!&ndash; Mark as done button &ndash;&gt;-->
    <!--                        <button-->
    <!--                            class="mr-4 bg-green-500 text-white rounded-full p-2 hover:bg-green-600 focus:outline-none">-->
    <!--                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"-->
    <!--                                 stroke="currentColor"-->
    <!--                                 class="h-6 w-6">-->
    <!--                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"-->
    <!--                                      d="M5 13l4 4L19 7"></path>-->
    <!--                            </svg>-->
    <!--                        </button>-->
    <!--                        &lt;!&ndash; Task details &ndash;&gt;-->
    <!--                        <div class="flex-grow text-gray-900">-->
    <!--                            <h2 class="text-lg title-font font-medium mb-1">The Catalyzer</h2>-->
    <!--                            <p class="leading-relaxed truncate">Photo booth fam kinfolk cold-pressed sriracha leggings-->
    <!--                                jianbing microdosing tousled waistcoat.</p>-->
    <!--                        </div>-->
    <!--                        &lt;!&ndash; Favorite button &ndash;&gt;-->
    <!--                        <button-->
    <!--                            class="ml-4 bg-yellow-500 text-white rounded-full p-2 hover:bg-yellow-600 focus:outline-none">-->
    <!--                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"-->
    <!--                                 stroke="currentColor"-->
    <!--                                 class="h-6 w-6">-->
    <!--                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"-->
    <!--                                      d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"></path>-->
    <!--                            </svg>-->
    <!--                        </button>-->
    <!--                    </div>-->

    <!--                </div>-->

    <!--            </div>-->

    <!--            &lt;!&ndash; New Task Card &ndash;&gt;-->
    <!--            &lt;!&ndash;            <div>&ndash;&gt;-->

    <!--            &lt;!&ndash;                <form @submit.prevent="">&ndash;&gt;-->
    <!--            &lt;!&ndash;                    <div class="flex flex-col p-5 bg-white rounded shadow w-full max-w-sm m-auto">&ndash;&gt;-->
    <!--            &lt;!&ndash;                        <div class="mb-4">&ndash;&gt;-->
    <!--            &lt;!&ndash;                            <label class="block text-grey-darker text-base font-bold mb-2" for="title">Task&ndash;&gt;-->
    <!--            &lt;!&ndash;                                Title</label>&ndash;&gt;-->
    <!--            &lt;!&ndash;                            <input&ndash;&gt;-->
    <!--            &lt;!&ndash;                                class="shadow bg-white focus:ring focus:outline-none text-grey-darker border rounded py-2 px-3 mb-2 leading-tight w-full"&ndash;&gt;-->
    <!--            &lt;!&ndash;                                id="title" v-model="task.title" type="text" placeholder="Task Title">&ndash;&gt;-->
    <!--            &lt;!&ndash;                        </div>&ndash;&gt;-->
    <!--            &lt;!&ndash;                        <div class="mb-4">&ndash;&gt;-->
    <!--            &lt;!&ndash;                            <label class="block text-grey-darker text-base font-bold mb-2" for="description">Task&ndash;&gt;-->
    <!--            &lt;!&ndash;                                Description</label>&ndash;&gt;-->
    <!--            &lt;!&ndash;                            <textarea&ndash;&gt;-->
    <!--            &lt;!&ndash;                                class="shadow bg-white focus:ring focus:outline-none text-grey-darker border rounded py-2 px-3 mb-2 leading-tight w-full"&ndash;&gt;-->
    <!--            &lt;!&ndash;                                id="description" v-model="task.description" placeholder="Task Description"></textarea>&ndash;&gt;-->
    <!--            &lt;!&ndash;                        </div>&ndash;&gt;-->
    <!--            &lt;!&ndash;                        <div class="mb-4">&ndash;&gt;-->
    <!--            &lt;!&ndash;                            <label class="block text-grey-darker text-base font-bold mb-2" for="date">Task Date</label>&ndash;&gt;-->
    <!--            &lt;!&ndash;                            &lt;!&ndash;                            <v-date-picker v-model="task.date" class="w-full"></v-date-picker>&ndash;&gt;&ndash;&gt;-->
    <!--            &lt;!&ndash;                        </div>&ndash;&gt;-->
    <!--            &lt;!&ndash;                        <div class="flex items-center justify-between">&ndash;&gt;-->
    <!--            &lt;!&ndash;                            <button class="bg-blue-500 hover:bg-blue-dark text-white font-bold py-2 px-4 rounded"&ndash;&gt;-->
    <!--            &lt;!&ndash;                                    type="submit"> Create Task&ndash;&gt;-->
    <!--            &lt;!&ndash;                            </button>&ndash;&gt;-->
    <!--            &lt;!&ndash;                        </div>&ndash;&gt;-->
    <!--            &lt;!&ndash;                    </div>&ndash;&gt;-->
    <!--            &lt;!&ndash;                </form>&ndash;&gt;-->

    <!--            &lt;!&ndash;            </div>&ndash;&gt;-->

    <!--        </div>-->

</template>

<script setup lang="ts">

import { ref } from "vue";
import HomeView from "@/common/views/HomeView.vue";


</script>