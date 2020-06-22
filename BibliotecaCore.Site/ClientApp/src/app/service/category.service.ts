import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  urlApiCategory = 'https://localhost:44373/api/Category/';

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  getData() {
    return this.http.get(this.urlApiCategory);
  }

  postData(formData) {
    return this.http.post(this.urlApiCategory, formData);
  }

  putData(id, formData) {
    return this.http.put(this.urlApiCategory + id, formData);
  }
  deleteData(id) {
    return this.http.delete(this.urlApiCategory + id);
  }
}
