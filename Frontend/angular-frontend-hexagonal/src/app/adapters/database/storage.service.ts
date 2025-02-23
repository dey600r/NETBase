import { Injectable } from '@angular/core';
import { StorageDatabasePort } from '@app/domain/ports/index';

@Injectable({
  providedIn: 'root'
})
export class StorageService implements StorageDatabasePort {

  setData<T>(key: string, data: T) {
    localStorage.setItem(key, JSON.stringify(data));
  }

  getData(key: string): string | null {
    try {
      return localStorage.getItem(key);
    } catch(e) {
      return null;
    }
  }

  removeData(key: string): void {
    localStorage.removeItem(key);
  }
}
