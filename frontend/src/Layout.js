import React, { useState } from "react";
import type { Node } from "react";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import AppBar from "@material-ui/core/AppBar";
import { Link } from "@reach/router";
import { Menu, MenuItem } from "@material-ui/core";
import styled from "styled-components";
import { isNil } from "ramda";
import useUserInfo from "./hooks/useUserInfo";
import { apiFetch } from "./utils/fetchLight";

const CustomToolBar = styled(Toolbar)`
  & > h6 {
    margin-right: 1rem;
  }
  & a {
    color: white;
    text-decoration: none;
  }
  background-color: #096;
`;
const Logo = styled.span`
  & > a {
    color: #6f9;
    font-weight: 500;
  }
  margin-right: 2rem;
  font-size: 1.65em;
`;
const Subtitle = styled.div`
  font-size: 0.45em;
  display: none;
`;

type Props = {
  children: Node,
};

export default ({ children }: Props) => {
  return (
    <div>
      <AppBar position="static">
        <CustomToolBar>
          <Logo variant="h3">
            {/* $FlowFixMe */}
            <Link to="/">edusent</Link>
            <Subtitle>connecting students with tutors</Subtitle>
          </Logo>
          <Typography variant="h6">
            <Link to="/about">About</Link>
          </Typography>
          <Typography variant="h6">
            <Link to="/help">Help</Link>
          </Typography>
          <Typography variant="h6">
            <Link to="/contact">Contact</Link>
          </Typography>
          <UserNavOrDefault />
        </CustomToolBar>
      </AppBar>
      <main>{children}</main>
    </div>
  );
};

const UserNavOrDefault = () => {
  const { userInfo } = useUserInfo();
  const [anchorEl, setAnchorEl] = useState(null);

  const handleLogout = () => {
    apiFetch(`users/logout`, "POST", {}).then(() =>
      window.location.replace(`/login`)
    );
  };
  const handleClick = (e) => setAnchorEl(e.currentTarget);
  const handleClose = () => setAnchorEl(null);

  if (isNil(userInfo))
    return (
      <>
        <Typography variant="h6" style={{ marginLeft: "auto" }}>
          {/* $FlowFixMe */}
          <Link to="/signup">Signup</Link>
        </Typography>
        <Typography variant="h6">
          {/* $FlowFixMe */}
          <Link to="/login">Login</Link>
        </Typography>
        {/* <Typography onClick={handleLogout}>Logout</Typography> */}
      </>
    );
  return (
    <>
      <Typography
        variant="h6"
        onClick={handleClick}
        style={{ marginLeft: "auto", cursor: "pointer" }}
      >
        {userInfo.userName}
      </Typography>
      <Menu
        id="user-menu"
        open={Boolean(anchorEl)}
        anchorEl={anchorEl}
        onClose={handleClose}
      >
        <MenuItem onClick={handleClose}>
          {/* $FlowFixMe */}
          <Link to="/user/sessions"> My sessions</Link>
        </MenuItem>
        <MenuItem onClick={handleClose}>
          {/* $FlowFixMe */}
          <Link to="/sessions/new"> New session</Link>
        </MenuItem>
      </Menu>
      <Typography
        variant="h6"
        onClick={handleLogout}
        style={{ marginLeft: "relative", cursor: "pointer" }}
      >
        Logout
      </Typography>
    </>
  );
};
