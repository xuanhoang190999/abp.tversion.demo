import { Pipe, PipeTransform, Output, EventEmitter } from '@angular/core';

@Pipe({
  name: 'filter',
})
export class FilterPipe implements PipeTransform {
  transform(quickReplies: any[], searchText: string): any[] {
    searchText = searchText.toLocaleLowerCase().trim();
    return quickReplies.filter(ft => {
        return ft.Name.toLowerCase().includes(searchText);
    })
  }
}
