import React, { useState, useEffect } from "react"
import styled from "styled-components"
import SearchIcon from "@material-ui/icons/Search"
import InputBase from "@material-ui/core/InputBase"
import Button from "@material-ui/core/Button"
import { navigate } from "@reach/router"
//  $FlowFixMe
import { ToastContainer, toast } from "react-toastify"
//  $FlowFixMe
import "react-toastify/dist/ReactToastify.css"

const SearchBox = styled.div`
  margin-bottom: 2rem;
  padding: 1rem 2rem;
  display: grid;
  flex-flow: row nowrap;
  grid-template: "logo search" auto / 20% 80%;
  align-items: center;
  color: white;
`

const SearchLayout = styled.div`
  display: grid;
  padding-top: 5rem;
  align-items: flex-start;
  justify-items: center;
  & h3 {
    color: white;
  }
`

const SearchForm = styled.form`
  border: 2px solid #3f51b5;
  border-radius: 4px;
  border-color: white;
  height: 43px;
  width: 500px;
  display: grid;
  grid-template-columns: 1fr auto;
  align-items: center;
  justify-content: space-between;
  position: absolute;
  color: white;
  position: relative;
  z-index: 2;
  background: white;

  & > button {
    align-self: stretch;
    width: 150px;
    border-radius: 4px;
    background-color: #000;
  }
  & > button:hover {
    background-color: #096;
  }
  & > div {
    padding-left: 1rem;
  }
  & input {
    color: gray !important;
    background: white;
  }
  & input::placeholder {
    opacity: 0.75;
  }
`

const MainContent = styled.div`
  background: rgba(0, 0, 0, 0.7)
    url("https://images.unsplash.com/photo-1522881193457-37ae97c905bf?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2250&q=80")
    center / cover no-repeat;

  background-blend-mode: darken;
  height: calc(
    100vh - 64px
  ); /* 64px is based off of material-ui navbar, Changes on smaller screens */
  text-align: center;
`
const Subtitle = styled.div`
  font-size: 2em;
  color: white;
  padding-top: 4em;
`

type Props = {
  location: { state: { register: string } },
}

const Home = ({ location }: Props) => {
  const [search, setSearch] = useState("")

  useEffect(() => {
    if (location.state) {
      const { register } = location.state
      toast(register)
    }
  })

  return (
    <MainContent>
      <ToastContainer />
      <Subtitle>Connecting students with tutors</Subtitle>
      <SearchLayout>
        <div>
          <SearchBox>
            <SearchForm
              method="POST"
              onSubmit={(e) => {
                e.preventDefault()
                navigate(`/subjects/teachers/${search}`)
              }}>
              <InputBase
                placeholder="Search for tutors by subject..."
                onChange={(e) => setSearch(e.target.value)}
                inputProps={{ "aria-label": "search" }}
              />
              <Button
                type="submit"
                startIcon={<SearchIcon />}
                color="primary"
                variant="contained">
                Search
              </Button>
            </SearchForm>
          </SearchBox>
        </div>
      </SearchLayout>
    </MainContent>
  )
}

export default Home
