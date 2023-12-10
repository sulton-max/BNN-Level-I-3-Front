import type { Guid } from "guid-typescript";
import type { IMappable } from "@/infrastructure/mappers/IMappable";

export class ToDoItem implements IMappable<ToDoItem> {
    constructor() {
        this.dueTime = new Date();
        this.reminderTime = new Date();
    }

    id!: Guid;
    title!: string;
    notes!: string;
    isDone!: boolean;
    isFavorite!: boolean;
    dueTime!: Date;
    reminderTime!: Date;

    public mapFrom(object: any) {
        this.id = object.id;
        this.title = object.title;
        this.notes = object.notes;
        this.isDone = object.isDone;
        this.isFavorite = object.isFavorite;
        this.dueTime = new Date(object.dueTime);
        this.reminderTime = new Date(object.reminderTime);

        return this;
    }
}