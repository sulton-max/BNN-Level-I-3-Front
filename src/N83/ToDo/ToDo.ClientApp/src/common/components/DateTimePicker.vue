<template>
    <div
        tabindex="0" ref="container"
        @focusout="onClose"
        class="h-[690px] theme-bg flex-col gap-y-4 items-center justify-between border border-gray-500 rounded-xl p-10 px-12 cursor-auto"
    >

        <!-- Date picker -->
        <div>

            <!-- Current day -->
            <div class="flex items-center text-4xl theme-text">
                <p>{{ formattedDate }}</p>
            </div>

            <h5 class="text-sm theme-text my-2 pl-2">Select date</h5>

            <!--Month selector-->
            <div class="flex items-center justify-between p-2">
                <button type="button" @click="onSetPrevMonth" class="theme-icon" :disabled="prevMonthDisabled"
                        :class="{'text-gray-500': prevMonthDisabled}">
                    <i class="fa-solid fa-angle-left"></i>
                </button>
                <p class="text-lg font-bold">{{ months[selectedTime!.getMonth()] }}</p>
                <button type="button" @click="onSetNextMonth" class="theme-icon" :disabled="nextMonthDisabled"
                        :class="{'text-gray-500': nextMonthDisabled}">
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
                    v-for="(day, index) in daysInCurrentMonth" :key="index"
                    type="button" @click="onSetDate(day)" :disabled="dateDisabled(day)"
                    :class="{'text-gray-500 hover:bg-opacity-10': dateDisabled(day), 'bg-opacity-80': dateCalculatorService.compareDates(day, selectedTime) == 0}"
                    class="flex text-sm theme-text justify-center items-center rounded-full w-12 h-12 bg-gray-500 bg-opacity-10 hover:bg-opacity-50"
                >
                    {{ day.getDate() }}
                </button>

                <!-- Days of the next month ( skipped ) -->
                <div v-for="day in nextMonthDaysToSkip" class="text-gray-500 flex items-center justify-center">
                </div>

            </div>
        </div>

        <div class="mt-5 flex flex-col space-y-5">

            <!-- Select Time -->
            <h5 class="text-sm theme-text my-2 pl-2">Select time</h5>

            <!-- Hour and Minute Inputs -->
            <div class="flex gap-x-4 items-center justify-center">

                <!-- Hours Input -->
                <div class="relative">
                    <input type="text" :disabled="true" :value="selectedTime.getHours()"
                           class="input theme-border w-[100px] h-14 outline-none text-3xl text-center">
                    <button type="button" class="absolute top-2 right-2 theme-icon btn-hover"
                            :disabled="nextHourDisabled" @click="onSetNextHour" :class="{'text-gray-500': nextHourDisabled}">
                        <i class="fa-solid fa-angle-up "/>
                    </button>
                    <button type="button" class="absolute bottom-1 right-2 theme-icon btn-hover" @click="onSetPrevHour"
                            :disabled="prevHourDisabled" :class="{'text-gray-500': prevHourDisabled}">
                        <i class="fa-solid fa-angle-down"/>
                    </button>
                </div>

                <!-- Minutes Input -->
                <div class="relative">
                    <input type="text" :disabled="true"
                           class="input theme-border w-[100px] h-14 outline-none text-3xl text-center"
                           :value="selectedTime.getMinutes()"/>
                    <button type="button" class="absolute top-2 right-2 theme-icon btn-hover"
                            :disabled="nextMinuteDisabled" @click="onSetNextMinute" :class="{'text-gray-500': nextMinuteDisabled}">
                        <i class="fa-solid fa-angle-up "/>
                    </button>
                    <button type="button" class="absolute bottom-1 right-2 theme-icon btn-hover"
                            :disabled="prevMinuteDisabled" @click="onSetPrevMinute" :class="{'text-gray-500': prevMinuteDisabled}">
                        <i class="fa-solid fa-angle-down"/>
                    </button>
                </div>

            </div>

        </div>

    </div>

</template>

<script setup lang="ts">

import { computed, nextTick, onMounted, reactive, ref, watch } from "vue";
import { DateTimeFormatterService } from "@/infrastructure/services/DateCalculatorService";

const container = ref<HTMLElement>();
const dateCalculatorService = new DateTimeFormatterService();
const weekDayNames = ["S", "M", "T", "W", "T", "F", "S"];
const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

/* region Props and Emits */

