import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { BookComponent } from './components/book/book.component';
import { CategoryComponent } from './components/category/category.component';
import { AuthorComponent } from './components/author/author.component';

import { BookService } from './service/book.service';
import { FilterBookPipe } from './pipes/filterBook';
import { AuthorService } from './service/author.service';
import { CategoryService } from './service/category.service';
import { AuthService } from './service/auth.service';
import { LoginComponent } from './components/login/login.component';
import { HttpInterceptorModule } from './service/http-interceptor.modules';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    BookComponent,
    CategoryComponent,
    AuthorComponent,
    FilterBookPipe,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    HttpInterceptorModule,
    AppRoutingModule
  ],
  providers: [BookService, AuthorService, CategoryService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
