import { Col, ListGroup, Row } from "react-bootstrap";
import type { ExamTemplate } from "../../Models/Exams/ExamTemplate";
import { useState } from "react";
import { EditTemplateListItemModal } from "./EditTemplateListItemModal";
import type { EditExamTemplateDTO } from "../../Models/Exams/EditExamTemplateDTO";

interface ExamTemplateListItemProps {
  template: ExamTemplate;
  editTemplate: (templateId: string, template: EditExamTemplateDTO) => Promise<void>;
  deleteTemplate: (templateId: string) => Promise<void>;
}

export function ExamTemplateListItem({ template, editTemplate, deleteTemplate }: ExamTemplateListItemProps) {
  const { title, description, questionCount } = {...template};
  console.log(description);
  const [ showEditExamTemplateModal, setShowEditExamTemplateModal ] = useState<boolean>(false);

  return(
    <>
      <EditTemplateListItemModal
        template={template}
        show={showEditExamTemplateModal}
        handleHide={() => setShowEditExamTemplateModal(false)}
        editTemplate={editTemplate}
        deleteTemplate={deleteTemplate}
      />
      <ListGroup.Item action onClick={() => setShowEditExamTemplateModal(true)}>
        <Row>
          <Col xs={3}>{title}</Col>
          <Col xs={8}>{description}</Col>
          <Col xs={1} className="d-flex justify-content-center">{questionCount}</Col>
        </Row>
      </ListGroup.Item>
    </>
  );
}