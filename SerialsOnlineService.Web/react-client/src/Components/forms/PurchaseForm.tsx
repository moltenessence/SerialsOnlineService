import { Field, Form, Formik } from "formik";
import { Navigate, redirect } from "react-router-dom";
import { Button, FormItem, FormWrapper } from "../styles/Form.style";

type PurchaseFormValuesType = {
    amountOfMonths: number;
    subscriptionId: number;
    userId: number;
}

type PurchaseFormProps = {
    subscriptionId: number;
    makePurchase: any;
}

const PurchaseForm: React.FC<PurchaseFormProps> = ({ subscriptionId, makePurchase }) => {
    return (
        <FormWrapper>
            <Formik
                initialValues={{ amountOfMonths: 1, subscriptionId: subscriptionId, userId: 0 }}
                onSubmit={(values, actions) => {
                        makePurchase(values);

                        actions.setSubmitting(false);
                  }}
            >
                {({ isSubmitting }) => (
                    <Form>
                        <FormItem>
                            <label>Amount of months to obtain: </label>
                            <Field as="select" name="amountOfMonths">
                                <option value={1}>1 month</option>
                                <option value={3}>3 months</option>
                                <option value={6}>6 months</option>
                                <option value={9}>9 months</option>
                                <option value={12}>12 months</option>
                            </Field>
                        </FormItem>
                        <FormItem>
                            <Button type="submit" disabled={isSubmitting}>
                                Submit
                            </Button>
                        </FormItem>
                    </Form>
                )}
            </Formik>
        </FormWrapper>
    );
};

export default PurchaseForm;