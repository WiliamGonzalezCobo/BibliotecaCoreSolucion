import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { BookComponent } from './components/book/book.component';
import { CategoryComponent } from './components/category/category.component';
import { AuthorComponent } from './components/author/author.component';
import { NgModule } from '@angular/core';
import { AuthGuard } from './service/auth.guard';

const routes: Routes = [
        { path: '', pathMatch: 'full', redirectTo: 'login'},
        { path: 'login', component: LoginComponent },
        { path: 'book', component: BookComponent, canActivate:[AuthGuard] },
        { path: 'category', component: CategoryComponent, canActivate:[AuthGuard] },
        { path: 'author', component: AuthorComponent, canActivate:[AuthGuard] }
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
