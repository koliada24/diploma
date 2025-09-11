import { ExamTemplatesGrid } from "../../Components/Exams/ExamTemplatesGrid";
import { ExamTemplatesHeader } from "../../Components/Exams/ExamTemplatesHeader";
import { MenuLayout } from "../Layouts/MenuLayout/MenuLayout";

export function ExamTemplates() {
  return (
    <MenuLayout>
      <ExamTemplatesHeader />
      <ExamTemplatesGrid />
    </MenuLayout>
  );
}