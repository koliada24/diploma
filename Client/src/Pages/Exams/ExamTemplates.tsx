import { useState } from "react";
import { ExamTemplatesGrid } from "../../Components/Exams/ExamTemplatesGrid";
import { ExamTemplatesHeader } from "../../Components/Exams/ExamTemplatesHeader";
import { MenuLayout } from "../Layouts/MenuLayout/MenuLayout";
import { AddExamTemplateModal } from "../../Components/Exams/AddExamTemplateModal";
import { useExamTemplates } from "../../Hooks/Exams/useExamTemplates";

export function ExamTemplates() {
  const [showAddExamTemplateModal, setShowAddExamTemplateModal] = useState<boolean>(false);

  const { templates, fetchTemplates, addTemplate } = useExamTemplates();

  return (
    <MenuLayout>
      <AddExamTemplateModal
        show={showAddExamTemplateModal}
        handleHide={() => setShowAddExamTemplateModal(false)} 
        addTemplate={addTemplate}
      />
      <ExamTemplatesHeader
        handleShowAddExamTemplateModal={() => setShowAddExamTemplateModal(true)}
      />
      <ExamTemplatesGrid
        templates={templates}
        fetchTemplates={fetchTemplates}
      />
    </MenuLayout>
  );
}