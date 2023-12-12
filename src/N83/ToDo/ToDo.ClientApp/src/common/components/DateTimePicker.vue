<template>
    <div
        @focusout="console.log('focusout')"
        class="w-[500px] theme-bg flex-col gap-y-4 justify-between border-2 border-gray-200 rounded-lg p-10 cursor-auto"
        :class="show ? 'block' : 'hidden'">

        <!-- Current day -->
        <div class="flex items-center text-4xl theme-text">
            <p>{{ formattedDate }}</p>
        </div>

        <!--Month selector-->
        <div class="flex items-center justify-between p-2">
            <button @click="prevMonth" class="theme-icon" :disabled="prevMonthDisabled"
                    :class="{'text-gray-500': prevMonthDisabled}">
                <i class="fa-solid fa-angle-left"></i>
            </button>
            <p class="text-lg font-bold">{{ months[currentDate!.getMonth()] }}</p>
            <button @click="nextMonth" class="theme-icon">
                <i class="fa-solid fa-angle-right"></i>
            </button>
        </div>

        <!-- Days in current month -->
        <div class="grid grid-cols-7 text-bold gap-2">

            <!-- Week day names -->
            <div v-for="weekDay in weekDayNames" class="theme-text text-base flex items-center justify-center">
                {{ weekDay }}
            </div>

            <!-- Days of previous month ( skipped ) -->
            <div v-for="day in prevMonthDaysToSkip" class="text-gray-500 flex items-center justify-center"></div>

            <!-- Days in month -->
            <button
                type="button"
                @click="currentDate = day"
                v-for="(day, index) in daysInCurrentMonth"
                :key="index"
                :class="{'text-gray-500 hover:bg-opacity-10': dateDisabled(day), 'bg-opacity-80': compareDates(day, currentDate) == 0}"
                :disabled="dateDisabled(day)"
                class="flex text-sm theme-text justify-center items-center rounded-full w-12 h-12 bg-gray-500 bg-opacity-10 hover:bg-opacity-50"
            >
                {{ day.getDate() }}
            </button>

            <!-- Days of the next month ( skipped ) -->
            <div v-for="day in nextMonthDaysToSkip" class="text-gray-500 flex items-center justify-center"></div>

        </div>
    </div>
</template>

<script setup lang="ts">

import { computed, ref } from "vue";

const props = defineProps({
    modelValue: {
        type: Date,
        required: true
    },
    minDate: {
        type: Date,
        required: false
    },
    show: {
        type: Boolean,
        required: false,
        default: false
    }
});

const emit = defineEmits(['update:modelValue', 'onClose']);

const dateSelected = (date: Date) => {
    currentDate.value = date;
}

const weekDayNames = ["S", "M", "T", "W", "T", "F", "S"];
const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

const currentDate = computed({
    get() {
        return props.modelValue;
    },
    set(value: Date) {
        emit('update:modelValue', value);
    }
});

// ref<Date>(new Date());

const daysInCurrentMonth = computed(() => {
    const year = currentDate.value.getFullYear();
    const month = currentDate.value.getMonth();
    const daysInMonth = new Date(year, month + 1, 0).getDate();

    return Array.from({length: daysInMonth}, (_, i) => new Date(year, month, i + 1));
});

const prevMonthDaysToSkip = computed(() => {
    const firstDayOfTheMonth = new Date(currentDate.value.getFullYear(), currentDate.value.getMonth()).getDay();
    return Array.from({length: firstDayOfTheMonth}, (_, i) => i);
});

const nextMonthDaysToSkip = computed(() => {
    const lastDayOfTheMonth = new Date(currentDate.value.getFullYear(), currentDate.value.getMonth() + 1, 0).getDay();
    return Array.from({length: 6 - lastDayOfTheMonth}, (_, i) => i);
});

const formattedDate = computed(() => {
    const dayShort = currentDate.value.toLocaleString("en-US", {weekday: 'short'});
    const monthShort = currentDate.value.toLocaleString("en-US", {month: 'short'});
    const day = currentDate.value.toLocaleString("en-US", {day: '2-digit'});
    return `${dayShort}, ${monthShort} ${day}`;
});

const dateDisabled = (date: Date) => props.minDate && compareDates(date, props.minDate) === -1;

const compareDates = (date1: Date, date2: Date): -1 | 0 | 1 => {
    const d1 = new Date(date1.getFullYear(), date1.getMonth(), date1.getDate());
    const d2 = new Date(date2.getFullYear(), date2.getMonth(), date2.getDate());

    if (d1 < d2) {
        return -1;
    } else if (d1 > d2) {
        return 1;
    } else {
        return 0;
    }
}

// const getDateWithoutHours = (date: Date) => new Date(date.getFullYear(), date.getMonth(), date.getDate());

const prevMonthDisabled = computed(() => props.minDate && (currentDate.value.getMonth() === props.minDate.getMonth() && currentDate.value.getFullYear() === props.minDate.getFullYear()));

const nextMonth = () => currentDate.value = new Date(currentDate.value.getFullYear(), currentDate.value.getMonth() + 1, currentDate.value.getDate());

const prevMonth = () => currentDate.value = new Date(currentDate.value.getFullYear(), currentDate.value.getMonth() - 1, currentDate.value.getDate());

</script>