import React from "react"
import { Link } from "@reach/router"
import { Grid, Card, Typography } from "@material-ui/core"
import styled from "styled-components"
import ImageWithFallback from "./ImageWithFallback"

type Props = {
  teacher: {
    id: string,
    fullname: string,
    rating: string,
    subjects: string,
  },
}

const StyledCard = styled(Card)`
  position: relative;
  display: grid;
  grid-template:
    "thumbnail" auto
    "about"/ 1fr;
  width: 400px;
  grid-gap: 1rem;
  padding: 1rem;
  overflow: visible !important;
  margin: 1rem;

  & img {
    width: 100%;
  }

  & *[data-price] {
    color: white;
    position: absolute;
    right: -25px;
    top: -25px;
    z-index: 10;
    background: #3f51b5;
    padding: 0 0.5rem;
    * {
      font-size: 2rem;
    }
  }
`

const ExtraInfoLayout = styled.div`
  padding-top: 1rem;
  display: grid;
  grid-template-columns: 1fr 1fr;

  & > *:last-child {
    justify-self: flex-end;
    align-self: flex-end;
  }
`

const TeacherCard = ({
  teacher: { fullname, rating, subjects, id },
}: Props) => (
  <Grid item>
    {/* //$FlowFixMe */}
    <Link to={`/users/${id}`} style={{ textDecoration: "none" }}>
      <StyledCard raised>
        <div style={{ gridArea: "about" }}>
          <Typography variant="h4">{fullname}</Typography>
          <Typography variant="subtitle1">{rating}</Typography>
          <ExtraInfoLayout>
            <Typography variant="body1">{subjects}</Typography>
          </ExtraInfoLayout>
        </div>
      </StyledCard>
    </Link>
  </Grid>
)

export default TeacherCard
