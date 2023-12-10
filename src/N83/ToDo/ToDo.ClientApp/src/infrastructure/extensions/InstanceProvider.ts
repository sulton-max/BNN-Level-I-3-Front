export function createInstance<T>(ctor: { new(): T; }): T {
    return new ctor();
}