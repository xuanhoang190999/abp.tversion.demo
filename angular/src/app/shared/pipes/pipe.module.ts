import { NgModule, ModuleWithProviders } from '@angular/core';

import { SafeHtmlPipe } from './safe-html.pipe';
import { ImageResizePipe } from './image-resize.pipe';
import { SanitizeHtmlPipe } from './sanitize-html.pipe';
import { OrderByPipe } from './order-by.pipe';
import { FilterPipe } from './filter-by.pipe';
import { YiDateTimePipe } from './yi-date-time.pipe';
import { YiDatePipe } from './yi-date.pipe';
import { YiNumberPipe } from './number-format.pipe';
import { YiCurrencyPipe } from './currency-format';
import { FilterBillOfPartner } from './filter-bill-of-partner.pipe';
import { LockFilterPipe } from './filter-text.pipe';

@NgModule({
    imports: [
    ],
    declarations: [
        OrderByPipe,
        ImageResizePipe,
        SafeHtmlPipe,
        SanitizeHtmlPipe,
        FilterPipe,
        YiDatePipe,
        YiDateTimePipe,
        YiNumberPipe,
        YiCurrencyPipe,
        FilterBillOfPartner,
        LockFilterPipe,
    ],
    exports: [
        OrderByPipe,
        ImageResizePipe,
        SafeHtmlPipe,
        SanitizeHtmlPipe,
        FilterPipe,
        YiDatePipe,
        YiDateTimePipe,
        YiNumberPipe,
        YiCurrencyPipe,
        FilterBillOfPartner,
        LockFilterPipe
    ],
})

export class PipeModule {
    static forRoot(): ModuleWithProviders<PipeModule> {
        return {
            ngModule: PipeModule,
            providers: [],
        };
    }
}
