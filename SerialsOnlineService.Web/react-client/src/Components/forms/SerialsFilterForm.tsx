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
        initialValues={{ orderByAmountOfSeriesDesc: false, orderByReleaseDesc: false }}
        onSubmit={(values: ISerialsQueryFilter, { setSubmitting }) => {
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
                <Field type="number" name="releaseYear" Min={0} />
              </FormItem>
              <FormItem>
                <div>Amount of series: </div>
                <Field type="number" name="amountOfSeries" Min={0} />
              </FormItem>
              <FormItem>
                <div>Order by amount of series </div>
                <Field as="select" name="orderByAmountOfSeriesDesc">
                  <option value={'true'}>Descending</option>
                  <option value={'false'}>Ascending</option>
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