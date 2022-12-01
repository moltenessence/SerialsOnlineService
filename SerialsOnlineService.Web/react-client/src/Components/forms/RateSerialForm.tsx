import { Field, Form, Formik, ErrorMessage } from "formik";
import ratingsService from "../../Services/RatingsService";
import { RatingButton, FormItem, FormWrapper , ErrorWrapper} from "../styles/Form.style";


type RateSerialFormValuesType = {
    value: number;
    annotation: string;
    serialId: number;
    userId: number;
}

type RateSerialFormProps = {
    userId: number;
    serialId: number;
}

function validateRatingValue(value: number) {
    let error;
    if (!value) {
      error = 'Required';
    } else if (value < 0  || value > 10) {
      error = 'Value must be in range 1 to 10.';
    }
    return error;
  }

const handleSubmit = (values: RateSerialFormValuesType, { setSubmitting }: { setSubmitting: (isSubmitting: boolean) => void }): void => {
    ratingsService.rateSerial(values);

    setSubmitting(false);
}

const RateSerialForm: React.FC<RateSerialFormProps> = ({ userId, serialId }) => {
    return (
        <FormWrapper>
            <FormItem>
                <h3>Leave your own rating:</h3>
            </FormItem>
            <Formik
                initialValues={{ value: 10, annotation: '', serialId: serialId, userId: userId }}
                onSubmit={handleSubmit}
            >
                {({ isSubmitting, errors, touched }) => (
                    <Form>
                        <FormItem>
                            <label>Rating:</label>
                            <Field type="number" name="value" validate={validateRatingValue} />
                        </FormItem>
                        <FormItem>
                            <label>Annotation (optional):</label>
                            <Field type="text" name="annotation" />
                        </FormItem>
                        <FormItem>
                            <RatingButton type="submit" disabled={isSubmitting}>
                                Submit
                            </RatingButton>
                        </FormItem>
                        {errors.value && touched.value && <ErrorWrapper>
                            {errors.value}
                        </ErrorWrapper>}
                    </Form>
                )}
            </Formik>
        </FormWrapper>
    );
};

export default RateSerialForm;