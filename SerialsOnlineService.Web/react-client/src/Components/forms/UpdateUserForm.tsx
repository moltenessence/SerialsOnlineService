import { width } from "@mui/system";
import { Field, Form, Formik, ErrorMessage } from "formik";
import { IUpdateUserRequest, IUser } from "../../Common/Models/IUser";
import { AppDispatch } from "../../redux/store";
import { UserActions } from "../../redux/User/userReducer";
import { FormWrapper, FormItem, Button, ErrorWrapper } from "../styles/Form.style";

type Props = {
  user: IUser;
  updateUser: (user: IUpdateUserRequest) => (dispatch: AppDispatch<UserActions>) => Promise<void>;
}

function validateAge(value: number) {
  let error;
  if (value < 0 || value > 100) {
    error = 'Invalid age';
  }
  return error;
}

function validateUsername(value: string) {
  let error;
  if (value.length > 20) {
    error = 'Too long username.';
  }
  if (value === '') {
    error = 'Username field is required.';
  }
  return error;
}


const UpdateUserForm: React.FC<Props> = ({ user, updateUser }) => {
  return (
    <FormWrapper>
      <Formik
        initialValues={{ age: user?.age, userName: user.userName, id: user.id, email: user.email, subscriptionId: user.subscriptionId }}
        onSubmit={(values, { setSubmitting }) => {
          updateUser(values);
        }}
      >
        {({ errors, touched }) => (
          <Form>
            <FormItem>
              <div>Age: </div>
              <Field type="number" name="age" validate={validateAge} Min={0} />
            </FormItem>
            <FormItem>
              <div>Username: </div>
              <Field type="text" name="userName" validate={validateUsername} />
            </FormItem>
            <FormItem>
              <Button type="submit" disabled={false}>
                Submit
              </Button>
            </FormItem>
            {errors.age && touched.age && <ErrorWrapper> {errors.age} </ErrorWrapper>}
            {errors.userName && touched.userName && <ErrorWrapper> {errors.userName} </ErrorWrapper >}
          </Form>
        )}
      </Formik>
    </FormWrapper>
  );
};

export default UpdateUserForm;