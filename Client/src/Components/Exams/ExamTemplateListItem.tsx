import { Col, ListGroup, Row } from "react-bootstrap";
import type { ExamTemplate } from "../../Models/Exams/ExamTemplate";
import { useState } from "react";
import { EditTemplateListItemModal } from "./EditTemplateListItemModal";

export function ExamTemplateListItem({ template }: { template: ExamTemplate }) {
  const { title, description, questionCount } = {...template};
  const [ showEditExamTemplateModal, setShowEditExamTemplateModal ] = useState<boolean>(false);

  return(
    <>
      <EditTemplateListItemModal
        template={template}
        show={showEditExamTemplateModal}
        handleHide={() => setShowEditExamTemplateModal(false)}
        handleSubmit={() => setShowEditExamTemplateModal(false)}
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