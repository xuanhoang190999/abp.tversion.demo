import { Injectable } from '@angular/core';

@Injectable()
export class SidebarNavHelper {

  public hasUrl = (item) => Boolean(item.url);
  public hasChildrens = (item) => Boolean(item.childrens);

}
