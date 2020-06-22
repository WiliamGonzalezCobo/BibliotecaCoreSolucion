import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BookService } from '../../service/book.service';
import { Book } from '../../interface/book';
import { CategoryService } from '../../service/category.service';
import { Category } from '../../interface/category';
import { AuthorService } from '../../service/author.service';
import { Author } from '../../interface/author';
import { AuthService } from '../../service/auth.service';


@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  constructor(private bookService: BookService, private categoryService: CategoryService,
    private authorService: AuthorService, private authService: AuthService) { }
    title = 'app';
    data: Book[];
    categories: Category[];
    authors: Author[];
    BookForm: FormGroup;
    submitted = false;
    EventValue: any = 'Save';
    textSearch = '';

  ngOnInit(): void {
      this.getdata();
      this.getCategories();
      this.getAuthors();
      this.inicialFormBook();
  }

  getdata() {
    this.bookService.getData().subscribe((data: Book[]) => {
      this.data = data;
    });
  }

  getCategories() {
    this.categoryService.getData().subscribe((categories: Category[]) => {
      this.categories = categories;
    });
  }

  getAuthors() {
    this.authorService.getData().subscribe((authors: Author[]) => {
      this.authors = authors;
    });
  }

  deleteData(id) {
    this.bookService.deleteData(id).subscribe((response: any) => {
      this.getdata();
    });
  }

  Save() {
    this.submitted = true;
     if (this.BookForm.invalid) {
            return;
     }
    this.bookService.postData(this.BookForm.value).subscribe((response: any) => {
    this.getdata();
    this.resetForm();
    });
  }

  Update() {
    this.submitted = true;
    if (this.BookForm.invalid) {
     return;
    }
    this.bookService.putData(this.BookForm.value.id, this.BookForm.value).subscribe((response: any) => {
      this.getdata();
      this.resetForm();
    });
  }

 EditData(book: Book) {
    this.BookForm.controls['id'].setValue(book.id);
    this.BookForm.controls['title'].setValue(book.title);
    this.BookForm.controls['isbn'].setValue(book.isbn);
    this.BookForm.controls['authorid'].setValue(book.authorid);
    this.BookForm.controls['categoryid'].setValue(book.categoryid);
    this.EventValue = 'Update';
  }

  resetForm() {
    this.getdata();
    this.inicialFormBook();
    this.EventValue = 'Save';
    this.submitted = false;
  }
  inicialFormBook() {
    this.BookForm = new FormGroup({
      id: new FormControl(0),
      title: new FormControl('', [Validators.required]),
      isbn: new FormControl('', [Validators.required]),
      authorid: new FormControl('', [Validators.required]),
      categoryid: new FormControl('', [Validators.required]),
    });
  }
}
