import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const URLAPI = 'https://localhost:44373/api/Book/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) {}

  getData() {
    return this.http.get(`${URLAPI}`, httpOptions);
  }

  postData(formData) {
    return this.http.post(`${URLAPI}`, formData);
  }

  putData(id, formData) {
    return this.http.put(`${URLAPI}` + id, formData);
  }
  deleteData(id) {
    return this.http.delete(`${URLAPI}` + id);
  }
}
