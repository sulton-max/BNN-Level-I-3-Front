import type ApiClientBase from "@/infrastructures/apiClients/apiClientBase/ApiClientBase";
import type { Location } from "@/modules/locations/models/Location";

export class LocationEndpointsClient {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getAsync() {
        return await this.client.getAsync<Array<Location>>("api/locations");
    }
}