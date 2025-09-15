import { useState } from "react";
import axios from "../../axios";
import config from "../../config";
import type { ExamTemplate } from "../../Models/Exams/ExamTemplate";
import type { CreateExamTemplateDTO } from "../../Models/Exams/CreateExamTemplateDTO";
import type { EditExamTemplateDTO } from "../../Models/Exams/EditExamTemplateDTO";

interface useExamTemplatesResult {
  templates: ExamTemplate[];
  fetchTemplates: () => Promise<void>;
  addTemplate: (template: CreateExamTemplateDTO) => Promise<void>;
  editTemplate: (templateId: string, template: EditExamTemplateDTO) => Promise<void>;
  deleteTemplate: (templateId: string) => Promise<void>;
}

export function useExamTemplates(): useExamTemplatesResult {
  const [templates, setTemplates] = useState<ExamTemplate[]>([]);
  
  const fetchTemplates = async () => {
    try {
      const responce = await axios.get<ExamTemplate[]>(`${config.apiUrl}/templates`);
    
      if (responce.status == 200) {
        setTemplates(responce.data);
      }
    }
    catch {
      // TODO: handle failed responce
    }
  };

  const addTemplate = async (template: CreateExamTemplateDTO) => {
    try {
      const responce = await axios.post<string>(`${config.apiUrl}/templates`, template);
    
      if (responce.status == 200) {
        fetchTemplates();
      }
    }
    catch {
      // TODO: handle failed responce
    }
  };

  const editTemplate = async (templateId: string, template: EditExamTemplateDTO) => {
    try {
      const responce = await axios.put(`${config.apiUrl}/templates/${templateId}`, template);
    
      if (responce.status == 200) {
        fetchTemplates();
      }
    }
    catch {
      // TODO: handle failed responce
    }
  };

  const deleteTemplate = async (templateId: string) => {
    try {
      const responce = await axios.delete<string>(`${config.apiUrl}/templates/${templateId}`);
    
      if (responce.status == 200) {
        fetchTemplates();
      }
    }
    catch {
      // TODO: handle failed responce
    }
  };

  return {
    templates: templates,
    fetchTemplates: fetchTemplates,
    addTemplate: addTemplate,
    editTemplate: editTemplate,
    deleteTemplate: deleteTemplate
  }
}