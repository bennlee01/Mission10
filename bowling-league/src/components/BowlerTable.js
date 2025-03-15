import { useEffect, useState } from "react"; // Import React hooks for side effects and state management

const BowlerTable = () => {
    // useState hook to store the list of bowlers
    const [bowlers, setBowlers] = useState([]);

    // useEffect hook to fetch data from the API when the component mounts
    useEffect(() => {
        // Fetching data from the API endpoint
        fetch("http://localhost:5000/api/bowlers")
            .then(response => response.json())  // Convert the response to JSON
            .then(data => setBowlers(data))     // Set the bowlers data to state
            .catch(error => console.error("Error fetching data:", error));  // Log any errors that occur during the fetch
    }, []); // Empty dependency array ensures this runs only once when the component mounts

    return (
        // Rendering the table of bowlers
        <table>
            <thead>
            <tr>
                <th>Name</th>
                <th>Team</th>
                <th>Address</th>
                <th>City</th>
                <th>State</th>
                <th>Zip</th>
                <th>Phone</th>
            </tr>
            </thead>
            <tbody>
            {/* Mapping over the bowlers array to display each bowler's details */}
            {bowlers.map((bowler, index) => (
                <tr key={index}>  {/* Use the index as the unique key for each row */}
                    <td>{bowler.FullName}</td>          {/* Display the full name of the bowler */}
                    <td>{bowler.TeamName}</td>          {/* Display the team name */}
                    <td>{bowler.BowlerAddress}</td>     {/* Display the bowler's address */}
                    <td>{bowler.BowlerCity}</td>        {/* Display the bowler's city */}
                    <td>{bowler.BowlerState}</td>       {/* Display the bowler's state */}
                    <td>{bowler.BowlerZip}</td}         {/* Display the bowler's zip code */}
                    <td>{bowler.BowlerPhoneNumber}</td> {/* Display the bowler's phone number */}
                </tr>
                ))}
            </tbody>
        </table>
    );
};

export default BowlerTable;  // Export the BowlerTable component for use in other parts of the app
