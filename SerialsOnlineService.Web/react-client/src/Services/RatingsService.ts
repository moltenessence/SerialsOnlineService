import { axiosInstance } from '../utils/axios';
import { IRating } from '../Common/Models/IRating';
import { IRateSerialRequest } from '../Common/Requests/RateSerialRequest';
import { IUpdateRatingRequest } from '../Common/Requests/UpdateRatingRequest';
import tokenStorage from './TokenStorage';
import usersService from './UsersService';

class RatingsService {
    public static async rateSerial(rating : IRateSerialRequest) {
        console.log(rating);

        const userId = await usersService.getByEmail(tokenStorage.getUserDataFromToken()?.email).then((user) => { return user.id });
        rating.userId = userId;
        
        const result = await axiosInstance.post<IRating>(`api/Rating`, {...rating}).
            then((response) => response.data);
        return result;
    }

    public static async deleteRating( id: number ) {
        const result = await axiosInstance.delete(`api/Rating/${id}}`).
            then((response) => response.data);
        return result;
    }

    public static async updateRating(id: number, rating : IUpdateRatingRequest) {
        const result = await axiosInstance.put<IRating>(`api/Rating/${id}`, {...rating}).
            then((response) => response.data);
        return result;
    }
}

export default RatingsService;