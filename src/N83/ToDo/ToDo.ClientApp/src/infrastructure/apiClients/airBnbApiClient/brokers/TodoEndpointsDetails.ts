import ApiClientBase from "@/infrastructure/apiClients/apiClientBase/ApiClientBase";
import { ToDo } from "@/modules/todos/models/ToDo";

export class TodoEndpointsDetails {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getAsync() {
        return await this.client.getAsync<Array<ToDo>>("api/todos");
    }

    public async getByIdAsync(id: string) {
        return await this.client.getAsync<Array<ToDo>>(`api/todos/${id}`);
    }

    public async createAsync(todo: ToDo) {
        return await this.client.getAsync<Array<ToDo>>("api/todos", todo);
    }

    public async updateAsync(todo: ToDo) {
        return await this.client.getAsync<Array<ToDo>>("api/todos", todo);
    }

    public async deleteAsync(id: string) {
        return await this.client.getAsync<Array<ToDo>>(`api/todos/${id}`);
    }
}