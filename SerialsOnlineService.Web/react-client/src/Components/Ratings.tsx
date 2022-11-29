import React from 'react';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';
import { IRating } from '../Common/Models/IRating';

type Payload = {
    ratings: Array<IRating> | undefined;
}

type RatingsProps = Payload & ReactJSXIntrinsicAttributes

const Ratings: React.FC<RatingsProps> = ({ ratings }) => {
    console.log('suka', ratings);

    const ratingsList = ratings?.map((rating: IRating) => {
        return (
                <div>
                    <p>User: {rating.userName}</p>
                    <p>Value: {rating.value}</p>
                    <p>Comment{rating.annotation ?? 'User has not left any comments.'}</p>
                </div>
        );
    }
    );

    return (
        <div>
            {ratingsList ?? 'No ratings for this serial.'}
        </div>
    );
};


export default Ratings;