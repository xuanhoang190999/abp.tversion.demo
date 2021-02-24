import { INavData } from "src/app/@coreui/lib/sidebar/app-sidebar-nav";


export const navItems: INavData[] = [
  {
    name: 'Trang chủ',
    url: '',
    title: 'Trang chủ',
    icon: '<span class="tpi-icon-menu"><i class="fa fa-home" aria-hidden="true"></i></span>',
    isHidden: false,
  },
  {
    name: 'Nhà phát hành',
    title: 'Nhà phát hành',
    icon: '<span class="tpi-icon-menu"><i class="fa fa-home" aria-hidden="true"></i></span>',
    isHidden: false,
    childrens: [
      {
        name: 'Thông tin',
        url: '/releases'
      },
      {
        name: 'Ứng dụng',
        url: '/releases/packages'
      },
      {
        name: 'Phiên bản',
        url: '/releases/changelogs'
      }
    ]
  },
  {
    name: 'Thông tin',
    url: '/information',
    title: 'Thông tin',
    icon: '<span class="tpi-icon-menu"><i class="fa fa-home" aria-hidden="true"></i></span>',
    isHidden: false,
  },
  {
    name: 'Liên hệ',
    url: '/contact',
    title: 'Liên hệ',
    icon: '<span class="tpi-icon-menu"><i class="fa fa-home" aria-hidden="true"></i></span>',
    isHidden: false,
  },
  // {
  //   name: 'Đăng xuất',
  //   url: '/login',
  //   title: 'Đăng xuất',
  //   icon: '<span class="tpi-icon-menu"><i class="fa fa-home" aria-hidden="true"></i></span>',
  //   isHidden: false,
  // }
]
