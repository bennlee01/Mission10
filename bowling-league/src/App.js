// Import the required styles and components
import './App.css';  // Import the CSS file for styling
import Header from "./components/Header";  // Import the Header component
import BowlerTable from "./components/BowlerTable";  // Import the BowlerTable component

// The main App component that renders the Header and BowlerTable
function App() {
    return (
        <div>
            {/* Render the Header component */}
            <Header />

            {/* Render the BowlerTable component */}
            <BowlerTable />
        </div>
    );
}

// Export the App component to be used in the index.js file
export default App;
