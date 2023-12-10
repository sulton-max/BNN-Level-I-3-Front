import ApiClientBase from "@/infrastructure/apiClients/apiClientBase/ApiClientBase";
import { TodoEndpointsDetails } from "@/infrastructure/apiClients/airBnbApiClient/brokers/TodoEndpointsDetails";

export class TodoApiClient {
    private readonly client: ApiClientBase;
    public readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7272";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.todos = new TodoEndpointsDetails(this.client);
    }

    public todos: TodoEndpointsDetails;
}