import { Button, Modal } from "react-bootstrap";

interface ConfirmDeletionModalProps {
  show: boolean;
  handleHide: () => void;
  handleConfirm: () => Promise<void>;
}

export function ConfirmDeletionModal({ show, handleHide, handleConfirm }: ConfirmDeletionModalProps) {
  return (
    <Modal
      show={show}
      onHide={handleHide}
      centered
    >
      <Modal.Header>
        <Modal.Title>Confirm template deletion</Modal.Title>
      </Modal.Header>

      <Modal.Body>
        Do you really want to delete this template?
      </Modal.Body>

      <Modal.Footer>
        <Button 
          variant="outline-secondary"
          onClick={handleHide}>Cancel</Button>
        
        <Button
        variant="danger"
        onClick={handleConfirm}>Delete</Button>
      </Modal.Footer>
    </Modal>
  );
}