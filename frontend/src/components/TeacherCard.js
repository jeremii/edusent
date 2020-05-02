import React from "react"
import { Link } from "@reach/router"
import { Grid, Card, Typography } from "@material-ui/core"
import styled from "styled-components"
import ImageWithFallback from "./ImageWithFallback"

type Props = {
  teacher: {
    UserId: string,
    FullName: string,
    Rating: string,
    Subjects: string,
  },
}

const StyledCard = styled(Card)`
  position: relative;
  display: grid;
  grid-template:
    "about" 100%;
  width: 260px;
  grid-gap: 0rem;
  padding: 1rem;
  overflow: visible !important;
  margin: 0.1rem;
  border: 2px solid #CCC;

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

const TeacherCard = ({
  teacher: { fullName, rating, subjects, id },
}: Props) => (
    <Grid item>
      {/* //$FlowFixMe */}
      <Link to={`/users/${id}`} style={{ textDecoration: "none" }}>
        <StyledCard>
          <div style={{ gridArea: "about" }}>
            <font color="gray"><strong>TEACHER</strong></font>
            <Typography variant="h4"><font color="#096">{fullName}</font></Typography>
            <Typography variant="subtitle1"><font color="#096"><strong>{rating}</strong></font></Typography>
            <br />
            <font color="gray"><strong>SUBJECTS</strong></font>
            <Typography variant="body1">{subjects}</Typography>

          </div>
        </StyledCard>
      </Link>
    </Grid>
  )

export default TeacherCard
