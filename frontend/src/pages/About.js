import React from "react";
/* $FlowFixMe */
import styled from "styled-components";

const HeaderOne = styled.div`
  text-align: center;
  color: #707070;
`;

const TextStyle = styled.p`
  text-align: center;
  width: 50%;
  margin: 0 auto;
  padding: 20px;
`;

export default () => (
  <div>
    <HeaderOne>
      <h1>
        What <span style={{ color: "#096" }}>edusent</span> does to help
        students
      </h1>
      <TextStyle>
        We connect students with tutors to promote academic success.
      </TextStyle>
    </HeaderOne>
  </div>
);
