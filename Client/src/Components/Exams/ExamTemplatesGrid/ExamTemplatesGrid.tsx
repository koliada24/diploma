import { Col, ListGroup, Row } from "react-bootstrap";
import { ExamTemplateListItem } from "./ExamTemplateListItem";
import { useEffect } from "react";
import type { ExamTemplate } from "../../../Models/Exams/ExamTemplate";

interface ExamTemplatesGridProps {
  templates: ExamTemplate[];
  fetchTemplates: () => Promise<void>;
}

export function ExamTemplatesGrid({ templates, fetchTemplates }: ExamTemplatesGridProps) {
  useEffect(() => {
    fetchTemplates();
  }, [])

  return (
    <>
      <ListGroup defaultActiveKey="#link1">
        <ListGroup.Item>
          <Row className="align-items-center">
            <Col xs={3} className="fw-semibold">
              Title
            </Col>
            <Col xs={8} className="fw-semibold">
              Description
            </Col>
            <Col xs={1} className="d-flex justify-content-center fw-semibold">
              Questions
            </Col>
          </Row>
        </ListGroup.Item>
        {templates.map(template => <ExamTemplateListItem 
          template={template}
        />)}
      </ListGroup>
    </>
  )
}