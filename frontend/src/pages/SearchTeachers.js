import React, { useState, useEffect } from "react"
import { Grid } from "@material-ui/core"
import { apiFetch } from "../utils/fetchLight"
import TeacherCard from "../components/TeacherCard"
import SiteMargin from "../ui/SiteMargin"

import withSearchBar from "../components/withSearchBar"

type Props = {
  term: string,
  teachers: {
    UserId: string,
    fullname: string,
    rating: string,
    subjects: string,
  },
}

const SearchTeachers = ({ term }: Props) => {
  const [teachers, setTeachers] = useState()
  useEffect(() => {
    // const urlConditions = urlParams.get("conditions");
    // const conditions = urlConditions ? urlConditions.split(",") : [];
    apiFetch(`subjects/teachers/${term}`)
      .then((res) => res.json())
      .then(setTeachers)
  }, [term])

  return (
    <SiteMargin>
      <Grid container spacing={3}>
        <Grid container spacing={3}>
          {teachers &&
            teachers.map((item) => (
              <TeacherCard teacher={item} key={item.UserId} />
            ))}
        </Grid>
      </Grid>
    </SiteMargin>
  )
}
// I really dislike having to do this to meet a deadline.
export default withSearchBar(SearchTeachers)