const props = defineProps({
    modelValue: {
        type: Date,
        required: true
    },
    minDate: {
        type: Date,
        required: false
    },
    maxDate: {
        type: Date,
        required: false
    }
});

const emit = defineEmits(['update:modelValue', 'onClose']);

/* endregion */

/* region Hooks */

onMounted(async () => {
    await nextTick(() => {
        container.value?.focus();
    });
});

/* endregion */

/* region Watchers and Computed props */

watch(() => props.modelValue, () => {

    // currentDate.value = props.modelValue;
});

const prevMonthDisabled = computed(() => props.minDate
    && (selectedTime.value.getMonth() === props.minDate.getMonth() && selectedTime.value.getFullYear() === props.minDate.getFullYear()));

const nextMonthDisabled = computed(() => props.maxDate
    && (selectedTime.value.getMonth() === props.maxDate.getMonth() && selectedTime.value.getFullYear() === props.maxDate.getFullYear()));

const prevHourDisabled = computed(() => {
    if (!props.minDate) return false;
    const time = new Date(selectedTime.value?.toString());
    time.setHours(time.getHours() - 1);
    return time < props.minDate;
});

const nextHourDisabled = computed(() => {
    if (!props.maxDate) return false;

    const time = new Date(selectedTime.value?.toString());
    time.setHours(time.getHours() + 1);
    return time > props.maxDate;
});

const prevMinuteDisabled = computed(() => {
    if (!props.minDate) return false;
    const time = new Date(selectedTime.value?.toString());
    time.setMinutes(time.getMinutes() - 1);
    return time < props.minDate;
});

const nextMinuteDisabled = computed(() => {
    if (!props.maxDate) return false;

    const time = new Date(selectedTime.value?.toString());
    time.setMinutes(time.getMinutes() + 1);
    return time > props.maxDate;
});

const prevMonthDaysToSkip = computed(() => dateCalculatorService.getPrevMonthLastDays(selectedTime.value));

const nextMonthDaysToSkip = computed(() => dateCalculatorService.getNextMonthFirstDays(selectedTime.value));

const formattedDate = computed(() => dateCalculatorService.formattedDate(selectedTime.value));

const selectedTime = computed({
    get() {
        return props.modelValue;
    },
    set(value: Date) {
        emit('update:modelValue', value);
    }
});

const daysInCurrentMonth = computed(() => dateCalculatorService.getMonthDaysAsDate(selectedTime.value));

/* endregion */

/* region Event handlers */

const onClose = () => {
    setTimeout(() => {
        const innerElementFocused = container.value!.contains(document.activeElement);
        if (!innerElementFocused)
            emit('onClose');
    }, 50);
}

const onSetNextMonth = () => selectedTime.value = dateCalculatorService.getNextMonth(selectedTime.value);

const onSetPrevMonth = () => selectedTime.value = dateCalculatorService.getPreviousMonth(selectedTime.value);

const onSetNextHour = () => {
    selectedTime.value?.setHours(selectedTime.value?.getHours() + 1);
    selectedTime.value = new Date(selectedTime.value?.toString());
}

const onSetPrevHour = () => {
    selectedTime.value?.setHours(selectedTime.value?.getHours() - 1);
    selectedTime.value = new Date(selectedTime.value?.toString());
}

const onSetNextMinute = () => {
    selectedTime.value?.setMinutes(selectedTime.value?.getMinutes() + 1);
    selectedTime.value = new Date(selectedTime.value?.toString());
}

const onSetPrevMinute = () => {
    selectedTime.value?.setMinutes(selectedTime.value?.getMinutes() - 1);
    selectedTime.value = new Date(selectedTime.value?.toString());
}

const onSetDate = (date: Date) => {
    if (props.minDate && date < props.minDate)
        selectedTime.value = props.minDate;
    else if (props.maxDate && date > props.maxDate)
        selectedTime.value = props.maxDate;
    else {
        date.setHours(selectedTime.value.getHours());
        date.setMinutes(selectedTime.value.getMinutes());
        selectedTime.value = new Date(date.toString());
    }
}

/* endregion */

/* region Methods */

const dateDisabled = (date: Date) =>
    (props.minDate && (dateCalculatorService.compareDates(date, props.minDate) === -1)
        || (props.maxDate && dateCalculatorService.compareDates(date, props.maxDate) === 1));

/* endregion */

</script>