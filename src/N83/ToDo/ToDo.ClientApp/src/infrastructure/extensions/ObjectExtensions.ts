export class Utils {
    static deepClone<T>(obj: T): T {
        return JSON.parse(JSON.stringify(obj));
    }
}