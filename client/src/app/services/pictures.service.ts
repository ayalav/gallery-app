import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Picture } from '../interfaces/picture';

@Injectable({
  providedIn: 'root'
})
export class PicturesService {
  private apiUrl = 'http://localhost:5000/api/pictures'

  constructor(private http: HttpClient) { }
  private selectedPictureSubject = new BehaviorSubject<Picture | null>(null);
  selectedPicture$ = this.selectedPictureSubject.asObservable();

  getPictures(): Observable<Picture[]> {
    return this.http.get<Picture[]>(this.apiUrl);
  }

  setSelectedPicture(picture: Picture) {
    this.selectedPictureSubject.next(picture);
  }
}
