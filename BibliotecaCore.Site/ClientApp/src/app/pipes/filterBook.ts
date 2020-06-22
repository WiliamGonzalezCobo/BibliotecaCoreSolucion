import { PipeTransform, Pipe } from '@angular/core';
import { Author } from '../interface/author';

@Pipe({
    name: 'filterBook'
})

export class FilterBookPipe implements PipeTransform {
    transform(value: any, arg: any): any {
        const resultBooks = [];
        if (value) {
            if (arg === '') {
                return value;
            }
            for (const book of value) {
                    if (book.title.toLowerCase().indexOf(arg.toLowerCase()) > -1) {
                        resultBooks.push(book);
                    } else if (book.category.name.toLowerCase().indexOf(arg.toLowerCase()) > -1) {
                        resultBooks.push(book);
                    } else if (book.author.name.toLowerCase().indexOf(arg.toLowerCase()) > -1) {
                        resultBooks.push(book);
                    }
                }
        }
        return resultBooks;
    }
}
