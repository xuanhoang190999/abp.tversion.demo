import { Pipe, PipeTransform } from '@angular/core';
import * as _ from 'lodash';

@Pipe({ name: 'orderBy', pure: false })
export class OrderByPipe implements PipeTransform {

    transform(value: any[], column: string, order = ''): any[] {
        if (!value || !column || column === '' || order === '') { return value; } // no array
        if (value.length <= 1) { return value; } // array with only one item

        return _.orderBy(value, [column], [order]);
    }
}