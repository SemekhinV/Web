import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Skin } from './skin';

@Injectable()
export class DataService {

    private url = "/api/skins";

    constructor(private http: HttpClient) {
    }

    getSkins() {
        return this.http.get(this.url);
    }

    getSkin(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createSkin(skin: Skin) {
        return this.http.post(this.url, skin);
    }
    updateSkin(skin: Skin) {

        return this.http.put(this.url, skin);
    }
    deleteSkin(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}