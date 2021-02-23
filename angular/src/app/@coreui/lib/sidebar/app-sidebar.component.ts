import { Component, OnInit } from '@angular/core';
import { navItems } from 'src/app/config/menu/nav-left';
import { INavData } from './app-sidebar-nav';

@Component({
  selector: 'app-sidebar',
  templateUrl: './app-sidebar.component.html',
  styleUrls: ['./app-sidebar.component.scss']
})
export class AppSidebarComponent implements OnInit {
  public navItems: INavData[] = navItems;

  constructor(
  ) { }

  ngOnInit(): void {
    console.log(this.navItems)
  }

}
