export interface INavData {
  name?: string;
  url?: string | any[];
  href?: string;
  icon?: string;
  title?: string;
  childrens?: INavData[];
  class?: string;
  isHidden?: boolean;
}
