import React from "react";
// $FlowFixMe
import styled from "styled-components";

const BlueScene = styled.div`
  text-align: center;
  background-color: none;
  color: #333;

  padding: 10px;
  margin: 1.5em auto;
  width: 50%;
`;

const BlueOverallLayout = styled.div`
  display: grid;
  grid-template-columns: 90%;
  grid-template-rows: 90%;
  grid-row-gap: 5px;
  justify-items: center;
  align-items: center;
`;

const BlueScenePosition = styled.div`
  margin: 0 auto;
  width: 550px;
`;

const BlueSceneLayoutHeader = styled.h2`
  text-align: left;
  color: #096;
`;

const BlueSceneLayoutText = styled.p`
  text-align: left;
`;

export default () => (
  <BlueScene>
    <BlueOverallLayout>
      <BlueScenePosition>
        <BlueSceneLayoutHeader>Contact</BlueSceneLayoutHeader>
        <BlueSceneLayoutText>
          Issues with the website?{" "}
          <a
            style={{ color: "#0C7", fontWeight: "bold" }}
            href="mailto:modulusyes@gmail.com"
          >
            Email us
          </a>
        </BlueSceneLayoutText>
        <BlueSceneLayoutText>
          Have bugs, errors, or suggestions for improvement? <br />
          Create an issue on our{" "}
          <a
            href="https://github.com/jeremii/edusent"
            style={{ color: "#0C7", fontWeight: "bold" }}
          >
            GitHub repo
          </a>
        </BlueSceneLayoutText>
      </BlueScenePosition>
    </BlueOverallLayout>
  </BlueScene>
);
