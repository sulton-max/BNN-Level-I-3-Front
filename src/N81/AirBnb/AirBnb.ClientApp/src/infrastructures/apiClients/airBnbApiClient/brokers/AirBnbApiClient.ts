import ApiClientBase from "@/infrastructures/apiClients/apiClientBase/ApiClientBase";
import { LocationEndpointsClient } from "@/infrastructures/apiClients/airBnbApiClient/brokers/LocationEndpointsClient";
import { LocationCategoriesEndpointsClients } from "@/infrastructures/apiClients/airBnbApiClient/brokers/LocationCategoriesEndpointsClients";

export class AirBnbApiClient {
    private readonly client: ApiClientBase;
    public readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7114";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.locations = new LocationEndpointsClient(this.client);
        this.locationCategories = new LocationCategoriesEndpointsClients(this.client);
    }

    public locations: LocationEndpointsClient;

    public locationCategories: LocationCategoriesEndpointsClients;
}