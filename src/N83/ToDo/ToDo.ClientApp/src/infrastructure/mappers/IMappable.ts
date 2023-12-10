export interface IMappable<T> {
    mapFrom(object: any): T;
}