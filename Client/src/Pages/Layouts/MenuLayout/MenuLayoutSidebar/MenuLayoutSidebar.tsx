import { Nav } from "react-bootstrap";

export const MenuLayoutSidebar = () => {
  return (
    <div className="bg-body-tertiary border position-fixed h-100 sidebar" style={{ width: "15%" }}>

      <div className="d-flex flex-column justify-content-center align-items-center h-10">
        <a href="/home" className="text-decoration-none text-reset">
          <h4>Platfom name</h4>
        </a>
      </div>

      <Nav defaultActiveKey="/home" className="flex-column ms-3">
        <Nav.Link href="/templates">Exam Templates</Nav.Link>
      </Nav>

    </div>
  );
};