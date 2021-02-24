import { Constants } from '../utils/constants';
import { Pipe, PipeTransform } from '@angular/core';
import { DecimalPipe } from '@angular/common';

@Pipe({
    name: 'yiNumber'
})
export class YiNumberPipe extends DecimalPipe implements PipeTransform {
    transform(value: any, args?: any): any {
        return super.transform(value, Constants.NUMBER_FMT);
    }
}