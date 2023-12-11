import type { Guid } from "guid-typescript";

export class ToDoItem {
    constructor() {
        this.dueTime = new Date();
        this.reminderTime = new Date();
    }

    id!: Guid;
    title!: string;
    isDone!: boolean;
    isFavorite!: boolean;
    dueTime!: Date;
    reminderTime!: Date;
}