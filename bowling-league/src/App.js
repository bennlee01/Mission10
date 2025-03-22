import React from 'react';  // Import React
import './App.css';  // Import custom styles
import Heading from './components/Heading';  // Import Heading component
import BowlerTable from './components/BowlerTable';  // Import BowlerTable component
import 'bootstrap/dist/css/bootstrap.min.css';  // Import Bootstrap styles

function App() {
  return (
      <div className="App">  {/* Main wrapper div */}
        <Heading />  {/* Render the Heading component */}
        <BowlerTable />  {/* Render the BowlerTable component */}
      </div>
  );
}

export default App;  // Export App component to be used elsewhere
