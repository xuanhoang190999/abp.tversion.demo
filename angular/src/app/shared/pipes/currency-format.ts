import { Pipe, PipeTransform } from '@angular/core';
import { CurrencyPipe } from '@angular/common';
import { Constants } from '../utils/constants';

@Pipe({
    name: 'yiCurrency'
})
export class YiCurrencyPipe extends CurrencyPipe implements PipeTransform {
    transform(value: any, args?: any): any {
        return super.transform(value, '', false, Constants.CURRENCY_FMT);
    }
}
