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
    serialId: number;
    rateSerial: any;
    openSerialInfo:any;
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

  function validateAnnotation(value:string)
{
  let error;
  if (value.length > 100) {
    error = 'Too long annotation.';
  }
  return error;
}

const RateSerialForm: React.FC<RateSerialFormProps> = ({ serialId, rateSerial, openSerialInfo }) => {

    const handleSubmit = (values: RateSerialFormValuesType, { setSubmitting }: { setSubmitting: (isSubmitting: boolean) => void }): void => {
        values.serialId = serialId;
        console.log(values);
        rateSerial(values);
    
        setSubmitting(false);
        openSerialInfo(false);
    }

    return (
        <FormWrapper>
            <FormItem>
                <h3>Leave your own rating:</h3>
            </FormItem>
            <Formik
                initialValues={{ value: 10, annotation: '', serialId: 0, userId: 0}}
                onSubmit={handleSubmit}
            >
                {({ isSubmitting, errors, touched }) => (
                    <Form>
                        <FormItem>
                            <div><label>Rating:</label></div>
                            <Field type="number" name="value" validate={validateRatingValue} />
                        </FormItem>
                        <FormItem>
                            <label>Annotation (optional):</label>
                            <Field type="text" name="annotation" validate={validateAnnotation} />
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