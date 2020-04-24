import React from "react";
// $FlowFixMe
import styled from "styled-components";
import {
  ExpansionPanel,
  ExpansionPanelSummary,
  ExpansionPanelDetails,
  Typography,
  // $FlowFixMe
} from "@material-ui/core/";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";

const HeaderOne = styled.div`
  text-align: center;
  color: #707070;
`;

const FAQ = styled.div`
  text-align: left;
  width: 50%;
  margin: 0 auto;
  padding: 20px 0px 0px 0px;
  color: #096;
`;

const SubHeader = styled.div`
  color: #888;
`;


export default () => (
  <div>
    <HeaderOne>{/* <h1>Help</h1> */}</HeaderOne>
    <SubHeader>
      <FAQ>
        <h2>FAQ</h2>
      </FAQ>
      <ExpansionPanel style={{ margin: "0 auto", width: "50%" }}>
        <ExpansionPanelSummary
          expandIcon={<ExpandMoreIcon />}
          aria-controls="panel1a-content"
          id="panel1a-header"
        >
          <Typography variant="h5">
            How do we find the best-suited tutor for you?
          </Typography>
        </ExpansionPanelSummary>
        <ExpansionPanelDetails>
          <Typography>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse
            malesuada lacus ex, sit amet blandit leo lobortis eget.
          </Typography>
        </ExpansionPanelDetails>
      </ExpansionPanel>
      <ExpansionPanel style={{ margin: "0 auto", width: "50%" }}>
        <ExpansionPanelSummary
          expandIcon={<ExpandMoreIcon />}
          aria-controls="panel1a-content"
          id="panel1a-header"
        >
          <Typography variant="h5">
            Can I schedule a session for my child?
          </Typography>
        </ExpansionPanelSummary>
        <ExpansionPanelDetails>
          <Typography>
            No, students must be at least 18 years old to qualify for a session.
          </Typography>
        </ExpansionPanelDetails>
      </ExpansionPanel>
      <ExpansionPanel style={{ margin: "0 auto", width: "50%" }}>
        <ExpansionPanelSummary
          expandIcon={<ExpandMoreIcon />}
          aria-controls="panel1a-content"
          id="panel1a-header"
        >
          <Typography variant="h5">
            Can I schedule a session at my residence?
          </Typography>
        </ExpansionPanelSummary>
        <ExpansionPanelDetails>
          <Typography>Yes!</Typography>
        </ExpansionPanelDetails>
      </ExpansionPanel>
    </SubHeader>
  </div>
);
