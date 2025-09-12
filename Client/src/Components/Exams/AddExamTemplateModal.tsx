import { Button, Form, Modal } from "react-bootstrap";
import type { CreateExamTemplateDTO } from "../../Models/Exams/CreateExamTemplateDTO";
import { useState } from "react";

interface AddExamTemplateModalProps {
  show: boolean;
  handleHide: () => void;
  addTemplate: (template: CreateExamTemplateDTO) => Promise<void>;
}

export function AddExamTemplateModal({ show, handleHide, addTemplate }: AddExamTemplateModalProps) {
  const [title, setTitle] = useState<string>('');
  const [description, setDescription] = useState<string>('');

  const handleSubmit = () => {
    addTemplate({title, description});
    onHide();
  }

  const onHide = () => {
    setTitle('');
    setDescription('');
    handleHide();
  }
  
  return (
    <Modal
      show={show}
      aria-labelledby="contained-modal-title-vcenter"
      onHide={onHide}
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
          <Form.Control 
            onChange={(e) => setTitle(e.target.value)}
            value={title} 
            placeholder="Title"
          />
        </Form.Group>

        <Form.Group controlId="examtemplateform.description">
          <Form.Label>Exam Description</Form.Label>
          <Form.Control
            onChange={(e) => setDescription(e.target.value)}
            value={description}
            placeholder="Description"
          />
        </Form.Group>
        
      </Modal.Body>

      <Modal.Footer>
        <Button variant="outline-secondary text-dark" onClick={onHide}>Cancel</Button>
        <Button onClick={handleSubmit}>Submit</Button>
      </Modal.Footer>
    </Modal>
  );
}