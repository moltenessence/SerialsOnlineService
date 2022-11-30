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
              <Field type="number" name="age" validate={validateAge}/>
            </FormItem>
            <FormItem>
              <div>Username: </div>
              <Field type="text" name="username" />
            </FormItem>
            <FormItem>
              <Button type="submit" disabled={false}>
                Submit
              </Button>
            </FormItem>
            {errors.age && touched.age && <ErrorWrapper> {errors.age} </ErrorWrapper>}
          </Form>
        )}
      </Formik>
    </FormWrapper>
  );
};

export default UpdateUserForm;