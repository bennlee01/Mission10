import React from 'react';

// This is a simple React functional component that displays a heading and a description
const Heading = () => {
    return (
        <div>
            {/* Main heading for the page */}
            <h1>Bowling League Bowlers</h1>

            {/* A paragraph providing a brief description of the bowlers shown on the page */}
            <p>Here are the bowlers currently playing for the Marlins or Sharks teams.</p>
        </div>
    );
};

// Export the Heading component to be used in other parts of the application
export default Heading;
