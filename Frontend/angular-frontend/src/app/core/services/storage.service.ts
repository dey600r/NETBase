import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  setData<T>(key: string, data: T) {
    localStorage.setItem(key, JSON.stringify(data));
  }

  getData(key: string): string | null {
    return localStorage.getItem(key);
  }
}
