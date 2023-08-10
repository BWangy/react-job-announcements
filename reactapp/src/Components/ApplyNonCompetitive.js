import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import { Button } from "react-bootstrap";
import Form from "react-bootstrap/Form";
import Modal from 'react-bootstrap/Modal';

const ApplyNonCompetitive = () => {
    const location = useLocation();
    const searchParams = new URLSearchParams(location.search);

    const id = searchParams.get('id');
    const [job, setJob] = useState(null);
    const [loading, setLoading] = useState(true);
    const [formData, setFormData] = useState({
        jobId: '',
        firstName: '',
        lastName: '',
        email: '',
        letterToHR: '',
    });
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);

    const resetForm = () => {
        setFormData({
            jobId: '',
            firstName: '',
            lastName: '',
            email: '',
            letterToHR: '',
        });
    };

    const [validated, setValidated] = useState({
        firstName: false,
        lastName: false,
        email: false,
        letterToHR: false
    });

    useEffect(() => {
        const fetchJob = async () => {
            try {
                console.log(id);
                const response = await fetch(`https://localhost:7207/api/ApplyNonCompetitive/?id=${id}`);
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const jobData = await response.json();
                setJob(jobData); // Update state with the fetched job data
                setLoading(false); // Set loading to false once the data is fetched
            } catch (error) {
                console.error('Error fetching job:', error);
                setLoading(false);
            }
        };
        fetchJob();
    }, [id]);

    if (loading) {
        return <div>Loading...</div>; // Show a loading message or spinner while fetching the data
    }

    const applyJob = async (e) => {
        e.preventDefault();

        if (
            formData.firstName.trim() === '' ||
            formData.lastName.trim() === '' ||
            formData.email.trim() === '' ||
            formData.letterToHR.trim() === ''
        ) {
            return;
        }

        const response = await fetch("https://localhost:7207/api/ApplyNonCompetitive", {
            method: "POST",
            body: JSON.stringify({
                jobId: id,
                firstName: formData.firstName,
                lastName: formData.lastName,
                email: formData.email,
                letterToHR: formData.letterToHR,
            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            },
        })

        if (!response.ok) {
            throw new Error(`Request failed with status: ${response.status}`);
        }

        setShow(true);
        resetForm();
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
            <div className="container">
                <p className="fs-4 fw-bold" style={{ color: '#1839B4' }}>You are applying for this job: {job.title}</p>
                <p className="fs-4 fw-bold" style={{ color: '#1839B4' }}>Closing Date: {job.strClosingDate}</p>
                <p className="fs-4 fw-bold" style={{ color: '#1839B4' }}>Restriction: {job.restriction}</p>
                <p className="fs-4 fw-bold" style={{ color: '#1839B4' }}>Department: {job.department}</p>
            </div>

            <div className="container">
                <div className="col-lg-4">
                    <Form noValidate validated={validated}>
                        <Form.Group className="mb-4">
                            <Form.Label>First Name</Form.Label>
                            <Form.Control type="text" name="firstName" value={formData.firstName} onChange={handleInputChange}
                                placeholder="First Name" maxLength="100" required isInvalid={!validated.firstName} />

                        </Form.Group>

                        <Form.Group className="mb-4">
                            <Form.Label>Last Name</Form.Label>
                            <Form.Control type="text" value={formData.lastName} onChange={handleInputChange} name="lastName" placeholder="Last Name" required isInvalid={!validated.lastName} />
                        </Form.Group>

                        <Form.Group className="mb-4">
                            <Form.Label>Email</Form.Label>
                            <Form.Control type="text" name="email" value={formData.email} onChange={handleInputChange} required isInvalid={!validated.email} />
                        </Form.Group>

                        <Form.Group className="mb-4">
                            <Form.Label>Letter To HR</Form.Label>
                            <Form.Control as="textarea" rows={5} cols={50} name="letterToHR" value={formData.letterToHR} onChange={handleInputChange} required isInvalid={!validated.letterToHR} />
                        </Form.Group>
                        <Button
                            className="btn btn-primary mt-2"
                            id="applyButton"
                            onClick={applyJob}
                            type="submit"
                        >
                            Apply
                        </Button>
                    </Form>
                </div>
            </div>

            <Modal show={show} onHide={handleClose} backdrop="static" keyboard={false}>
                <Modal.Header closeButton>
                    <Modal.Title>Job Application</Modal.Title>
                </Modal.Header>
                <Modal.Body>Thank you for applying!</Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
};

export default ApplyNonCompetitive;