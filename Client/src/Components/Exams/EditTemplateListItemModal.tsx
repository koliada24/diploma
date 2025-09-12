import { Button, Form, Modal } from "react-bootstrap";
import type { ExamTemplate } from "../../Models/Exams/ExamTemplate";
import type { EditExamTemplateDTO } from "../../Models/Exams/EditExamTemplateDTO";
import { useState } from "react";

interface EditTemplateListItemModalProps {
  template: ExamTemplate;
  show: boolean;
  handleHide: () => void;
  editTemplate: (templateId: string, template: EditExamTemplateDTO) => Promise<void>;
  deleteTemplate: (templateId: string) => Promise<void>;
}

export function EditTemplateListItemModal({ template, show, handleHide, editTemplate, deleteTemplate }: EditTemplateListItemModalProps) {
  const [title, setTitle] = useState<string>(template.title);
  const [description, setDescription] = useState<string>(template.description);

  const handleSubmit = async () => {
    await editTemplate(template.id, {title, description});
    handleHide();
  }
  
  const handleDelete = async () => {
    await deleteTemplate(template.id);
    handleHide();
  }

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
          <Form.Control
            placeholder="Title"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
          />
        </Form.Group>

        <Form.Group controlId="examtemplateform.description">
          <Form.Label>Exam Description</Form.Label>
          <Form.Control
            placeholder="Description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />
        </Form.Group>
        
      </Modal.Body>

      <Modal.Footer className="justify-content-between">
        <div className="d-flex justify-content-start">
          <Button variant="danger" onClick={handleDelete}>Delete</Button>
        </div>
        <div className="d-flex justify-content-end">
          <Button variant="outline-secondary text-dark" className="me-2" onClick={handleHide}>Cancel</Button>
          <Button variant="primary" onClick={handleSubmit}>Submit</Button>
        </div>
      </Modal.Footer>
    </Modal>
  );
} 