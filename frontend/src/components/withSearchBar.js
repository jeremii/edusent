import React, { useState } from "react";
import type { ComponentType } from "react";
import SearchIcon from "@material-ui/icons/Search";
import InputBase from "@material-ui/core/InputBase";
import Button from "@material-ui/core/Button";
import { navigate } from "@reach/router";
// $FlowFixMe
import styled from "styled-components";

const SearchBox = styled.div`
  margin-bottom: 2rem;
  padding: 1rem 2rem;
  display: grid;
  flex-flow: row nowrap;
  grid-template: "search" auto / 100%;
  align-items: center;
`;

const SearchArea = styled.div`
  grid-area: 
`;


const SearchForm = styled.form`
  border: 2px solid #333;
  border-radius: 4px;
  border-color: #999;
  height: 50px;
  display: grid;
  grid-template-columns: 1fr auto;
  align-items: center;
  justify-content: space-between;
  & > button {
    align-self: stretch;
    width: 150px;
    background-color: #111;
    border-radius: 4px;
  }
  & > div {
    padding-left: 1rem;
  }
`;

function withSearchBar<C: ComponentType<any>>(WrapComponent: C) {
  return (props: {}) => {
    const [search, setSearch] = useState("");
    return (
      <>
    <SearchBox>
      <SearchArea>
        <SearchForm
          method="POST"
          onSubmit={(e) => {
            e.preventDefault();
            navigate(`/subjects/teachers/${search}`);
          }}
        >
          <InputBase
            placeholder="Search tutors by subject..."
            onChange={(e) => setSearch(e.target.value)}
            inputProps={{ "aria-label": "search" }}
          />
          <Button
            type="submit"
            startIcon={<SearchIcon />}
            color="primary"
            variant="contained"
          >
            Search
              </Button>
        </SearchForm>
      </SearchArea>
    </SearchBox>
    <WrapComponent {...props} />
  </>
    );
  };
}

export default withSearchBar;
