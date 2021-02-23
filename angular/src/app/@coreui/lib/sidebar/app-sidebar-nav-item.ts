import { Component, Input, OnInit } from '@angular/core';
import { SidebarNavHelper } from './sidebar.service';

@Component({
  selector: 'app-sidebar-nav-item',
  template: `
      <li (click)="item.isHidden=!item.isHidden" class="nav-item">

        <span *ngIf='helper.hasChildrens(item)' class="tpi-icon">
          <i class="fa fa-chevron-{{item.isHidden ? 'down' : 'right'}}" aria-hidden="true"></i>
        </span>
        <span *ngIf='!helper.hasChildrens(item)' class="tpi-icon">
          <i class="fa fa-long-arrow-right" aria-hidden="true"></i>
        </span>

        <a class="tpi-name" routerLinkActive="active" [routerLink]="item.url">{{item.name}}</a>

        <!-- child -->
        <div *ngIf='helper.hasChildrens(item) && item.isHidden'>
          <ul *ngFor='let child of item.childrens' class="tpi-name-child">
            <a routerLinkActive="active" [routerLink]="child.url">{{child.name}}</a>
          </ul>
        </div>
      </li>
  `,
  styleUrls: ['./app-sidebar.component.scss']
})
export class AppSidebarNavItemComponent implements OnInit {
  @Input() item: any;

  constructor(public helper: SidebarNavHelper) {
    console.log(this.item)
   }

  ngOnInit(): void {

  }

}
