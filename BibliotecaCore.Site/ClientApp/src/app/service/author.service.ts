import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  urlApiAuthor = 'https://localhost:44373/api/Author/';

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  getData() {
    return this.http.get(this.urlApiAuthor);
  }

  postData(formData) {
    return this.http.post(this.urlApiAuthor, formData);
  }

  putData(id, formData) {
    return this.http.put(this.urlApiAuthor + id, formData);
  }
  
  deleteData(id) {
    return this.http.delete(this.urlApiAuthor + id);
  }
}
