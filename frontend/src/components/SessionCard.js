import React from "react"
import { Link } from "@reach/router"
import { Grid, Card, Typography } from "@material-ui/core"
import styled from "styled-components"


type Props = {}

const StyledCard = styled(Card)`
  position: relative;
  display: grid;
  grid-template: "about" 100%;
  width: 260px;
  grid-gap: 0rem;
  padding: 1rem;
  overflow: visible !important;
  margin: 0.1rem;
  border: 2px solid #ccc;

  & img {
    width: 100%;
  }

  & *[data-price] {
    color: white;
    position: absolute;
    right: -25px;
    top: -25px;
    z-index: 10;
    background: #000;
    padding: 0 0.2em;
    * {
      font-size: 2rem;
    }
  }
`

// const ExtraInfoLayout = styled.div`
//   padding-top: 1rem;
//   display: grid;
//   grid-template-columns: 1fr 1fr;

//   & > *:last-child {
//     justify-self: flex-end;
//     align-self: flex-end;
//   }
// `

const SessionCard = ({
  session: { duration, start, day = new Date(start) },
}: Props) => (
    <Grid item>
      {/* //$FlowFixMe */}
      <StyledCard>
        <div style={{ gridArea: "about" }}>
          <font color="gray">
            <strong>DATETIME</strong>
          </font>
          <Typography variant="h5">
            <font color="#096">
              {
                new Intl.DateTimeFormat('en-US', {
                  year: 'numeric',
                  month: 'short',
                  day: '2-digit',
                  hour: 'numeric', minute: 'numeric'
                }).format(day)

              }
            </font>
          </Typography>
          <Typography variant="h4">
            <font color="#096">
              <strong>{duration} mins</strong>
            </font>
          </Typography>
          <br />
          <font color="gray">
            <strong>STATUS</strong>
          </font>
          <Typography variant="body1">Confirmed</Typography>
        </div>
      </StyledCard>

    </Grid>
  )

export default SessionCard
