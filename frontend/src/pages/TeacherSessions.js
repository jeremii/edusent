import React, { useState, useEffect } from "react"
import { Grid, Typography } from "@material-ui/core"
import SessionCard from "../components/SessionCard"
import withSearchBar from "../components/withSearchBar"
import SiteMargin from "../ui/SiteMargin"
import { apiFetch } from "../utils/fetchLight"

type Props = {
  userId: string,
  teacher: {
    fullName: string,
    rating: string,
    subjects: string,
    userId: string,
  },
}

// Need paging, and need listing details page
const TeacherSessions = ({ userId }: Props) => {
  const [teacher, setTeacher] = useState();
  const [sessions, setSessions] = useState();
  useEffect(() => {
    apiFetch(`users/teacher/${userId}`)
      .then((res) => res.json())
      .then(setTeacher);
    apiFetch(`sessions/teacher/${userId}`)
      .then((res) => res.json())
      .then(setSessions);
  }, [userId])

  return (
    <SiteMargin>
      <Typography variant="h2">{teacher && teacher.fullName}</Typography>
      <Typography variant="h6"><font style=
        {{
          "fontSize": "0.65em",
          "fontWeight": "bold",
          "color": "gray"
        }}>RATING </font>
        {teacher && teacher.rating}</Typography>
      <Typography variant="h6">
        <font style=
          {{
            "fontSize": "0.65em",
            "fontWeight": "bold",
            "color": "gray"
          }}>SUBJECTS </font>{teacher && teacher.subjects}</Typography>
      <Grid container spacing={3} wrap="wrap" justify="space-around">
        {sessions &&
          sessions.map((item) => (
            <SessionCard session={item} key={item.id} />
          ))}
      </Grid>
    </SiteMargin >
  )
}

export default withSearchBar(TeacherSessions)
