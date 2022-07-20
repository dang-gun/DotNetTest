const React = require("react");
const ReactDOM = require("react-dom/client");

import App from './App';

import Test from './pages/test/test';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <App />
        <Test />
    </React.StrictMode>
);