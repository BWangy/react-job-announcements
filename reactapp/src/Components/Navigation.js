import React from "react";
import { NavDropdown, Navbar, NavbarBrand } from "react-bootstrap";
import { Nav } from "react-bootstrap";
import { Container } from "react-bootstrap";
import "./Navbar.css";
import { Link } from "react-router-dom"; // Import the Link component

const Navigation = () => {
    return (
        <Navbar
            expand="lg"
            className="navbar-light border-bottom box-shadow mb-3"
            style={{ backgroundColor: "#EFEFEF" }}
        >
            <Container>
                <NavbarBrand as={Link} to="/"> {/* Use Link component for the NavbarBrand */}
                    <img
                        src="https://dynamiclearningmaps.org/sites/default/files/pictures/states/NJ_state.png"
                        alt="New Jersey"
                    />
                </NavbarBrand>
                <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <Nav className="flex-grow-1">
                        <NavDropdown title="Postings">
                            <NavDropdown.Item as={Link} to="/Competitive"> {/* Use Link component */}
                                <span style={{ color: "#015498" }}>Competitive</span>
                            </NavDropdown.Item>
                            <NavDropdown.Item as={Link} to="/NonCompetitive"> {/* Use Link component */}
                                <span style={{ color: "#015498" }}>Non-Competitive</span>
                            </NavDropdown.Item>
                        </NavDropdown>
                        <NavDropdown title="Add New">
                            <NavDropdown.Item as={Link} to="/AddCompetitive"> {/* Use Link component */}
                                <span style={{ color: "#015498" }}>Competitive</span>
                            </NavDropdown.Item>
                            <NavDropdown.Item as={Link} to="/AddNonCompetitive"> {/* Use Link component */}
                                <span style={{ color: "#015498" }}>Non-Competitive</span>
                            </NavDropdown.Item>
                        </NavDropdown>
                        <Nav.Link className="text-dark" as={Link} to="/Contact"> {/* Use Link component */}
                            Contact Us
                        </Nav.Link>
                    </Nav>
                    <h1 id="navbarText" className="fs-2 fw-bold custom-blue">
                        Job Announcements
                    </h1>
                </div>
            </Container>
        </Navbar>
    );
};

export default Navigation;
