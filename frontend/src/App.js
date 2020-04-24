import React from "react";
import { Router } from "@reach/router";
import {
  Home,
  Login,
  Signup,
  UserSessions,
  CreateSession,
  SessionDetails,
  Search,
  About,
  Help,
  Contact,
} from "./pages";
import Layout from "./Layout";

export default () => (
  <Router>
    <Layout path="/">
      {/* $FlowFixMe */}
      <Home path="/" />
      <Login path="login" />
      <Signup path="signup" />
      <UserSessions path="/user/sessions" />
      <UserSessions path="/user/sessions/:pageId" />
      {/* $FlowFixMe */}
      <CreateSession path="/session/new" />
      <About path="about" />
      <Help path="help" />
      <Contact path="contact" />
      <SessionDetails path="/session/:id" />
      <Search path="/search/:subject" />
      <Search path="/search/:subject/:pageId" />
    </Layout>
  </Router>
);
