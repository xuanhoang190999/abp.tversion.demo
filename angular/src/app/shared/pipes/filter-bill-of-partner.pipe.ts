import { OnChanges, OnInit, Pipe, PipeTransform, SecurityContext, SimpleChanges } from "@angular/core";
import { DomSanitizer } from "@angular/platform-browser";
import * as _ from "lodash";

@Pipe({
  name: "filterBillOfPartner",
})
export class FilterBillOfPartner implements PipeTransform {
  transform(billOfPartner: any[], searchSelect: string, searchText: string): any[] {
    if (billOfPartner.length >0) {
      searchSelect = searchSelect.toLocaleLowerCase().trim();
      searchText = String(searchText).toLocaleLowerCase().trim();
      return _.filter(billOfPartner,function(item){
          return String(item.ShowState).toLowerCase().includes(searchSelect) && String(item.Number).toLowerCase().includes(searchText);
      });
    }
  }
}
