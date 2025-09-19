import { Button } from "react-bootstrap";
import { useExamTemplates } from "../../../Hooks/Exams/useExamTemplates";
import { useNavigate, useParams } from "react-router-dom";
import { ConfirmDeletionModal } from "../../../Components/Exams/EditExamTemplate/General/ConfirmDeletionModal";
import { useState } from "react";

interface EditExamTemaplateFooterProps {
  newTitle: string;
  newDescription: string;
}

export function EditExamTemaplateFooter({ newTitle, newDescription }: EditExamTemaplateFooterProps) {
  const [showConfirmDeletionModal, setShowConfirmDeletionModal] = useState<boolean>(false);
  const { deleteTemplate, editTemplate } = useExamTemplates();
  const navigate = useNavigate();
  const { id } = useParams<{id: string}>();

  const handleSubmit = async () => {
    await editTemplate(id ?? '', { title: newTitle, description: newDescription });
    navigate('/templates');
  }
  
  const handleDelete = async () => {
    await deleteTemplate(id ?? '');
    navigate('/templates');
  }

  return (
    <>
      <ConfirmDeletionModal
        show={showConfirmDeletionModal}
        handleHide={() => setShowConfirmDeletionModal(false)}
        handleConfirm={handleDelete}
      />
      <div className="d-flex justify-content-between mb-3">
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
    </>
  );
}