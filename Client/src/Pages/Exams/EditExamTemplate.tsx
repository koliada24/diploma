import { useNavigate, useParams } from "react-router-dom";
import { MenuLayout } from "../Layouts/MenuLayout/MenuLayout";
import { Button, Form } from "react-bootstrap";
import { useEffect, useState } from "react";
import { useExamTemplates } from "../../Hooks/Exams/useExamTemplates";
import { ConfirmDeletionModal } from "./ConfirmDeletionModal";

export function EditExamTemplate() {
  const { id } = useParams<{id: string}>();
  const { getTemplateById, deleteTemplate, editTemplate } = useExamTemplates();
  const navigate = useNavigate();
  
  const [title, setTitle] = useState<string>('');
  const [newTitle, setNewTitle] = useState<string>('');
  const [newDescription, setNewDescription] = useState<string>('');
  const [showConfirmDeletionModal, setShowConfirmDeletionModal] = useState<boolean>(false);

  useEffect(() => {
    const fetchData = async () => {
      const template = await getTemplateById(id ?? ' '); 
      if (template) {
        setTitle(template.title);
        setNewTitle(template.title);
        setNewDescription(template.description);
      }
    };
    fetchData();
  }, []);

  const handleSubmit = async () => {
    await editTemplate(id ?? '', { title: newTitle, description: newDescription });
    navigate('/templates');
  }
  
  const handleDelete = async () => {
    await deleteTemplate(id ?? '');
    navigate('/templates');
  }

  return (
    <MenuLayout>
        <ConfirmDeletionModal 
          show={showConfirmDeletionModal}
          handleHide={() => setShowConfirmDeletionModal(false)}
          handleConfirm={handleDelete}
        />
        <h4>Editing {title}</h4>
        <hr/>

        <Form.Group className="mb-3" controlId="examtemplateform.title">
          <Form.Label>Title</Form.Label>
          <Form.Control
            placeholder="Title"
            value={newTitle}
            onChange={(e) => setNewTitle(e.target.value)}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="examtemplateform.description">
          <Form.Label>Exam Description</Form.Label>
          <Form.Control
            placeholder="Description"
            value={newDescription}
            onChange={(e) => setNewDescription(e.target.value)}
          />
        </Form.Group>

        <div className="d-flex justify-content-between">
          <div className="d-flex justify-content-start">
            <Button variant="danger" onClick={() => setShowConfirmDeletionModal(true)}>Delete</Button>
          </div>

          <div className="d-flex justify-content-end">
            <Button 
              variant="outline-secondary text-dark"
              className="me-2"
              onClick={() => navigate('/templates')}
            >Cancel</Button>
            
            <Button
              variant="primary"
              onClick={handleSubmit}
            >Submit</Button>
          </div>
        </div>
    </MenuLayout>
  );
}