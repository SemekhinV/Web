import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Skin } from './skin';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    skin: Skin = new Skin();   // изменяемый товар
    skins: Skin[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) {}

    ngOnInit() {
        this.loadSkins();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadSkins() {
        this.dataService.getSkins()
            .subscribe((data: Skin[]) => this.skins = data);
    }
    // сохранение данных
    save() {
        if (this.skin.id == null) {
            this.dataService.createSkin(this.skin)
                .subscribe((data: Skin) => this.skins.push(data));
        } else {
            this.dataService.updateSkin(this.skin)
                .subscribe(data => this.loadSkins());
        }
        this.cancel();
    }
    editSkin(p: Skin) {
        this.skin = p;
    }
    cancel() {
        this.skin = new Skin();
        this.tableMode = true;
    }
    delete(p: Skin) {
        this.dataService.deleteSkin(p.id)
            .subscribe(data => this.loadSkins());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}