import { Button, Form, Modal } from "react-bootstrap";
import type { ExamTemplate } from "../../Models/Exams/ExamTemplate";

interface EditTemplateListItemModalProps {
  template: ExamTemplate;
  show: boolean;
  handleHide: () => void;
  handleSubmit: () => void;
}

export function EditTemplateListItemModal({ template, show, handleHide, handleSubmit }: EditTemplateListItemModalProps) {
  return (
    <Modal
      show={show}
      aria-labelledby="contained-modal-title-vcenter"
      onHide={handleHide}
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Editing Exam Template
        </Modal.Title>
      </Modal.Header>

      <Modal.Body>

        <Form.Group className="mb-3" controlId="examtemplateform.title">
          <Form.Label>Title</Form.Label>
          <Form.Control placeholder="Title" value={template.title} />
        </Form.Group>

        <Form.Group controlId="examtemplateform.description">
          <Form.Label>Exam Description</Form.Label>
          <Form.Control placeholder="Description" value={template.description} />
        </Form.Group>
        
      </Modal.Body>

      <Modal.Footer className="justify-content-between">
        <div className="d-flex justify-content-start">
          <Button variant="danger" onClick={handleSubmit}>Delete</Button>
        </div>
        <div className="d-flex justify-content-end">
          <Button variant="outline-secondary text-dark" className="me-2" onClick={handleHide}>Cancel</Button>
          <Button variant="primary" onClick={handleSubmit}>Submit</Button>
        </div>
      </Modal.Footer>
    </Modal>
  );
} 