import React, { useState, useEffect } from 'react';  // Importing necessary React hooks
import axios from 'axios';  // Importing axios for making HTTP requests

// Functional component for displaying the list of bowlers in a table
const BowlerTable = () => {
    // State hook to store the list of bowlers fetched from the API
    const [bowlers, setBowlers] = useState([]);

    // useEffect hook to fetch the bowlers data from the API when the component mounts
    useEffect(() => {
        axios.get('http://localhost:5184/api/bowlers')  // Correct API URL
            .then(response => {
                // Set the fetched data to the bowlers state
                setBowlers(response.data);  // Assuming the API returns an array of bowler objects
            })
            .catch(error => {
                // If there's an error during the API request, log it to the console
                console.error("There was an error fetching the bowlers!", error);
            });
    }, []);  // Empty dependency array means the effect runs only once when the component mounts

    return (
        // Main container for the table, Bootstrap class for margin-top and spacing
        <div className="container mt-4">
            {/* Heading for the table */}
            <h2 className="text-center mb-4">Bowler Information</h2>

            {/* Table structure using Bootstrap classes */}
            <table className="table table-bordered">
                {/* Table header with column names */}
                <thead className="thead-dark">
                    <tr>
                        <th>First Name</th>
                        <th>Middle Name</th>
                        <th>Last Name</th>
                        <th>Team Name</th>
                        <th>Address</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Zip</th>
                        <th>Phone Number</th>
                    </tr>
                </thead>
                <tbody>
                    {/* Mapping through the bowlers array to display each bowler's information */}
                    {bowlers.map(bowler => (
                        <tr key={bowler.bowlerID}>  {/* Unique key for each row */}
                            <td>{bowler.bowlerFirstName}</td>
                            <td>{bowler.bowlerMiddleInit || "N/A"}</td>  {/* Handle empty middle initial */}
                            <td>{bowler.bowlerLastName}</td>
                            <td>{bowler.teamName || "No Team"}</td>  {/* Handle missing team name */}
                            <td>{bowler.bowlerAddress}</td>
                            <td>{bowler.bowlerCity}</td>
                            <td>{bowler.bowlerState}</td>
                            <td>{bowler.bowlerZip}</td>
                            <td>{bowler.bowlerPhoneNumber}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default BowlerTable;
