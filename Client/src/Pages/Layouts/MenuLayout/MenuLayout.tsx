import { MenuLayoutContent } from "./MenuLayoutContent/MenuLayoutContent";
import { MenuLayoutHeader } from "./MenuLayoutHeader/MenuLayoutHeader";
import { MenuLayoutSidebar } from "./MenuLayoutSidebar/MenuLayoutSidebar";

interface MenuLayoutProps {
  children: any;
}

export function MenuLayout({ children }: MenuLayoutProps) {
  return (
    <>
      <div className="d-flex">
        <MenuLayoutSidebar />
        <div className="p-0 w-100 margin-left-15-percent">
          <MenuLayoutHeader />
          <MenuLayoutContent children={children} />
        </div>
      </div>
    </>
  );
}