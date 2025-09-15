import { useParams } from "react-router-dom";
import { MenuLayout } from "../Layouts/MenuLayout/MenuLayout";

export function EditExamTemplate() {
  const { id } = useParams<{id: string}>();

  return (
    <MenuLayout>
      {id}
    </MenuLayout>
  );
}