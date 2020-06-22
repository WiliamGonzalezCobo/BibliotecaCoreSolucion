import { Component, OnInit } from '@angular/core';
import { AuthorService } from '../../service/author.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Author } from '../../interface/author';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {
  constructor(private authorService: AuthorService) { }
    title = 'app';
    AuthorForm: FormGroup;
    submitted = false;
    EventValue = 'Save';
    authors: Author[];

  ngOnInit(): void {
    this.getAuthors();
    this.inicialFormAuthor();
  }

  getAuthors() {
    this.authorService.getData().subscribe((authors: Author[]) => {
      this.authors = authors;
    });
  }

  deleteData(id) {
    this.authorService.deleteData(id).subscribe((response: any) => {
      this.getAuthors();
    });
  }

  Save() {
    this.submitted = true;
     if (this.AuthorForm.invalid) {
            return;
     }
    this.authorService.postData(this.AuthorForm.value).subscribe((response: any) => {
    this.getAuthors();
    this.resetForm();
    });
  }

  Update() {
    this.submitted = true;
    if (this.AuthorForm.invalid) {
     return;
    }
    this.authorService.putData(this.AuthorForm.value.id, this.AuthorForm.value).subscribe((response: any) => {
      this.getAuthors();
      this.resetForm();
    });
  }

 EditData(author: Author) {
    this.AuthorForm.controls['id'].setValue(author.id);
    this.AuthorForm.controls['name'].setValue(author.name);
    this.AuthorForm.controls['lastName'].setValue(author.lastName);
    const indexT = author.birthdate.toString().indexOf('T');
    this.AuthorForm.controls['birthdate'].setValue(author.birthdate.toString().substring(0, indexT));
    this.EventValue = 'Update';
  }

  resetForm() {
    this.getAuthors();
    this.inicialFormAuthor();
    this.EventValue = 'Save';
    this.submitted = false;
  }

  inicialFormAuthor() {
    this.AuthorForm = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      birthdate: new FormControl('', [Validators.required]),
    });
  }
}
