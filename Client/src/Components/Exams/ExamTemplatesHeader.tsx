import { Button, Container } from "react-bootstrap";

interface ExamTemplatesHeaderProps {
  handleShowAddExamTemplateModal: () => void;
}

export function ExamTemplatesHeader({ handleShowAddExamTemplateModal }: ExamTemplatesHeaderProps) {
  return (
    <Container className="d-flex mb-3 p-0">
      <Button className="ms-auto" onClick={handleShowAddExamTemplateModal}>Add Template</Button>
    </Container>
  );
}