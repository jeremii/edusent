import React from "react"
import { Router } from "@reach/router"
import {
  Home,
  Login,
  Signup,
  TeacherSessions,
  SessionCreate,
  SessionDetails,
  Search,
  About,
  Help,
  Contact,
  SearchTeachers,
} from "./pages"
import Layout from "./Layout"

export default () => (
  <Router>
    <Layout path="/">
      {/* $FlowFixMe */}
      <Home path="/" />
      <Login path="login" />
      <Signup path="signup" />
      <TeacherSessions path="/sessions/teacher/:userId" />
      {/* $FlowFixMe */}
      <SessionCreate path="/session/new" />
      <SearchTeachers path="/subjects/teachers/:term" />
      <About path="about" />
      <Help path="help" />
      <Contact path="contact" />
      <SessionDetails path="/session/:id" />
      <Search path="/search/:subject" />
      <Search path="/search/:subject/:pageId" />
    </Layout>
  </Router>
)
