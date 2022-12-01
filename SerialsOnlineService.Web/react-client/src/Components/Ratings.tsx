import React, { useEffect, useState } from 'react';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';
import { IRating } from '../Common/Models/IRating';
import { RatingsWrapper, RatingItem, RatingField } from './styles/Ratings.style';

type Payload = {
    ratings: Array<IRating> | undefined;
}

type RatingsProps = Payload & ReactJSXIntrinsicAttributes

function getRatingAsStars(ratingValue: number): Array<string> {
    const stars = [];

    for (let i = 0; i < ratingValue; i++) {
        stars.push(String.fromCharCode(9733));
    }

    return stars;
}

const Ratings: React.FC<RatingsProps> = ({ ratings }) => {

    const [ratingsList, setRatings] = useState<JSX.Element[]>();

    useEffect(() => {
        const items = ratings?.map((rating: IRating) => {
            return (
                <RatingItem>
                    <RatingField><strong>Username:</strong> {rating.userName}</RatingField>
                    <RatingField><strong>Rating:</strong> {getRatingAsStars(rating.value)}</RatingField>
                    <RatingField><strong>Comment:</strong> {rating.annotation ?? 'User has not left any comments.'}</RatingField>
                </RatingItem>
            );
        }
        );

        setRatings(items)

    }, [ratings?.length])

    return (
        <RatingsWrapper>
            {ratingsList ?? 'No ratings for this serial.'}
        </RatingsWrapper>
    );
};


export default Ratings;