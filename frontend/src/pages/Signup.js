import React from "react";
import { Button, Typography } from "@material-ui/core";
import { Field, Formik, Form } from "formik";
import styled from "styled-components";
import * as Yup from "yup";
import Input from "../ui/Input";
import { apiFetch } from "../utils/fetchLight";
import SiteMargin from "../ui/SiteMargin";
import Stack from "../ui/Stack";

const signupSchema = Yup.object().shape({
  email: Yup.string().email("Invalid email address").required("Email Required"),
  password: Yup.string()
    .min(8, "Password must be at least 8 characters long.")
    .required("Password required."),
});

const StyledForm = styled.div`
  & > form {
    width: 750px;
    margin: auto;
    border: 3px solid #ccc;
    border-radius: 5px;
    padding: 2rem;
  }
`;

const Signup = ({ navigate }: Object) => {
  return (
    <SiteMargin>
      <Formik
        validateOnChange
        validationSchema={signupSchema}
        initialValues={{
          email: "",
          password: "",
        }}
        onSubmit={(formValues, formikBag) => {
          apiFetch("users/signup", "POST", formValues)
            .then(() => {
              navigate(`/`);
            })
            .catch(async (error) => {
              const body = await error.response.json();
              if (body.message) {
                formikBag.setStatus(body.message);
              }
            })
            .finally(() => formikBag.setSubmitting(false));
        }}
      >
        {({ isSubmitting, isValid, status }) => (
          <StyledForm>
            <Form>
              <Typography variant="h1">Signup</Typography>
              <Stack>
                <br />
                {status && <h4 style={{ color: "red" }}>{status}</h4>}
                <Field
                  id="email"
                  name="email"
                  label="Email"
                  component={Input}
                  variant="outlined"
                  placeholder="Email"
                  fullWidth
                />
                <Field
                  id="password"
                  name="password"
                  label="Password"
                  component={Input}
                  variant="outlined"
                  placeholder="Password"
                  type="Password"
                  fullWidth
                />
                <Button
                  type="submit"
                  fullWidth
                  color="primary"
                  variant="contained"
                  align="right"
                  disabled={isSubmitting || !isValid}
                >
                  Submit
                </Button>
              </Stack>
            </Form>
          </StyledForm>
        )}
      </Formik>
    </SiteMargin>
  );
};

export default Signup;
