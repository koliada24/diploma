import { useState } from "react";
import { ExamTemplatesGrid } from "../../Components/Exams/ExamTemplatesGrid";
import { ExamTemplatesHeader } from "../../Components/Exams/ExamTemplatesHeader";
import { MenuLayout } from "../Layouts/MenuLayout/MenuLayout";
import { AddExamTemplateModal } from "../../Components/Exams/AddExamTemplateModal";

export function ExamTemplates() {
  const [showAddExamTemplateModal, setShowAddExamTemplateModal] = useState<boolean>(false);

  return (
    <MenuLayout>
      <AddExamTemplateModal
        show={showAddExamTemplateModal}
        handleHide={() => setShowAddExamTemplateModal(false)} 
        handleSubmit={() => setShowAddExamTemplateModal(false)} 
      />
      <ExamTemplatesHeader 
        handleShowAddExamTemplateModal={() => setShowAddExamTemplateModal(true)}
      />
      <ExamTemplatesGrid />
    </MenuLayout>
  );
}