import { Field, Form, Formik } from "formik";
import { ISerialsQueryFilter } from "../../Common/Models/ISerialsQueryFilter";
import { FormWrapper, FormItem, Button, SearchForm } from "../styles/Form.style";

type Props = {
    filterData: any;
}

const SerialsFilterForm: React.FC<Props> = ({ filterData }) => {
  return (
    <FormWrapper>
      <Formik
        initialValues={{ orderByAmountOfSeriesDesc: true, orderByReleaseDesc: false}}
        onSubmit={(values : ISerialsQueryFilter, { setSubmitting }) => {
            filterData(values);
        }}
      >
        {({ errors, touched }) => (
          <Form>
            <SearchForm>
            <FormItem>
              <div>Name (exact name): </div>
              <Field type="text" name="name" />
            </FormItem>
            <FormItem>
              <div>Release year: </div>
              <Field type="number" name="releaseYear" />
            </FormItem>
            <FormItem>
              <div>Amount of series: </div>
              <Field type="number" name="amountOfSeries" />
            </FormItem>
            <FormItem>
              <div>Order by release </div>
              <Field as="select" name="orderByReleaseDesc">
                                <option value={'true'}>Yes</option>
                                <option value={'false'}>No</option>
                </Field>
            </FormItem>
            <FormItem>
              <div>Order by amount of series </div>
              <Field as="select" name="orderByAmountOfSeries">
                                <option value={'true'}>Yes</option>
                                <option value={'false'}>No</option>
                </Field>
            </FormItem>
            <FormItem>
              <Button type="submit" disabled={false}>
                Submit
              </Button>
            </FormItem>
            </SearchForm>
          </Form>
        )}
      </Formik>
    </FormWrapper>
  );
};

export default SerialsFilterForm;