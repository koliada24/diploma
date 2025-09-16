import { useEffect, useState } from "react";
import { MenuLayout } from "../../Layouts/MenuLayout/MenuLayout";
import { EditExamTemplateGeneral } from "./EditExamTemplateGeneral";
import { Nav } from "react-bootstrap";
import { useParams } from "react-router-dom";
import { useExamTemplates } from "../../../Hooks/Exams/useExamTemplates";

enum EditExamTemplateTabs {
  General,
  Questions
}

export function EditExamTemplate() {
  const { id } = useParams<{id: string}>();
  const { getTemplateById } = useExamTemplates();
  
  const [title, setTitle] = useState<string>('');

  useEffect(() => {
    const fetchData = async () => {
      const template = await getTemplateById(id ?? ' '); 
      if (template) {
        setTitle(template.title);
      }
    };
    fetchData();
  }, []);

  const [activeTab, setActiveTab] = useState<EditExamTemplateTabs>(EditExamTemplateTabs.General);

  const handleTabSelect = (key: string | null) => {
    if (key && key in EditExamTemplateTabs) {
      setActiveTab(Number(key) as unknown as EditExamTemplateTabs);
    }
  };

  const renderTabContent = (activeTab: EditExamTemplateTabs) => {
    switch (activeTab as EditExamTemplateTabs) {
      case EditExamTemplateTabs.General:
        return <EditExamTemplateGeneral />;
      case EditExamTemplateTabs.Questions:
        return <>EditExamTemplateTabs.Questions</>;
      default:
        return <>Unknown page</>;
    }
  };

  return (
    <>
      <MenuLayout>
        <h4 className="mb-3">Editing {title}</h4>
        

        <Nav
          variant="tabs"
          className="mb-3"
          activeKey={activeTab}
          onSelect={(key) => handleTabSelect(key)}
        >
          <Nav.Item>
            <Nav.Link eventKey={EditExamTemplateTabs.General}>General</Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link eventKey={EditExamTemplateTabs.Questions}>Questions</Nav.Link>
          </Nav.Item>
        </Nav>
        {renderTabContent(activeTab as EditExamTemplateTabs)}
      </MenuLayout>
    </>
  );
}