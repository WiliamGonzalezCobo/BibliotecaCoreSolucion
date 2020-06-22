import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../service/category.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Category } from '../../interface/category';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  constructor(private categoryService: CategoryService) { }
  title = 'app';
  CategoryForm: FormGroup;
  submitted = false;
  EventValue = 'Save';
  categories: Category[];

ngOnInit(): void {
  this.getcategories();
  this.inicialFormCategory();
}

getcategories() {
  this.categoryService.getData().subscribe((categories: Category[]) => {
    this.categories = categories;
  });
}

deleteData(id) {
  this.categoryService.deleteData(id).subscribe((response: any) => {
    this.getcategories();
  });
}

Save() {
  this.submitted = true;
   if (this.CategoryForm.invalid) {
          return;
   }
  this.categoryService.postData(this.CategoryForm.value).subscribe((response: any) => {
  this.getcategories();
  this.resetForm();
  });
}

Update() {
  this.submitted = true;
  if (this.CategoryForm.invalid) {
   return;
  }
  this.categoryService.putData(this.CategoryForm.value.id, this.CategoryForm.value).subscribe((response: any) => {
    this.getcategories();
    this.resetForm();
  });
}

EditData(categoy: Category) {
  this.CategoryForm.controls['id'].setValue(categoy.id);
  this.CategoryForm.controls['name'].setValue(categoy.name);
  this.CategoryForm.controls['description'].setValue(categoy.description);
  this.EventValue = 'Update';
}

resetForm() {
  this.getcategories();
  this.inicialFormCategory();
  this.EventValue = 'Save';
  this.submitted = false;
}

inicialFormCategory() {
  this.CategoryForm = new FormGroup({
    id: new FormControl(0),
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
  });
}
}
