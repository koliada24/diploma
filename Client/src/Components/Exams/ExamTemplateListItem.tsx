import { Col, ListGroup, Row } from "react-bootstrap";
import type { ExamTemplate } from "../../Models/Exams/ExamTemplate";
import { useNavigate } from "react-router-dom";

interface ExamTemplateListItemProps {
  template: ExamTemplate;
}

export function ExamTemplateListItem({ template }: ExamTemplateListItemProps) {
  const { title, description, questionCount } = {...template};
  const navigate = useNavigate();

  return(
    <ListGroup.Item action onClick={() => navigate(`/templates/edit/${template.id}`)}>
      <Row>
        <Col xs={3}>{title}</Col>
        <Col xs={8}>{description}</Col>
        <Col xs={1} className="d-flex justify-content-center">{questionCount}</Col>
      </Row>
    </ListGroup.Item>
  );
}