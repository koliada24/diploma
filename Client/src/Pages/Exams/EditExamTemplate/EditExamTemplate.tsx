import { MenuLayout } from "../../Layouts/MenuLayout/MenuLayout";
import { EditExamTemplateGeneral } from "./EditExamTemplateGeneral";
import { useParams } from "react-router-dom";
import { useEditExamTemplateGeneral } from "../../../Hooks/Exams/useEditExamTemplateGeneral";
import { EditExamTemplateQuestions } from "./EditExamTemplateQuestions";
import { EditExamTemaplateFooter } from "./EditExamTemaplateFooter";

export function EditExamTemplate() {
  const { id } = useParams<{id: string}>();
  const { currentTitle, newTitle, setNewTitle, newDescription, setNewDescription } = useEditExamTemplateGeneral({id: id ?? ''});

  return (
    <>
      <MenuLayout>
        <h4 className="mb-3">Editing {currentTitle}</h4>
        <EditExamTemplateGeneral
          newTitle={newTitle}
          setNewTitle={setNewTitle}
          newDescription={newDescription}
          setNewDescription={setNewDescription}
        />
        <EditExamTemplateQuestions />
        <EditExamTemaplateFooter
          newTitle={newTitle}
          newDescription={newDescription}
        />
      </MenuLayout>
    </>
  );
}