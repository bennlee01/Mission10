import { useEffect, useState } from "react";

const BowlerTable = () => {
    const [bowlers, setBowlers] = useState([]);

    useEffect(() => {
        fetch("http://localhost:5000/api/bowlers")
            .then(response => response.json())
            .then(data => setBowlers(data))
            .catch(error => console.error("Error fetching data:", error));
    }, []);

    return (
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
            {bowlers.map((bowler, index) => (
                <tr key={index}>
                    <td>{bowler.FullName}</td>
                    <td>{bowler.TeamName}</td>
                    <td>{bowler.BowlerAddress}</td>
                    <td>{bowler.BowlerCity}</td>
                    <td>{bowler.BowlerState}</td>
                    <td>{bowler.BowlerZip}</td>
                    <td>{bowler.BowlerPhoneNumber}</td>
                </tr>
            ))}
            </tbody>
        </table>
    );
};

export default BowlerTable;
