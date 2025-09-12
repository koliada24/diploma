import { Button, Form, Modal } from "react-bootstrap";

interface AddExamTemplateModalProps {
  show: boolean;
  handleHide: () => void;
  handleSubmit: () => void;
}

export function AddExamTemplateModal({ show, handleHide, handleSubmit }: AddExamTemplateModalProps) {
  return (
    <Modal
      show={show}
      aria-labelledby="contained-modal-title-vcenter"
      onHide={handleHide}
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Adding Exam Template
        </Modal.Title>
      </Modal.Header>

      <Modal.Body>

        <Form.Group className="mb-3" controlId="examtemplateform.title">
          <Form.Label>Title</Form.Label>
          <Form.Control placeholder="Title" />
        </Form.Group>

        <Form.Group controlId="examtemplateform.description">
          <Form.Label>Exam Description</Form.Label>
          <Form.Control placeholder="Description" />
        </Form.Group>
        
      </Modal.Body>

      <Modal.Footer>
        <Button variant="outline-secondary text-dark" onClick={handleHide}>Cancel</Button>
        <Button onClick={handleSubmit}>Submit</Button>
      </Modal.Footer>
    </Modal>
  );
}