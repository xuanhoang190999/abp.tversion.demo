import { Constants } from '../utils/constants';
import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'yiDateTime'
})
export class YiDateTimePipe extends DatePipe implements PipeTransform {
    transform(value: any, args?: any): any {
        return super.transform(value, Constants.DATE_TIME_FMT);
    }
}