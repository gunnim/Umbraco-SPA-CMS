/* ===============
 *  React Routing
 * =============== */
import React from 'react';
import { 
    Route,
    Switch,
    Redirect,
} from 'react-router';
import {
  TransitionGroup,
  CSSTransition,
} from 'react-transition-group';

var components = {
    '/': () => <p>Home</p>,
    about: () => <p>About</p>,
};

const RedirectWithStatus = ({ from, to, status }) => (
  <Route render={({ staticContext }) => {
    // there is no `staticContext` on the client, so
    // we need to guard against that here
    if (staticContext)
      staticContext.status = status
    return <Redirect from={from} to={to}/>
  }}/>
) 
RedirectWithStatus;

const Status = props => (
  <Route render={({ staticContext }) => {
    if (staticContext)
      staticContext.status = props.code
    return props.children
  }}/>
)

export const NotFound = () => (
  <Status code={404}>
    <div>
      <h1>Sorry, can’t find that.</h1>
    </div>
  </Status>
)

const renderMergedProps = (Component, ...rest) => {
  const finalProps = Object.assign({}, ...rest);
  return (
    <Component {...finalProps} />
  );
}

export const PropsRoute = ({ component, ...rest }) => {
  return (
    <Route {...rest} render={routeProps =>
      <CSSTransition 
        classNames="fade"
        timeout={{
          enter: 150,
          exit: 150,
        }}
        {...rest}
      >
          {renderMergedProps(component, routeProps, rest)}
      </CSSTransition>
    }/>
  );
}

const SwitchWrapper = ({ render, ...rest }) =>
  render(rest)

var routes = [
    '/',
    'about',
];

const App = props => 
  <div>
    <header>Header</header>
    <Route render={({ location }) => (
      <TransitionGroup>
        <SwitchWrapper render={transitionProps => (
          <Switch key={location.key} location={location}>
            {routes.map(route => 
                <PropsRoute exact {...props} path={route} {...transitionProps} component={components[route]} />
            )}
            <PropsRoute {...props} {...transitionProps} component={NotFound} />
          </Switch>
          )}/>
      </TransitionGroup>
    )}/>
    <footer>Footer</footer>
  </div>

export default App;
