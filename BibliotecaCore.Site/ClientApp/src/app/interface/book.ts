import { Author } from './author';
import { Category } from './category';
export interface Book {
    id: number;
    title: string;
    isbn: string;
    authorid: number;
    categoryid: number;
    author: Author;
    category: Category;
}
