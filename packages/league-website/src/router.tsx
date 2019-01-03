import React from "react";
import { hot } from "react-hot-loader";
import { Route, Switch, BrowserRouter } from "react-router-dom";

import Home from "./pages/Home/index";

function Router() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={Home} />
      </Switch>
    </BrowserRouter>
  );
}

export default hot(module)(Router);
