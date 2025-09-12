import { Col, ListGroup, Row } from "react-bootstrap";
import type { ExamTemplate } from "../../Models/Exams/ExamTemplate";

export function ExamTemplateListItem({ template }: { template: ExamTemplate }) {
  const { title, description, questionCount } = {...template};

  return(
    <ListGroup.Item action>
      <Row>
        <Col xs={3}>{title}</Col>
        <Col xs={8}>{description}</Col>
        <Col xs={1} className="d-flex justify-content-center">{questionCount}</Col>
      </Row>
    </ListGroup.Item>
  );
}