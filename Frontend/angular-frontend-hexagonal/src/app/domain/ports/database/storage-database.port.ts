export interface IStorageDatabasePort {
    setData<T>(key: string, data: T): void;
    getData(key: string): string | null;
    removeData(key: string): void;
}

export abstract class StorageDatabasePort implements IStorageDatabasePort {
    abstract setData<T>(key: string, data: T): void;
    abstract getData(key: string): string | null;
    abstract removeData(key: string): void;
}