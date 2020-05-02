import React from "react"
import { Field, Formik, Form } from "formik"
import { Typography, Button } from "@material-ui/core"
import * as Yup from "yup"
import styled from "styled-components"
import useApi from "../hooks/useApi"
import SiteMargin from "../ui/SiteMargin"
import RadioButton from "../ui/RadioButton"
import { apiFetch } from "../utils/fetchLight"
import Input from "../ui/Input"
import Stack from "../ui/Stack"

const getQueryParams = (url) => {
  const queries = new URLSearchParams(url)
  const params = {}
  queries.forEach((value, name) => {
    params[name] = value
  })
  return params
}

const callIfTruthyElseReturnDefault = (func) => (defaultVal) => (value) => {
  if (value) return func(value)
  return defaultVal
}

const sessionSchema = Yup.object().shape({
  title: Yup.string()
    .min(1)
    .required(),
  description: Yup.string()
    .min(1)
    .required(),
  authors: Yup.string()
    .min(1)
    .required(),
  price: Yup.number()
    .positive()
    .required(),
  condition: Yup.string()
    .min(1)
    .required(),
  contactOption: Yup.string()
    .min(1)
    .required(),
})

const StyledForm = styled.div`
  & > form {
    width: 750px;
    margin: auto;
    border: 3px solid #ccc;
    border-radius: 5px;
    padding: 2rem;
  }
`

const ConditionRadios = () => {
  const { data: conditions } = useApi("conditions")
  return (
    <fieldset>
      <legend>Condition</legend>
      {conditions &&
        conditions.map(({ value, name }) => (
          <Field
            key={name}
            id={value.toString()}
            name="condition"
            label={name}
            component={RadioButton}
          />
        ))}
    </fieldset>
  )
}

const getAboutText = (contactEnumValue) => {
  switch (contactEnumValue) {
    case 0:
      return "Seller will receive an email with the Buyer's contact information and an additional message. Buyer will not see any information about the Seller unless the Seller replies to the email"
    default:
      return "Missing Enum Match"
  }
}

const MethodOfContactRadios = () => {
  const { data } = useApi("listings/contact")

  return (
    <fieldset>
      <legend>Contact Option</legend>
      {data &&
        data
          .filter((x) => x.value === 0) // Match for now until additional options are available
          .map((x) => (
            <Field
              id={x.value.toString()}
              key={x.name}
              name="contactOption"
              label={x.name}
              component={RadioButton}
              about={getAboutText(x.value)}
            />
          ))}
    </fieldset>
  )
}

type Props = {
  navigate: (string) => any,
  location: { search: string },
}

const SessionCreate = ({ navigate }: Props) => {
  const {
    title,
    authors,
    description,
    smallThumbnail,
    thumbnail,
  } = getQueryParams(window.location.search)

  return (
    <SiteMargin>
      <Formik
        validationSchema={sessionSchema}
        initialValues={{
          title: title || "",
          description: description || "",
          price: "",
          authors: authors || "",
          smallThumbnail: smallThumbnail || "",
          thumbnail: thumbnail || "",
        }}
        onSubmit={(formValues, formikBag) => {
          apiFetch("sessions", "POST", formValues)
            .then(async (res) => {
              const body = await res.json()
              navigate(`/sessions/${body.id}`)
            })
            .finally(() => formikBag.setSubmitting(false))
        }}>
        {({ isSubmitting, isValid }) => (
          <StyledForm>
            <Form>
              <Typography variant="h1" gutterBottom>
                New Listing
              </Typography>
              <Typography variant="subtitle1" gutterBottom>
                Enter in your books details
              </Typography>
              <Stack>
                <Typography variant="h5" gutterBottom>
                  Book Details
                </Typography>
                <Field
                  name="title"
                  id="title"
                  placeholder="Title"
                  component={Input}
                  label="Title"
                  variant="outlined"
                  fullWidth
                  disabled={title}
                />
                <Field
                  id="description"
                  name="description"
                  label="Description"
                  component={Input}
                  variant="outlined"
                  placeholder="Description"
                  fullWidth
                  multiline
                  disabled={description}
                  rows="5"
                />
                <Field
                  id="authors"
                  name="authors"
                  label="Authors "
                  component={Input}
                  variant="outlined"
                  placeholder="Author(s)"
                  disabled={authors}
                  fullWidth
                />

                <Typography variant="h5" gutterBottom>
                  About Your Book. Please note that the price must be in US
                  dollars.
                </Typography>
                <hr />
                <Typography variant="h6" gutterBottom>
                  Please note that the price must be in US dollars.
                </Typography>
                <Field
                  id="price"
                  type="number"
                  name="price"
                  component={Input}
                  variant="outlined"
                  label="Price"
                  placeholder="ex. $10.00"
                  fullWidth
                  min={0}
                />
                <div>
                  <ConditionRadios />
                </div>
                <Typography variant="h5" gutterBottom>
                  How do you want to be contacted?
                </Typography>
                <MethodOfContactRadios />
                <Button
                  type="submit"
                  variant="contained"
                  color="primary"
                  align="right"
                  fullWidth
                  disabled={isSubmitting || !isValid}>
                  Submit
                </Button>
              </Stack>
            </Form>
          </StyledForm>
        )}
      </Formik>
    </SiteMargin>
  )
}

export default SessionCreate
