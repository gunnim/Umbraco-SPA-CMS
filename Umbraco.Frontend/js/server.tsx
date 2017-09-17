import 'expose-loader?React!react';
import 'expose-loader?ReactDOM!react-dom';
import 'expose-loader?ReactDOMServer!react-dom/server';

import React from 'react'; // Just to get around compiler errors, gets included elsewhere anyway
import { StaticRouter as Router } from 'react-router';

import App from './app';

const Routing = props => (
    <Router
        location={props.path}
        context={props.context}
    >
        <App {...props} />
    </Router>
);

// We could also wrap this module with a new base file and require+expose this module from there
// Instead we shortcut and access webpack's internal way of globalizing modules
global['Routing'] = Routing;
