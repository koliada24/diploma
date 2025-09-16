import { useEffect, useState } from "react";
import { useExamTemplates } from "./useExamTemplates";

interface useEditExamTemplateProps {
  id: string
}

interface useEditExamTemplateResult {
  currentTitle: string;
  newTitle: string;
  setNewTitle: (title: string) => void;
  newDescription: string;
  setNewDescription: (title: string) => void;
}

export function useEditExamTemplate({ id }: useEditExamTemplateProps): useEditExamTemplateResult {
  const [currentTitle, setCurrentTitle] = useState<string>('');
  const [newTitle, setNewTitle] = useState<string>('');
  const [newDescription, setNewDescription] = useState<string>('');
  const { getTemplateById } = useExamTemplates();

  useEffect(() => {
    const fetchData = async () => {
      const template = await getTemplateById(id ?? ' '); 
      if (template) {
        setCurrentTitle(template.title);
        setNewTitle(template.title);
        setNewDescription(template.description);
      }
    };
    fetchData();
  }, []);

  return {
    currentTitle,
    newTitle,
    setNewTitle,
    newDescription,
    setNewDescription
  };
}