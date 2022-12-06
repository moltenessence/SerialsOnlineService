import { Field, Form, Formik } from "formik";
import { PriceFilterOptions } from "../../Common/Enums/PriceFilterOptions";
import { ISubscriptionFilter } from "../../Common/Models/ISubscriptionsFilter";
import { FormWrapper, FormItem, Button, SearchForm } from "../styles/Form.style";

type Props = {
  filterData: any;
}

const SubscriptionsFilterForm: React.FC<Props> = ({ filterData }) => {
  return (
    <FormWrapper>
      <Formik
        initialValues={{ priceFilterOption: PriceFilterOptions.MinimalPrice }}
        onSubmit={(values: ISubscriptionFilter) => {
          filterData(values);
        }}
      >
        {({ }) => (
          <Form>
            <SearchForm>
              <FormItem>
                <label>Select subscription with:  </label>
                <Field as="select" name="priceFilterOption">
                  <option value={PriceFilterOptions.MaximalPrice}>Max price</option>
                  <option value={PriceFilterOptions.MinimalPrice}>Min price</option>
                  <option value={PriceFilterOptions.All}>Show all</option>
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

export default SubscriptionsFilterForm;