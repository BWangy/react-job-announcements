import React from "react";
import "./App.css";
import Navigation from "./Components/Navigation";
import { Routes, Route } from "react-router-dom";
import "./App.css";
import Home from "./Components/Home";
import NonCompetitive from "./Components/NonCompetitive";
import AddCompetitive from "./Components/AddCompetitive";
import AddNonCompetitive from "./Components/AddNonCompetitive";
import Contact from "./Components/Contact";
import Competitive from "./Components/Competitive";
import ApplyCompetitive from "./Components/ApplyCompetitive";
import ApplyNonCompetitive from "./Components/ApplyNonCompetitive";

const App = () => {
    return (
        <>
            <Navigation />
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/Competitive" element={<Competitive />} />
                <Route path="/ApplyCompetitive" element={<ApplyCompetitive />} />
                <Route path="/ApplyNonCompetitive" element={<ApplyNonCompetitive />} />
                <Route path="/NonCompetitive" element={<NonCompetitive />} />
                <Route path="/AddCompetitive" element={<AddCompetitive />} />
                <Route path="/AddNonCompetitive" element={<AddNonCompetitive />} />
                <Route path="/Contact" element={<Contact />} />
            </Routes>
        </>
    );
};

export default App;
