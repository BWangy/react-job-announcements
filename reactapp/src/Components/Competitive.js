import React, { useState, useEffect } from "react";
import MaterialTable from "material-table";
import { ThemeProvider, createTheme } from '@mui/material';
import { Link } from "react-router-dom"

const Competitive = () => {
    // State to store the fetched data
    const [jobs, setJobs] = useState(null);
    // State to store loading state
    const [loading, setLoading] = useState(true);
    // State to store any error that may occur during fetch
    const [error, setError] = useState(null);

    // useEffect to fetch data asynchronously
    useEffect(() => {
        // Define an async function to perform the fetch
        const fetchData = async () => {
            try {
                const response = await fetch("https://localhost:7207/api/Competitive");
                if (!response.ok) {
                    throw new Error("Network response was not ok");
                }
                const data = await response.json();
                setJobs(data);
                setLoading(false);
            } catch (error) {
                setError(error.message);
                setLoading(false);
            }
        };

        // Call the async function to fetch the data
        fetchData();
    }, []); // Empty dependency array ensures it runs only once on component mount

    // Render the component based on loading and error states
    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    const columns = [
        { title: "Title", field: "title", render: rowData => (<Link to={`/ApplyCompetitive?id=${rowData.identifier}`}> {rowData.title} </Link>) },
        { title: "Closing Date", field: "strClosingDate" },
        { title: "Application Fee", field: "applicationFee" },
        { title: "Department", field: "department" },
    ];

    const defaultMaterialTheme = createTheme();

    return (
        <div className="container p-5" style={{ maxWidth: "100%" }} >
            <link
                rel="stylesheet"
                href="https://fonts.googleapis.com/icon?family=Material+Icons"
            />
            <ThemeProvider theme={defaultMaterialTheme}>
                <MaterialTable columns={columns} data={jobs} title="Competitive Jobs" />
            </ThemeProvider>
        </div>    
        
    );
 };

export default Competitive;
