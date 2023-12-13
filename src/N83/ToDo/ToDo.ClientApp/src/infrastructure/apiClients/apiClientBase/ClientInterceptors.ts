import type { AxiosError, AxiosInstance, AxiosResponse } from "axios";
import { ApiResponse } from "@/infrastructure/apiClients/apiClientBase/ApiResponse";
import { ProblemDetails } from "@/infrastructure/apiClients/apiClientBase/ProblemDetails";
import type { IMappable } from "@/infrastructure/mappers/IMappable";
// import { createInstance } from "@/infrastructure/extensions/InstanceProvider";

export class ClientInterceptors {

    public static registerResponseConverter(client: AxiosInstance) {
        client.interceptors.response.use(<TResponse extends IMappable<TResponse>>(response: AxiosResponse<TResponse>) => {
                return {
                    ...response,
                    data: new ApiResponse(response.data as TResponse, null, response.status)
                }
            },
            (error: AxiosError) => {
                return {
                    ...error,
                    data: new ApiResponse(null, error.response?.data as ProblemDetails, error.response?.status ?? 500)
                };
            }
        );
    }
}
