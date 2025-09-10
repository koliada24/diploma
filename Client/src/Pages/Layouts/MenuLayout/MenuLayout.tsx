import { MenuLayoutHeader } from "./MenuLayoutHeader/MenuLayoutHeader";

interface MenuLayoutProps {
  children: any;
}

export function MenuLayout({ children }: MenuLayoutProps) {
  return (
    <>
      <MenuLayoutHeader />
      {children}
    </>
  );
}