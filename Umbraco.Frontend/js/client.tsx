import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';

import App from './app';

import 'expose-loader?React!react';
import 'expose-loader?ReactDOM!react-dom';

const Routing = props => (
    <Router>
        <App {...props} />
    </Router>
);

// Expose loader does not offer syntax to expose ES6 modules in a good way
// Instead we access webpack's internal way of globalizing modules
//
// https://github.com/webpack-contrib/expose-loader/issues/43

// We could also wrap this module with a new base file and require+expose this module from there
// Instead we shortcut and access webpack's internal way of globalizing modules
global['Routing'] = Routing;
