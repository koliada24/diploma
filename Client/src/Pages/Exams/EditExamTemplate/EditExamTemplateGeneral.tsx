import { Form } from "react-bootstrap";

interface EditExamTemplateGeneralProps {
  newTitle: string;
  setNewTitle: (title: string) => void;
  newDescription: string;
  setNewDescription: (title: string) => void;
}

export function EditExamTemplateGeneral({ newTitle, setNewTitle, newDescription, setNewDescription }: EditExamTemplateGeneralProps) {
  return (
    <>
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
    </>
  );
}