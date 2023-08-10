import React, { useState, useEffect } from "react";
import { Button } from "react-bootstrap";
import Form from "react-bootstrap/Form"
import Modal from 'react-bootstrap/Modal';

const AddCompetitive = () => {

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);

    const [formData, setFormData] = useState({
        title: '',
        openDate: '',
        closingDate: '',
        applicationFee: '',
        departmentId: '1',
    });

    const [departmentOptions, setDepartmentOptions] = useState([]);

    // Fetch data from the API when the component mounts
    useEffect(() => {
        fetchDepartmentOptions();
    }, []);

    // Function to fetch department options from the API
    const fetchDepartmentOptions = async () => {
        try {
            const response = await fetch('https://localhost:7207/api/Department');
            if (!response.ok) {
                throw new Error('Failed to fetch department options');
            }
            const data = await response.json();
            // Assuming the API returns an array of department objects with id and name properties
            setDepartmentOptions(data);
        } catch (error) {
            console.error(error);
        }
    };

    const resetForm = () => {
        setFormData({
            title: '',
            openDate: '',
            closingDate: '',
            applicationFee: '',
            departmentId: '1',
        });
    };

    const [validated, setValidated] = useState({
        title: false,
        closingDate: false,
        openDate: false,
        applicationFee: false
    });

    const addJob = (e) => {
        e.preventDefault();

        if (
            formData.title.trim() === '' ||
            formData.closingDate.trim() === '' ||
            formData.openDate.trim() === '' ||
            formData.departmentId.trim() === '' ||
            formData.applicationFee.trim() === ''
        ) {
            return;
        }

        fetch("https://localhost:7207/api/Competitive", {
            method: "POST",
            body: JSON.stringify({
                desc: "",
                title: formData.title,
                strClosingDate: "",
                datClosingDate: formData.closingDate,
                datOpenDate: formData.openDate,
                department: "",
                departmentId: formData.departmentId,
                identifier: 0,
                applicationFee: formData.applicationFee,
                restriction: "",
            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            },
        })
            .then((response) => response.json())
            .then((data) => {
                // Handle the response data if needed
                console.log('Response:', data);
                setShow(true);
                resetForm();
            })
            .catch((error) => {
                // Handle errors if the fetch fails
                console.error('Error:', error);
            });
    };

    const validateInput = (value) => {
        return value.trim() !== ""; // Check if the value is not empty after trimming
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        console.log('Updating state:', name, value);

        const isValid = validateInput(value);
        setValidated((prevValidation) => ({ ...prevValidation, [name]: isValid }));

        setFormData((prevFormData) => ({ ...prevFormData, [name]: value }));
    };

    return (
        <>
            <div className="row justify-content-center my-4">
                <div className="col-lg-4">
                    <Form noValidate validated={validated}>
                        <Form.Group className="mb-4">
                            <Form.Label>Title</Form.Label>
                            <Form.Control type="text" name="title" value={formData.title} onChange={handleInputChange} placeholder="Enter title" maxLength="100" required isInvalid={!validated.title} />
                        </Form.Group>

                        <Form.Group className="mb-4">
                            <Form.Label>Open Date</Form.Label>
                            <Form.Control type="date" value={formData.openDate} onChange={handleInputChange} name="openDate" required isInvalid={!validated.openDate} />
                        </Form.Group>

                        <Form.Group className="mb-4">
                            <Form.Label>Closing Date</Form.Label>
                            <Form.Control type="date" name="closingDate" value={formData.closingDate} onChange={handleInputChange} required isInvalid={!validated.closingDate} />
                        </Form.Group>

                        <Form.Group className="mb-4">
                            <Form.Label>Application Fee</Form.Label>
                            <Form.Control type="number" name="applicationFee" value={formData.applicationFee} onChange={handleInputChange} min="0" step="any" maxLength="400" required isInvalid={!validated.applicationFee} />
                        </Form.Group>

                        <Form.Group className="mb-4">
                            <Form.Label>Department</Form.Label>
                            <Form.Select name="departmentId" value={formData.departmentId} onChange={handleInputChange}>
                                {departmentOptions.map((department) => (
                                    <option key={department.item1} value={department.item1}>
                                        {department.item2}
                                    </option>
                                ))}
                            </Form.Select>
                        </Form.Group>

                        <Button
                            className="btn btn-primary mt-2"
                            id="addButton"
                            onClick={addJob}
                            type="submit"
                        >
                            ADD
                        </Button>
                    </Form>
                </div>
            </div>

            <Modal show={show} onHide={handleClose} backdrop="static" keyboard={false}>
                <Modal.Header closeButton>
                    <Modal.Title>Competitive Jobs</Modal.Title>
                </Modal.Header>
                <Modal.Body>Job has been added</Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
};

export default AddCompetitive;
