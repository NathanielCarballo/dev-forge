import { Injectable } from '@angular/core';
import { CarList } from '../carlist';


@Injectable({
    providedIn: 'root'
})

export class CarService {
    url = 'http://localhost:3000/cars';


async getAllCars(): Promise<CarList[]> {
    const data = await fetch(this.url);
    return await data.json() ?? [];
}

async getCarById(id: number): Promise<CarList | undefined> {
    const data = await fetch(`${this.url}/${id}`);
    return await data.json() ?? {};
}

}
